using Dientesitos_API.Model;
using Dientesitos_API.Service.CTratamiento;
using Microsoft.AspNetCore.Mvc;

namespace Dientesitos_API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class TratamientoController : Controller
    {
        private readonly ITratamiento _tratamiento;
        public TratamientoController(ITratamiento tratamiento)
        {
            _tratamiento = tratamiento;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tratamiento.GetAllTratamientos());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _tratamiento.GetTratamiento(id);
            if (obj == null)
            {
                return NotFound("El tratamiento (" + id.ToString() + ") no existe");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost("agregar")]
        public IActionResult add(Tratamiento tratamiento)
        {
            _tratamiento.add(tratamiento);
            return CreatedAtAction(nameof(add), tratamiento);
        }
        [HttpDelete("eliminar/{id}")]
        public IActionResult delete(int id)
        {
            _tratamiento.delete(id);
            return NoContent();
        }
        [HttpPut("modificar")]
        public IActionResult modificar(Tratamiento tratamiento)
        {
            _tratamiento.update(tratamiento);
            return CreatedAtAction(nameof(modificar), tratamiento);
        }
    }
}
