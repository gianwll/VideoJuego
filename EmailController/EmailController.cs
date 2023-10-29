using Microsoft.AspNetCore.Mvc;
using Universidad2.Context;
using Universidad2.Models;

namespace Universidad2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {
        public readonly AplicacionContext _aplicacionContext;
        public EmailController(AplicacionContext context)
        {
            _aplicacionContext = context;
        }
        [HttpPost]
        [Route("AgregarEmail")]
        public async Task<IActionResult> Post([FromBody] Email email)
        {
            _aplicacionContext.Email.Add(email);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Agregado");
        }
        [HttpGet]
        [Route("MostrarEmail")]
        public async Task<IActionResult> Get()
        {
            List<Email> listaEmail=_aplicacionContext.Email.OrderByDescending(e=>e.idEmail).ToList();
            return StatusCode(StatusCodes.Status200OK, listaEmail);
        }
        [HttpPut]
        [Route("EditarEmail/")]
        public async Task<IActionResult> Put([FromBody]Email email)
        {
            _aplicacionContext.Email.Update(email);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Editado correctamente");
        }
        [HttpDelete]
        [Route("EliminarEmail/")]
        public async Task<IActionResult> Delete(int? id)
        {
            Email email= _aplicacionContext.Email.Find(id);
            _aplicacionContext.Email.Remove(email);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Eliminado correctamente");

        }
    }
}
