using AutoGenerator;
using AutoGenerator.Config;
using System.ComponentModel.DataAnnotations;

namespace LAHJAAPI.Models
{

    [ValidatorEnabled(true)]

    public class Setting : ITModel
    {
        [Key]
        public required string Name { get; set; }
        public string? Value { get; set; }
    }
}
