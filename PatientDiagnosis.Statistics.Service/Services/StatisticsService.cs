using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PatientDiagnosis.Common.Models.Entities;
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
            var uriBuilder = new UriBuilder("https",apiGatewayAddress.Host ,apiGatewayAddress.Port, "/api/Examinations/Entries");
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

        public async Task<IEnumerable<TiaOccuredFrequency>> GetTiaOccuredFrequencyStatistics()
        {
            var examinations = await GetAllExaminationsAsync();

            var grouped = examinations
                .Where(examination => examination.TiaInTwoWeeksOccured.HasValue)
                .GroupBy(examination => examination.TiaInTwoWeeksOccured)
                .Select(grouped => new TiaOccuredFrequency { Occured = grouped.Key.Value, Frequency = grouped.Count() })
                .ToArray();

            return grouped;
        }

        public async Task<IEnumerable<ObservationOccurenceRatio>> GetObservationsRatioByTiaOccured(bool tiaOccured)
        {
            var examinations = await GetAllExaminationsAsync();
            var examinationsWithTiaOccured = examinations.Where(examination => examination.TiaInTwoWeeksOccured == tiaOccured);

            var observationsWithRatio = new List<ObservationOccurenceRatio>();
            var withObserbationValueAndTiaCount = examinations
                .Where(examination => examination.TiaInTwoWeeksOccured.GetValueOrDefault() && examination.Vertigo.HasValue)
                .Count();
            observationsWithRatio.Add(new ObservationOccurenceRatio
            {
                ObservationName = nameof(Examination.Vertigo),
                Ratio = (float) examinationsWithTiaOccured.Where(examination => examination.Vertigo.GetValueOrDefault()).Count() / withObserbationValueAndTiaCount
            });

            withObserbationValueAndTiaCount = examinations
                .Where(examination => examination.TiaInTwoWeeksOccured.GetValueOrDefault() && examination.SpeechDif.HasValue)
                .Count();
            observationsWithRatio.Add(new ObservationOccurenceRatio
            {
                ObservationName = nameof(Examination.SpeechDif),
                Ratio = (float)examinationsWithTiaOccured.Where(examination => examination.SpeechDif.GetValueOrDefault()).Count() / withObserbationValueAndTiaCount
            });

            withObserbationValueAndTiaCount = examinations
                .Where(examination => examination.TiaInTwoWeeksOccured.GetValueOrDefault() && examination.BodyWeakness.HasValue)
                .Count();
            observationsWithRatio.Add(new ObservationOccurenceRatio
            {
                ObservationName = nameof(Examination.BodyWeakness),
                Ratio = (float)examinationsWithTiaOccured.Where(examination => examination.BodyWeakness.GetValueOrDefault()).Count() / withObserbationValueAndTiaCount
            });

            withObserbationValueAndTiaCount = examinations
                .Where(examination => examination.TiaInTwoWeeksOccured.GetValueOrDefault() && examination.FirstTia.HasValue)
                .Count();
            observationsWithRatio.Add(new ObservationOccurenceRatio
            {
                ObservationName = nameof(Examination.FirstTia),
                Ratio = (float)examinationsWithTiaOccured.Where(examination => examination.FirstTia.GetValueOrDefault()).Count() / withObserbationValueAndTiaCount
            });

            withObserbationValueAndTiaCount = examinations
                .Where(examination => examination.TiaInTwoWeeksOccured.GetValueOrDefault() && examination.GaitDisturb.HasValue)
                .Count();
            observationsWithRatio.Add(new ObservationOccurenceRatio
            {
                ObservationName = nameof(Examination.GaitDisturb),
                Ratio = (float)examinationsWithTiaOccured.Where(examination => examination.GaitDisturb.GetValueOrDefault()).Count() / withObserbationValueAndTiaCount
            });

            withObserbationValueAndTiaCount = examinations
                .Where(examination => examination.TiaInTwoWeeksOccured.GetValueOrDefault() && examination.HighGlucose.HasValue)
                .Count();
            observationsWithRatio.Add(new ObservationOccurenceRatio
            {
                ObservationName = nameof(Examination.HighGlucose),
                Ratio = (float)examinationsWithTiaOccured.Where(examination => examination.HighGlucose.GetValueOrDefault()).Count() / withObserbationValueAndTiaCount
            });

            return observationsWithRatio;
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
