using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatientDiagnosis.Examinations.Service.Models;
using PatientDiagnosis.Examinations.Service.Models.DTO;
using PatientDiagnosis.Examinations.Service.Models.Entities;
using PatientDiagnosis.Examinations.Service.Repositories.Interfaces;

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
        public async Task AddAsync(Examination examination)
        {
            await examinations.AddAsync(examination);
            await context.SaveChangesAsync();
        }

        public Task<Examination> GetAsync(long id)
            => examinations
            .SingleOrDefaultAsync(examination => examination.Id == id);

        public async Task<Examination[]> GetAllAsync()
            => await examinations.ToArrayAsync();

        public async Task DeleteAsync(Examination examination)
        {
            examinations.Remove(examination);
            await context.SaveChangesAsync();
        }

        public async Task UpdateExaminationPredictionsAsync(ExaminationPrediction prediction)
        {
            var examination = await GetAsync(prediction.Id);
            examination.FirstClassPrediction = (float)Math.Round(prediction.FirstClassPrediction, 2);
            examination.SecondClassPrediction= (float)Math.Round(prediction.SecondClassPrediction, 2);
            context.Entry(examination).Property("FirstClassPrediction").IsModified = true;
            context.Entry(examination).Property("SecondClassPrediction").IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateExaminationAsync(long id, Examination updatedExamination)
        {
            var examination = await GetAsync(id);
            updatedExamination.Id = id;
            updatedExamination.PatientId = examination.PatientId;
            context.Entry(examination).CurrentValues.SetValues(updatedExamination);
            await context.SaveChangesAsync();
        }

        public Task<Examination> GetByPatientAsync(long id)
            => examinations
                .Where(examination => examination.PatientId == id)
                .FirstOrDefaultAsync();

        public async Task UpdateTiaOccured(long examinationId, bool occurred)
        {
            var examination = await GetAsync(examinationId);
            examination.TiaInTwoWeeksOccured = occurred;
            context.Entry(examination).Property("TiaInTwoWeeksOccured").IsModified = true;
            await context.SaveChangesAsync();
        }
    }
}
