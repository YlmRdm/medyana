using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace patientimaging_api.Models
{
    public struct PatientViewModel
    {
        [Required]
        [Column(TypeName = "nvarchar(4)")]
        public string PolyclinicCode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(8)")]
        public string DoctorRegistrationNumber { get; set; }

        [Required]
        public string DoctorFullName { get; set; }

        [Required]
        [Column("Patient Name")]
        public string Name { get; set; }

        [Required]
        [Column("Patient Surname")]
        public string Surname { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(11)")]
        public string IdentityNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string PhoneNumber { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime NextAppointmentDate { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string DoctorNote { get; set; }
    }
}
