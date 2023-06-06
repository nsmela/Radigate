using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Radigate.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase {
        private static List<Patient> Patients = new List<Patient>{
            new Patient {Id= 0, LastName = "Carey", FirstName="Drew"},
            new Patient {Id= 1, LastName = "Stiles", FirstName="Ryan"},
            new Patient {Id= 2, LastName = "Proops", FirstName="Greg"},
            new Patient {Id= 3, LastName = "Mocharie", FirstName="Colin"},
            new Patient {Id= 4, LastName = "Bradey", FirstName="Wayne"},
            new Patient {Id= 5, LastName = "Taylor", FirstName="Aishia"},
            new Patient {Id= 5, LastName = "Owen", FirstName="Clive"}
        };

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetPatient() {
            return Ok(Patients);
        }
    }
}
