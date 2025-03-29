
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class AuthorizationSession : ITModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string SessionToken { get; set; }

        public string? UserToken { get; set; }


        [Required]
        public string AuthorizationType { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        [Required]
        public bool IsActive { get; set; }


        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public string IpAddress { get; set; }

        public string DeviceInfo { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string ServicesIds { get; set; }



        public AuthorizationSession()
        {

            Id = Guid.NewGuid().ToString();
            StartTime = DateTime.UtcNow;
            IsActive = true;
        }
    }

    public class FAQItem : ITModel
    {
        [Key]
        public string? Id { get; set; } = $"faq_{Guid.NewGuid():N}";

        public string? Question { get; set; }
        public string? Answer { get; set; }

        public string? Tag { get; set; } = "genarel";

    }
    class CategoryTab : ITModel
    {
        [Key]
        public string? Id { get; set; } = $"catg_{Guid.NewGuid():N}";

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public bool Active { get; set; }

        public string? Image { get; set; }

        public string? UrlUsed { get; set; }

        public int CountFalvet { get; set; } = 0;

        public int Rateing { get; set; } = 5;
    }

    public class TypeModel : ITModel
    {
        [Key]
        public string Id { get; set; } = $"type_{Guid.NewGuid():N}";

        [Required]
        public string? Name { get; set; } // مثل "Text-to-Speech", "API", "Dialect Conversion"

        public string? Description { get; set; }

        public bool Active { get; set; }

        public string? Image { get; set; }
    }

    public class Dialect : ITModel
    {
        [Key]
        public string Id { get; set; } = $"dialect_{Guid.NewGuid():N}";

        [Required]
        public string? Name { get; set; } // مثل "Najdi", "Hijazi", "Egyptian"
        public string? Description { get; set; }

        [Required]
        public string? LanguageId { get; set; } // مفتاح خارجي يرتبط باللغة
        public Language? Language { get; set; }
    }

    public class Advertisement : ITModel
    {
        [Key]
        public string Id { get; set; } = $"adv_{Guid.NewGuid():N}";

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public bool Active { get; set; } = true;

        public string? Url { get; set; }

        public ICollection<AdvertisementTab>? AdvertisementTabs { get; set; }
    }

    public class AdvertisementTab : ITModel
    {
        [Key]
        public string Id { get; set; } = $"adv_trans_{Guid.NewGuid():N}";

        [Required]
        public string? AdvertisementId { get; set; }


        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? ImageAlt { get; set; }


        public Advertisement Advertisement { get; set; }
    }

}
