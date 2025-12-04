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
    public class Juego
    {
        [Key] public int JuegoId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Empresa { get; set; }
        public int AnnoLanzamiento { get; set; }
        //public ICollection<Torneo> Torneos { get; set; }


        public void Create(IConfiguration configuration)
        {
           
            try
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                using var connection = new MySqlConnection(connectionString);
                connection.Open();
                var sql = @"INSERT INTO juegos (Nombre, Genero, Empresa, AnnoLanzamiento) 
                            VALUES (@Nombre, @Genero, @Empresa, @AnnoLanzamiento)";

                using var cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Genero", Genero);
                cmd.Parameters.AddWithValue("@Empresa", Empresa);
                cmd.Parameters.AddWithValue("@AnnoLanzamiento", AnnoLanzamiento);
                
                cmd.ExecuteNonQuery();

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static List<Juego> getAll(IConfiguration configuration)
        {
            try
            {
                List <Juego> listaJuegos= new List<Juego>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                using var connection = new MySqlConnection(connectionString);
                connection.Open();
                var sql = "SELECT * FROM juegos";
                using var cmd = new MySqlCommand(sql, connection);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var juego = new Juego
                    {
                        JuegoId = reader.GetInt32("JuegoId"),
                        Nombre = reader.GetString("Nombre"),
                        Genero = reader.GetString("Genero"),
                        Empresa = reader.GetString("Empresa"),
                        AnnoLanzamiento = reader.GetInt32("AnnoLanzamiento")
                    };
                    listaJuegos.Add(juego);
                }
                return listaJuegos;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
