using Microsoft.EntityFrameworkCore;
using PatientDiagnosis.Examinations.Service.Models;
using PatientDiagnosis.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PatientDiagnosis.Repositories
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
    }
}
