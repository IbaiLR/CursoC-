using System.ComponentModel.DataAnnotations;

namespace GestionTorneos.Models
{
    public class Torneo
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; } 
        public DateTime FechaFin { get; set; }
        public double Premio { get; set; }  
        public string Formato { get; set;  }
        public int JuegoId { get; set; }    
        public Juego Juego { get; set; }    
    }
}
