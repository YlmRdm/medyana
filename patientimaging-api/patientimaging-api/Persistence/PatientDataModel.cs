using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using patientimaging_api.Models;

namespace patientimaging_api.Persistence
{
    [Table("Patients")]
    public class PatientDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4)")]
        // 4
        public string PolyclinicCode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(8)")]
        // 8
        public string DoctorRegistrationNumber { get; set; }

        [Required]
        public string DoctorFullName { get; set; }

        [Required]
        [Column("Patient Name")]
        // Patient Name
        public string Name { get; set; }

        [Required]
        [Column("Patient Surname")]
        // Patient Surname
        public string Surname { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(11)")]
        // 11
        public string IdentityNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        // 10
        public string PhoneNumber { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime NextAppointmentDate { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        // 1000
        public string DoctorNote { get; set; }
    }
}
