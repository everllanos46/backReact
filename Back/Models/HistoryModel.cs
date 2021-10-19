using System.ComponentModel.DataAnnotations;
using Entidad;

namespace Back.Models{
    public class HistoryInputModel{
        [Required(ErrorMessage = "La ciudad requerida")]
        public string City{get; set;}
        [Required(ErrorMessage = "La información requerida")]
        public string Information{get; set;}
    }

    public class HistoryViewModel : HistoryInputModel{
        public HistoryViewModel()
        {
            
        }
        public HistoryViewModel(History history)
        {
            City= history.City;
            Information= history.Information;
        }


    }
}