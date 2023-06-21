using Dientesitos_API.Model;
using Dientesitos_API.Service.CSede;
using Microsoft.AspNetCore.Mvc;

namespace Dientesitos_API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class SedeController : Controller
    {
        private readonly ISede _sede;
        public SedeController(ISede sede)
        {
            _sede = sede;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_sede.GetAllSedes());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _sede.GetSede(id);
            if (obj == null)
            {
                return NotFound("La Sede(" + id.ToString() + ") no existe");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost("agregar")]
        public IActionResult add(Sede sede)
        {
            _sede.add(sede);
            return CreatedAtAction(nameof(add), sede);
        }
        [HttpDelete("eliminar/{id}")]
        public IActionResult delete(int id)
        {
            _sede.delete(id);
            return NoContent();
        }
        [HttpPut("modificar")]
        public IActionResult modificar(Sede sede)
        {
            _sede.update(sede);
            return CreatedAtAction(nameof(modificar), sede);
        }
    }
}
