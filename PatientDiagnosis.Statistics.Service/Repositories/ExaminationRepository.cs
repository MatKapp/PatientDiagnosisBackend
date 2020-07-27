using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatientDiagnosis.Examinations.Service.Models;
using PatientDiagnosis.Examinations.Service.Models.DTO;
using PatientDiagnosis.Examinations.Service.Models.Entities;
using PatientDiagnosis.Examinations.Service.Repositories.Interfaces;
using PatientDiagnosis.Statistics.Service.Models.DTO;

namespace PatientDiagnosis.Examinations.Service.Repositories
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly ExaminationDbContext context;
        private readonly DbSet<Examination> examinations;

        public ExaminationRepository(ExaminationDbContext context)
        {
            this.context = context;
            this.examinations = context.Set<Examination>();
        }

        public Task<Examination> GetAsync(long id)
            => examinations
            .SingleOrDefaultAsync(examination => examination.Id == id);

        public async Task<Examination[]> GetAllAsync()
            => await examinations.ToArrayAsync();

        public async Task<IEnumerable<RoundedPredictionFrequency>> GetPredictionFrequencyStatistics()
        {
            var examinations = await GetAllAsync();

            var grouped = examinations.GroupBy(examination => Math.Round(examination.FirstClassPrediction, 1))
                .Select(grouped => new RoundedPredictionFrequency { RoandedPrediction = grouped.Key, Frequency = grouped.Count() })
                .ToArray();

            return grouped;
        }
    }
}
