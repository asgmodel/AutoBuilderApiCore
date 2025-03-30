using AutoGenerator;
using System.ComponentModel.DataAnnotations;

namespace AutoGenerator.Models
{
    public class Setting : ITModel
    {
        [Key]
        public required string Name { get; set; }
        public string? Value { get; set; }
    }
}
