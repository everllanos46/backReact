using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class History
    {
        [Key]
        public int IdHistory { get; set; }
        public string City{get; set;}
        public string Information{get; set;}
    }
}