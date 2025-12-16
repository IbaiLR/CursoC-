using K4os.Compression.LZ4.Streams.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using Org.BouncyCastle.Crypto.Engines;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
namespace GestionTorneos.Models
{
    public class Torneo
    {
        [Key] public int TorneoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; } 
        public DateTime FechaFin { get; set; }
        public double Premio { get; set; }  
        public string Formato { get; set;  }
        public int JuegoId { get; set; }
        public string JuegoNombre { get; set; }

        public void Create(IConfiguration configuration)
        {
            try { 
           
                using var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                var sql = @"INSERT INTO torneos (Nombre, FechaInicio, FechaFin, Premio, Formato, JuegoId) 
                           VALUES(@Nombre, @FechaInicio, @FechaFin, @Premio, @Formato, @JuegoId)";
                using var cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("Nombre", Nombre);
                cmd.Parameters.AddWithValue("FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("FechaFin", FechaFin);
                cmd.Parameters.AddWithValue("Premio", Premio);
                cmd.Parameters.AddWithValue("Formato", Formato);
                cmd.Parameters.AddWithValue("JuegoId", JuegoId);

                cmd.ExecuteNonQuery();

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List <Torneo> GetAll(IConfiguration configuration)
        {
            var listaTorneos = new List<Torneo>();
            using var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            string sql = @"
                        SELECT 
                            t.TorneoId,
                            t.Nombre,
                            t.FechaInicio,
                            t.FechaFin,
                            t.Premio,
                            t.Formato,
                            t.JuegoId,
                            j.Nombre AS JuegoNombre
                        FROM torneos t
                        JOIN juegos j ON t.JuegoId = j.JuegoId;
                    ";
            using var cmd = new MySqlCommand(sql, connection);
            using var reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {


                var torneo = new Torneo()
                {
                    TorneoId = reader.GetInt32("TorneoId"),
                    Nombre = reader.GetString("Nombre"),
                    FechaInicio = reader.GetDateTime("FechaInicio"),
                    FechaFin = reader.GetDateTime("FechaFin"),
                    Premio = reader.GetInt32("Premio"),
                    Formato = reader.GetString("Formato"),
                    JuegoId = reader.GetInt32("JuegoId"),
                    JuegoNombre= reader.GetString("JuegoNombre")
                };
                listaTorneos.Add(torneo);
            }
            return listaTorneos;
        }

        public static Torneo GetById(IConfiguration configuration, int TorneoId)
        {
            using var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            string sql = "SELECT * FROM torneos WHERE TorneoId=@TorneoId";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("TorneoId", TorneoId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Torneo torneo = new Torneo()
                {
                    TorneoId = reader.GetInt32("TorneoId"),
                    Nombre = reader.GetString("Nombre"),
                    FechaInicio = reader.GetDateTime("FechaInicio"),
                    FechaFin = reader.GetDateTime("FechaFin"),
                    Premio = reader.GetInt32("Premio"),
                    Formato = reader.GetString("Formato"),
                    JuegoId = reader.GetInt32("JuegoId")
                };
                return torneo;
            }
            else
            {
                return null;
            }
        }

        public static void DeleteById(IConfiguration configuration, int TorneoId)
        {
            using var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            string sql = "DELETE FROM torneos WHERE TorneoId= @TorneoId";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("TorneoId", TorneoId);
            cmd.ExecuteNonQuery();

        }
       

    }
}
