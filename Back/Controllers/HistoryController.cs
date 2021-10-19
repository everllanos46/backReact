using Microsoft.AspNetCore.Mvc;
using Logica;
using Entidad;
using Datos;
using Back.Models;
using Microsoft.AspNetCore.Http;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private HistoryService _historyService;
        public HistoryController(PruebaContext pruebaContext)
        {
            _historyService = new HistoryService(pruebaContext);
        }

        [HttpPost]
        public ActionResult<HistoryViewModel> GuardarHistorial(HistoryInputModel historyInput){
            History history = Mapear(historyInput);
            var response = _historyService.GuardarHistorial(history);
            if(response.Error){
                ModelState.AddModelError("Error al guardar a la persona", response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                if(response.Estado.Equals("EXISTE"))   detalleProblemas.Status=StatusCodes.Status302Found;
                if(response.Error.Equals("ERROR"))   detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            response.Mensaje="Historial Guardado";
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<HistoryViewModel> ConsultarHistorial( ){
            var Response = _historyService.ConsultarHistoriales();
            if(Response == null){
                ModelState.AddModelError("Error al consultar al historial", "");
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            return Ok(Response.Historiales);
        }

        private History Mapear(HistoryInputModel historyInput){
            var history = new History{
                City = historyInput.City,
                Information = historyInput.Information,
            };
            return history;
        }
        
    }
}