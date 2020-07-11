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
            examination.FirstClassPrediction = prediction.FirstClassPrediction;            
            examination.SecondClassPrediction= prediction.SecondClassPrediction;
            examinations.Update(examination);
            context.SaveChanges();
        }
    }
}
