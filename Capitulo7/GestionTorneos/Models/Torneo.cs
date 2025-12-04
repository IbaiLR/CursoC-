using K4os.Compression.LZ4.Streams.Adapters;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Engines;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
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

        public void Create(IConfiguration configuration)
        {
            try { 
            
                using var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                var sql = @"INSERT INTO torneos (Nombre, FechaInicio, FechaFin, Premio, Formato, JuegoId) 
                           VALUES(@Nombre, @FechaInicio, @FechaFin, @Premio, @Formato, @JuegoId)";
                using var cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
