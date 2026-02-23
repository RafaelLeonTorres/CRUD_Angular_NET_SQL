using MaterialAPI.DTOs;
using MaterialAPI.Utils;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MaterialAPI.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly string _connectionString;
        public MaterialService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(SpNames.DeleteMaterial, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    int result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<bool> UpdateAsync(int id, MaterialUpdateDTO material)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(SpNames.UpdateMaterial, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", material.Name);
                    command.Parameters.AddWithValue("@Description", material.Description);

                    int result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }
    }
}
