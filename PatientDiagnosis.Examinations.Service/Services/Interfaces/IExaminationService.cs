using System.Threading.Tasks;
using PatientDiagnosis.Examinations.Service.Models.Entities;

namespace PatientDiagnosis.Examinations.Service.Services.Interfaces
{
    public interface IExaminationService
    {
        void Add(Examination examination);
        Task<Examination[]> GetAllAsync();
    }
}
