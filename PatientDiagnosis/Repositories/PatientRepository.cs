using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatientDiagnosis.Patients.Service.Models;
using PatientDiagnosis.Patients.Service.Repositories.Interfaces;

namespace PatientDiagnosis.Patients.Service.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDbContext context;
        private readonly DbSet<Patient> patients;

        public PatientRepository(PatientDbContext context)
        {
            this.context = context;
            this.patients = context.Set<Patient>();
        }
        public async Task AddAsync(Patient patient)
        {
            await patients.AddAsync(patient);
            await context.SaveChangesAsync();
        }

        public Task<Patient> GetAsync(long id)
            => patients
            .SingleOrDefaultAsync(patient => patient.Id == id);

        public async Task<Patient[]> GetAllAsync()
            => await patients.ToArrayAsync();

        public async Task DeleteAsync(Patient patient)
        {
            patients.Remove(patient);
            await context.SaveChangesAsync();
        }
    }
}
