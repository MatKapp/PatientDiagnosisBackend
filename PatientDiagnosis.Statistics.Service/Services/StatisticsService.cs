using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PatientDiagnosis.Examinations.Service.Models.Entities;
using PatientDiagnosis.Examinations.Service.Services.Interfaces;
using PatientDiagnosis.Patients.Service.Models;
using PatientDiagnosis.Statistics.Service.Models.DTO;

namespace PatientDiagnosis.Examinations.Service.Services
{
    public class ExaminationService : IStatisticsService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly Uri apiGatewayAddress;

        public ExaminationService( IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            this.apiGatewayAddress = configuration.GetValue<Uri>("APIGatewayAddress");
        }

        public async Task<Examination[]> GetAllExaminationsAsync()
        {
            using var httpClient = httpClientFactory.CreateClient();
            var uriBuilder = new UriBuilder("https",apiGatewayAddress.Host ,apiGatewayAddress.Port, "/api/Examinations");
            var callResult = await httpClient.GetAsync(uriBuilder.ToString());
            var examinationsRespone = await callResult.Content.ReadAsStringAsync();
            var examinations = JsonConvert.DeserializeObject<Examination[]>(examinationsRespone);
            return examinations;
        }

        public async Task<Patient[]> GetAllPatientsAsync()
        {
            using var httpClient = httpClientFactory.CreateClient();
            var uriBuilder = new UriBuilder("https", apiGatewayAddress.Host, apiGatewayAddress.Port, "/api/Patients");
            var callResult = await httpClient.GetAsync(uriBuilder.ToString());
            var patientsResponse = await callResult.Content.ReadAsStringAsync();
            var patients = JsonConvert.DeserializeObject<Patient[]>(patientsResponse);
            return patients;
        }

        public async Task<IEnumerable<RoundedPredictionFrequency>> GetPredictionFrequencyStatistics()
        {
            var examinations = await GetAllExaminationsAsync();

            var grouped = examinations.GroupBy(examination => Math.Round(examination.FirstClassPrediction, 1))
                .Select(grouped => new RoundedPredictionFrequency { RoandedPrediction = (float)grouped.Key, Frequency = grouped.Count() })
                .ToArray();

            return grouped;
        }

        public async Task<IEnumerable<AggregatedAgeFrequency>> GetAgeFrequencyStatistics(int interval)
        {
            var patients = await GetAllPatientsAsync();


            var grouped = patients.GroupBy(patient => patient.Age / interval)
                .Select(grouped => new AggregatedAgeFrequency { DownAgeBoundary = grouped.Key * interval, UpAgeBoundary = (grouped.Key + 1) * interval, Frequency = grouped.Count() })
                .OrderBy(ageGrouped => ageGrouped.DownAgeBoundary)
                .ToArray();

            return grouped;
        }
    }
}
