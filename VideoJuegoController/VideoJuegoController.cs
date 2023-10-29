using Microsoft.AspNetCore.Mvc;
using Universidad2.Context;
using Universidad2.Models;

namespace Universidad2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoJuegoController : Controller
    {
        public readonly AplicacionContext _aplicacionContext;
        public VideoJuegoController(AplicacionContext context)
        {
            _aplicacionContext = context;
        }
        [HttpPost]
        [Route("AgregarVideoJuego")]
        public async Task<IActionResult> Post([FromBody] VideoJuego videoJuego)
        {
            _aplicacionContext.VideoJuego.Add(videoJuego);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Agregado");
        }
        [HttpGet]
        [Route("MostrarVideoJuego")]
        public async Task<IActionResult> Get()
        {
            List<VideoJuego> listaVideoJuegos = _aplicacionContext.VideoJuego.OrderByDescending(e => e.idVideoJuego).ToList();
            return StatusCode(StatusCodes.Status200OK, listaVideoJuegos);
        }
        [HttpPut]
        [Route("EditarVideoJuego/")]
        public async Task<IActionResult> Put([FromBody] VideoJuego videoJuego)
        {
            _aplicacionContext.VideoJuego.Update(videoJuego);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Editado correctamente");
        }
        [HttpDelete]
        [Route("EliminarVideoJuego/")]
        public async Task<IActionResult> Delete(int? id)
        {
            VideoJuego videoJuego = _aplicacionContext.VideoJuego.Find(id);
            _aplicacionContext.VideoJuego.Remove(videoJuego);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Eliminado correctamente");

        }
    }
}
