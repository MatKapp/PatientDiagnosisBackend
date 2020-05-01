using PatientDiagnosis.Examinations.Service.Models;
using System.Threading.Tasks;

namespace PatientDiagnosis.Services.Interfaces
{
    public interface IExaminationService
    {
        void Add(Examination examination);
        Task<Examination[]> GetAllAsync();
    }
}
