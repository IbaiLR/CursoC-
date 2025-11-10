using System.ComponentModel.DataAnnotations;

namespace MyAppMVC1.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Email { get; set; } 
        [Required]
        public string Contrasenna { get; set; }

        

    }
}
