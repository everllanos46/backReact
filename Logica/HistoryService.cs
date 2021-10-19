using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class HistoryService
    {
        private PruebaContext _historyContext;
        public HistoryService(PruebaContext context)
        {
            _historyContext = context;
        }

        public SaveResponse GuardarHistorial(History history){
            try{
                _historyContext.Add(history);
                _historyContext.SaveChanges();
                return new SaveResponse(history);
            } catch(Exception e){
                return new SaveResponse("Hubo una exepción","Error");
            }
        }

        public GetResponse ConsultarHistoriales()
        {
            GetResponse consultarResponse = new GetResponse();
            try
            {
                consultarResponse.Error = false;
                consultarResponse.Mensaje = "Consultado correctamente";
                consultarResponse.Historiales = _historyContext.historiales.ToList();
            }
            catch (Exception e)
            {
                consultarResponse.Error = true;
                consultarResponse.Mensaje = $"Hubo un error al momento de consultar,{e.Message} ";
                consultarResponse.Historiales = null;
            }
            return consultarResponse;
        }

        
    }

    public class SaveResponse
    {

        public SaveResponse(History history)
        {
            Error = false;
            Estado = "Guardado";
        }

        public SaveResponse(string message, string estate)
        {
            Error = true;
            Mensaje = message;
            Estado = estate;
        }

        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public string Estado { get; set; }
    }

    public class GetResponse{
        public bool Error { get; set; }
        public String Mensaje { get; set; }
        public List<History> Historiales { get; set; }
    }

}