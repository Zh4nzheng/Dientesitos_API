using Dientesitos_API.Model;
using Dientesitos_API.Service.CDoctor;
using Microsoft.AspNetCore.Mvc;

namespace Dientesitos_API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctor _doctor;
        public DoctorController(IDoctor doctor)
        {
            _doctor = doctor;
        }
        [HttpGet]
        public IActionResult Get ()
        {
            return Ok(_doctor.GetAllDoctores());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _doctor.GetDoctor(id);
            if (obj == null)
            {
                return NotFound("El producto(" + id.ToString() + ") no existe");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost("agregar")]
        public IActionResult add(Doctor doctor)
        {
            _doctor.add(doctor);
            return CreatedAtAction(nameof(add), doctor);
        }
        [HttpDelete("eliminar/{id}")]
        public IActionResult delete(int id)
        {
            _doctor.delete(id);
            return NoContent();
        }
        [HttpPut("modificar")]
        public IActionResult modificar(Doctor doctor)
        {
            _doctor.update(doctor);
            return CreatedAtAction(nameof(modificar), doctor);
        }
    }
}
