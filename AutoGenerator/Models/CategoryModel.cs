using AutoGenerator;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CategoryModel : ITModel
    {
        [Key]
        public string? Id { get; set; } = $"catm_{Guid.NewGuid():N}";

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }


    }

}
