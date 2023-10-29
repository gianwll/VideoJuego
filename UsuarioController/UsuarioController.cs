using Microsoft.AspNetCore.Mvc;
using Universidad2.Context;
using Universidad2.Models;

namespace Universidad2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        public readonly AplicacionContext _aplicacionContext;
        public UsuarioController(AplicacionContext context)
        {
            _aplicacionContext = context;
        }
        [HttpPost]
        [Route("AgregarUsuario")]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            _aplicacionContext.Usuario.Add(usuario);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Agregado");
        }
        [HttpGet]
        [Route("MostrarUsuario")]
        public async Task<IActionResult> Get()
        {
            List<Usuario> listaEmail = _aplicacionContext.Usuario.OrderByDescending(e => e.idUsuario).ToList();
            return StatusCode(StatusCodes.Status200OK, listaEmail);
        }
        [HttpPut]
        [Route("EditarUsuario/")]
        public async Task<IActionResult> Put([FromBody] Usuario usuario)
        {
            _aplicacionContext.Usuario.Update(usuario);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Editado correctamente");
        }
        [HttpDelete]
        [Route("EliminarUsuario/")]
        public async Task<IActionResult> Delete(int? id)
        {
            Usuario usuario = _aplicacionContext.Usuario.Find(id);
            _aplicacionContext.Usuario.Remove(usuario);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Eliminado correctamente");

        }
    }
}
