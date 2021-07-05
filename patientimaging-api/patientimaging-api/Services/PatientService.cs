using System;
using System.Threading.Tasks;
using patientimaging_api.Models;
using patientimaging_api.Persistence;

namespace patientimaging_api.Services
{
    public class PatientService : IPatientService
    {
        private readonly MainDbContext _mainDbContext;

        public PatientService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<bool> SavePatientAsync(PatientInputModel inputModel)
        {
            try
            {
                PatientDataModel patientModel = new PatientDataModel();
                patientModel.PolyclinicCode = inputModel.PolyclinicCode;
                patientModel.DoctorRegistrationNumber = inputModel.DoctorRegistrationNumber;
                patientModel.DoctorFullName = inputModel.DoctorFullName;
                patientModel.Name = inputModel.Name;
                patientModel.Surname = inputModel.Surname;
                patientModel.Birthdate = inputModel.Birthdate;
                patientModel.Gender = inputModel.Gender;
                patientModel.IdentityNumber = inputModel.IdentityNumber;
                patientModel.PhoneNumber = inputModel.PhoneNumber;
                patientModel.AppointmentDate = inputModel.AppointmentDate;
                patientModel.NextAppointmentDate = inputModel.NextAppointmentDate;
                patientModel.DoctorNote = inputModel.DoctorNote;

                _mainDbContext.Patients.Add(patientModel);

                return await _mainDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}