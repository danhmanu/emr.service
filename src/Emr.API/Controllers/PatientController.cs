using Emr.Domain.AggregatesModel.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientRepository Patientrepository;


        public PatientController(ILogger<PatientController> logger, IPatientRepository repository)
        {
            _logger = logger;
            Patientrepository = repository;
        }

        [HttpGet]
        //[Authorize]
        [Route("/GetProtectedData")]
        public IActionResult GetProtectedData()
        {
            var Pa = Patientrepository.GetPatientFull();
            return Ok(new { message = "This is protected data." });
        }

    }
}
