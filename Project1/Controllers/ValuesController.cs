using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;



namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly DBPRUEBASContext _dbcontext;

        public TareaController(DBPRUEBASContext context)
        {
            _dbcontext = context;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {

            List<Tarea> lista = _dbcontext.Tareas.OrderByDescending(t => t.IdTarea).ThenBy(t => t.FechaRegistro).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);

        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Tarea request)
        {
            if (request.Descripcion?.Length > 10) { 
                await _dbcontext.Tareas.AddAsync(request);
                await _dbcontext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, "La tarea tiene que tener como minimo 10 caracteres.");
            }
        }



        [HttpDelete]
        [Route("Cerrar/{id:int}")]
        public async Task<IActionResult> Cerrar(int id)
        {

            Tarea tarea = _dbcontext.Tareas.Find(id);

            _dbcontext.Tareas.Remove(tarea);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

    }
}
