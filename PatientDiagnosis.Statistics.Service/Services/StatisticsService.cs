using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PatientDiagnosis.Examinations.Service.Models.Entities;
using PatientDiagnosis.Examinations.Service.Services.Interfaces;
using PatientDiagnosis.Statistics.Service.Models.DTO;

namespace PatientDiagnosis.Examinations.Service.Services
{
    public class ExaminationService : IExaminationService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly Uri apiGatewayAddress;

        public ExaminationService( IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            this.apiGatewayAddress = configuration.GetValue<Uri>("APIGatewayAddress");
        }

        public async Task<Examination[]> GetAllAsync()
        {
            using var httpClient = httpClientFactory.CreateClient();
            var uriBuilder = new UriBuilder("https",apiGatewayAddress.Host ,apiGatewayAddress.Port, "/api/Examinations");
            var callResult = await httpClient.GetAsync(uriBuilder.ToString());
            var examinationsRespone = await callResult.Content.ReadAsStringAsync();
            var examinations = JsonConvert.DeserializeObject<Examination[]>(examinationsRespone);
            return examinations;
        }

        public async Task<IEnumerable<RoundedPredictionFrequency>> GetPredictionFrequencyStatistics()
        {
            var examinations = await GetAllAsync();

            var grouped = examinations.GroupBy(examination => Math.Round(examination.FirstClassPrediction, 3))
                .Select(grouped => new RoundedPredictionFrequency { RoandedPrediction = (float)grouped.Key, Frequency = grouped.Count() })
                .ToArray();

            return grouped;
        }
    }
}
