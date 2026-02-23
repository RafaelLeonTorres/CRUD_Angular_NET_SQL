using System.ComponentModel.DataAnnotations;

namespace MaterialAPI.DTOs
{
    public class MaterialReadDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
