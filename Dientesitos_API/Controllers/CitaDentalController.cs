using Dientesitos_API.Model;
using Dientesitos_API.Service.CCita;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Dientesitos_API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class CitaDentalController : Controller
    {
        private readonly ICita _cita;
        public CitaDentalController(ICita cita)
        {
            _cita = cita;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cita.GetAllCitas());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _cita.GetCita(id);
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
        public IActionResult add(CitaDental citaDental)
        {
            _cita.add(citaDental);
            return CreatedAtAction(nameof(add), citaDental);
        }
        [HttpDelete("eliminar/{id}")]
        public IActionResult delete(int id)
        {
            _cita.delete(id);
            return NoContent();
        }
        [HttpPut("modificar")]
        public IActionResult modificar(CitaDental citaDental)
        {
            _cita.update(citaDental);
            return CreatedAtAction(nameof(modificar), citaDental);
        }
    }
}
