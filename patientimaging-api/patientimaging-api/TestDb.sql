CREATE DATABASE TestDb;

CREATE TABLE Patients (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    PolyclinicCode NVARCHAR(4) NOT NULL,
    DoctorRegistrationNumber NVARCHAR(8) NOT NULL,
    DoctorFullName NVARCHAR(255) NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Birthdate DATETIME NOT NULL,
    Gender ENUM('Female','Male','Unspecified') NOT NULL,
    IdentityNumber NVARCHAR(11) NOT NULL,
    PhoneNumber NVARCHAR(10) NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    NextAppointmentDate DATETIME,
    DoctorNote NVARCHAR(1000)
);