using System;
using System.Threading.Tasks;
using PatientDiagnosis.Examinations.Service.Models.Entities;
using PatientDiagnosis.Examinations.Service.Repositories.Interfaces;
using PatientDiagnosis.Examinations.Service.Services.Interfaces;

namespace PatientDiagnosis.Examinations.Service.Services
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationRepository examinationRepository;

        public ExaminationService( IExaminationRepository examinationRepository)
        {
            this.examinationRepository = examinationRepository;
        }
        
        public async Task<Examination[]> GetAllAsync()
            => await examinationRepository.GetAllAsync();
    }
}
