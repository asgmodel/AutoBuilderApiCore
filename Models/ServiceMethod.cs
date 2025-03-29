
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Models
{
    public class ServiceMethod : ITModel
    {
        [Key]
        public required string Id { get; set; } = $"servm_{Guid.NewGuid():N}";
        public required string Method { get; set; }
        [DataType(DataType.Text)]
        public string? InputParameters { get; set; }
        [DataType(DataType.Text)]
        public string? OutputParameters { get; set; }

        public string ServiceId { get; set; }
        public Service Service { get; set; }


        public string[]? InputParams => JsonSerializer.Deserialize<string[]>(InputParameters!);
        public string[]? OutputParams => JsonSerializer.Deserialize<string[]>(OutputParameters!);
    }
}
