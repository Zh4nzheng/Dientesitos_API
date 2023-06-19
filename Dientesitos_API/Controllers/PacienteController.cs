using Dientesitos_API.Model;
using Dientesitos_API.Service.CPaciente;
using Microsoft.AspNetCore.Mvc;

namespace Dientesitos_API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        private readonly IPaciente _paciente;
        public PacienteController(IPaciente paciente)
        {
            _paciente = paciente;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_paciente.GetAllPacientes());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var obj = _paciente.GetPaciente(id);
            if(obj == null) 
            {
                return NotFound("El producto("+id.ToString()+") no existe");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost("agregar")]
        public IActionResult add(Paciente paciente)
        {
            _paciente.add(paciente);
            return CreatedAtAction(nameof(add),paciente);
        }
        [HttpDelete("eliminar/{id}")]
        public IActionResult delete(int id) 
        {
            _paciente.delete(id);
            return NoContent();
        }
        [HttpPut("modificar")]
        public IActionResult modificar(Paciente paciente)
        {
            _paciente.update(paciente);
            return CreatedAtAction(nameof(modificar), paciente);
        }
    }
}
