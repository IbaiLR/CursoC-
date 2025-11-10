using System.ComponentModel.DataAnnotations;
using System.Data.Common;
namespace EjemploMVC.Models;

public class Usuario
{
    int id { get; set; }
    string nombre { get; set; }
    string apellidos { get; set; }
    string email { get; set; }
    string contrasenna { get; set; }
    
    public Usuario()
}