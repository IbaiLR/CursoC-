namespace GestionTorneos.Models.ViewModels
{
    public class CreateTorneoViewModel
    {
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double Premio { get; set; }
        public string Formato { get; set; }
        public int JuegoId { get; set; }
    }
}
