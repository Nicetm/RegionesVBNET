using DAL.Interfaces;
using DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DAL.Data
{
    public class ComunaRepository : IComunaRepository
    {
        private readonly string _connStr;

        public ComunaRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection")!;
        }

        public IEnumerable<Comuna> GetByRegion(int idRegion)
        {
            var comunas = new List<Comuna>();

            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("sp_GetComunasByRegion", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@IdRegion", idRegion);
            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comunas.Add(new Comuna
                {
                    IdComuna = (int)reader["IdComuna"],
                    IdRegion = (int)reader["IdRegion"],
                    Nombre = reader["Comuna"].ToString() ?? "",
                    InformacionAdicional = reader["InformacionAdicional"].ToString() ?? ""
                });
            }

            return comunas;
        }

        public Comuna GetById(int idRegion, int idComuna)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("sp_GetComunaById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@IdRegion", idRegion);
            cmd.Parameters.AddWithValue("@IdComuna", idComuna);
            conn.Open();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Comuna
                {
                    IdComuna = (int)reader["IdComuna"],
                    IdRegion = (int)reader["IdRegion"],
                    Nombre = reader["Comuna"].ToString() ?? "",
                    InformacionAdicional = reader["InformacionAdicional"].ToString() ?? ""
                };
            }

            return null!;
        }

        public void Merge(Comuna comuna, int idRegion)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("sp_MergeComuna", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@IdComuna", comuna.IdComuna);
            cmd.Parameters.AddWithValue("@IdRegion", idRegion);
            cmd.Parameters.AddWithValue("@Comuna", comuna.Nombre);
            cmd.Parameters.AddWithValue("@InformacionAdicional", comuna.InformacionAdicional ?? (object)DBNull.Value);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
