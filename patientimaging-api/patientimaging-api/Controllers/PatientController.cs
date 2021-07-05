using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using patientimaging_api.Hubs;
using patientimaging_api.Models;
using patientimaging_api.Persistence;
using patientimaging_api.Services;

namespace patientimaging_api
{
    [Route("api/v1/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IHubContext<PatientHub> _hubContext;
        public PatientController(IPatientService patientService, IHubContext<PatientHub> hubContext)
        {
            _patientService = patientService;
            _hubContext = hubContext;
            // _context = context;
        }

        // GET: api/Patient
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PatientDataModel>>> GetPatients()
        //{
        //    return await _context.Patients.ToListAsync();
        //}

        // GET: api/Patient/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PatientDataModel>> GetPatientDataModel(int id)
        //{
        //    var patientDataModel = await _context.Patients.FindAsync(id);

        //    if (patientDataModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return patientDataModel;
        //}

        // PUT: api/Patient/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPatientDataModel(int id, PatientDataModel patientDataModel)
        //{
        //    if (id != patientDataModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(patientDataModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PatientDataModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Patient
        //public async Task<ActionResult<PatientDataModel>> PostPatientDataModel(PatientDataModel patientDataModel)
        //{
        //    _context.Patients.Add(patientDataModel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPatientDataModel", new { id = patientDataModel.Id }, patientDataModel);
        //}

        [HttpPost]
        [Route("deliverypoint")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<IActionResult> PatientArrived(PatientInputModel inputModel)
        {
            var saveResult = await _patientService.SavePatientAsync(inputModel);

            if (saveResult)
            {
                PatientViewModel patientViewModel = new PatientViewModel
                {
                    PolyclinicCode = inputModel.PolyclinicCode,
                    DoctorRegistrationNumber = inputModel.DoctorRegistrationNumber,
                    DoctorFullName = inputModel.DoctorFullName,
                    Name = inputModel.Name,
                    Surname = inputModel.Surname,
                    Birthdate = inputModel.Birthdate,
                    Gender = inputModel.Gender,
                    IdentityNumber = inputModel.IdentityNumber,
                    PhoneNumber = inputModel.PhoneNumber,
                    AppointmentDate = inputModel.AppointmentDate,
                    NextAppointmentDate = inputModel.NextAppointmentDate,
                    DoctorNote = inputModel.DoctorNote,
                };

                await _hubContext.Clients.All.SendAsync("PatientMessageReceived", patientViewModel);
            }

            return StatusCode(200, saveResult);
        }

        // DELETE: api/Patient/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePatientDataModel(int id)
        //{
        //    var patientDataModel = await _context.Patients.FindAsync(id);
        //    if (patientDataModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Patients.Remove(patientDataModel);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PatientDataModelExists(int id)
        //{
        //    return _context.Patients.Any(e => e.Id == id);
        //}
    }
}
