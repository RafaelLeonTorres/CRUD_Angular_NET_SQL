using System.ComponentModel.DataAnnotations;

namespace MaterialAPI.DTOs
{
    public class MaterialCreateDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
