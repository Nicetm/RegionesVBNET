using DAL.Interfaces;
using DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Data
{
    public class RegionRepository : IRegionRepository
    {
        private readonly string _connStr = string.Empty;

        public RegionRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Cadena de conexión no encontrada");
        }

        public IEnumerable<Region> GetAll()
        {
            var regiones = new List<Region>();

            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("sp_GetAllRegiones", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                regiones.Add(new Region
                {
                    IdRegion = (int)reader["IdRegion"],
                    Nombre = reader["Region"]?.ToString() ?? string.Empty
                });
            }

            return regiones;
        }

        public Region GetById(int id)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("sp_GetRegionById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@IdRegion", id);
            conn.Open();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Region
                {
                    IdRegion = (int)reader["IdRegion"],
                    Nombre = reader["Region"]?.ToString() ?? string.Empty
                };
            }

            return null;
        }
    }
}
