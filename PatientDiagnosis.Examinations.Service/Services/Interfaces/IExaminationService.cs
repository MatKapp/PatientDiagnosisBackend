using System.Threading.Tasks;
using PatientDiagnosis.Common.Models.Entities;
using PatientDiagnosis.Examinations.Service.Models.Entities;

namespace PatientDiagnosis.Examinations.Service.Services.Interfaces
{
    public interface IExaminationService
    {
        Task<Examination[]> GetAllAsync();
    }
}
