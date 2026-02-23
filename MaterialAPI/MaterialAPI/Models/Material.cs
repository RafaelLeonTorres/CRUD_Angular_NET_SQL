using System.ComponentModel.DataAnnotations;

namespace MaterialAPI.Models
{
    public class Material
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(50)]
        public string? Description { get; set; }
    }
}
