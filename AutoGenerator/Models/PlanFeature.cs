using AutoGenerator;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PlanFeature : ITModel
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required] public string? Description { get; set; }
        public string? PlanId { get; set; }

        public Plan? Plan { get; set; }
    }
}
