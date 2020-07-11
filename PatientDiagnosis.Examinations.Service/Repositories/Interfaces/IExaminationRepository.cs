﻿using System.Threading.Tasks;
using PatientDiagnosis.Examinations.Service.Models.DTO;
using PatientDiagnosis.Examinations.Service.Models.Entities;

namespace PatientDiagnosis.Examinations.Service.Repositories.Interfaces
{
    public interface IExaminationRepository
    {
        Task AddAsync(Examination examination);

        Task DeleteAsync(Examination examinationId);

        Task<Examination> GetAsync(long id);

        Task<Examination[]> GetAllAsync();

        Task UpdateExaminationPredictionsAsync(ExaminationPrediction prediction);
    }
}
