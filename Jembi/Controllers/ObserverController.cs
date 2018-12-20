using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Jembi.Core.Interfaces;

namespace Jembi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ObserverController : Controller
    {
        private IObservationService _observationService;
        
        public ObserverController(IObservationService observationService)
        {
            _observationService = observationService;
        }


        [HttpGet("createobservation")]
        public IActionResult CreateObservation(string code, decimal value)
        {
            var item = _observationService.Create(code, value);

            return Ok(item);
        }

        [HttpGet("getvitalsignbypatient")]
        public IActionResult GetVitalSignByPatient(string patientId)
        {
            var item = _observationService.GetVitalSignByPatient(patientId);

            return Ok(item);
        }

        [HttpGet("getvitalsignbypatientandcode")]
        public IActionResult GetVitalSignByPatientAndCode(string patientId, string code)
        {
            var item = _observationService.GetVitalSignByPatientAndCode(patientId, code);

            return Ok(item);
        }

        [HttpGet("getvitalsignbycode")]
        public IActionResult GetVitalSignByCode(string code)
        {
            var item = _observationService.GetVitalSignByCode(code);

            return Ok(item);
        }

        [HttpGet("getobservationbyid")]
        public IActionResult GetObservationById(string id)
        {
            var item = _observationService.GetObservationById(id);

            return Ok(item);
        }
    }
}