using AutoGenerator;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Setting : ITModel
    {
        [Key]
        public required string Name { get; set; }
        public string? Value { get; set; }
    }
}
