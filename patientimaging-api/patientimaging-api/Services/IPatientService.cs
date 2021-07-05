using System;
using System.Threading.Tasks;
using patientimaging_api.Models;

namespace patientimaging_api.Services
{
    public interface IPatientService
    {
        Task<bool> SavePatientAsync(PatientInputModel inputModel);
    }
}
