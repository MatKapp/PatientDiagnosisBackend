using System.Threading.Tasks;

namespace PatientDiagnosis.Common.Services.Interfaces
{
    public interface IRabbitMQHandler
    {
        void  HandleMessage(string message);
    }
}
