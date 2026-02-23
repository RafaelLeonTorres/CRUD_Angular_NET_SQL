using MaterialAPI.DTOs;

namespace MaterialAPI.Services
{
    public interface IMaterialService
    {
        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateAsync(int id, MaterialUpdateDTO material);
    }
}
