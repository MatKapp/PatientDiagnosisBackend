using PatientDiagnosis.Examinations.Service.Models;
using PatientDiagnosis.Repositories.Interfaces;
using PatientDiagnosis.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PatientDiagnosis.Services
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationRepository examinationRepository;

        public ExaminationService( IExaminationRepository examinationRepository)
        {
            this.examinationRepository = examinationRepository;
        }
        public void Add(Examination patient)
        {
            throw new NotImplementedException();
        }

        public async Task<Examination[]> GetAllAsync()
            => await examinationRepository.GetAllAsync();
    }
}
