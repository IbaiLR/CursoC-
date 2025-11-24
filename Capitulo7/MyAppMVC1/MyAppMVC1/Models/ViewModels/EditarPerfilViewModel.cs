using System.ComponentModel.DataAnnotations;

namespace MyAppMVC1.Models.ViewModels
{
    public class EditarPerfilViewModel
    {
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellidos {  get; set; }
        [Required]
        public string email { get; set; }

    }
}
