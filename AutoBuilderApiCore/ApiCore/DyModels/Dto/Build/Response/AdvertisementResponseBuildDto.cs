using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Responses
{
    public class AdvertisementResponseBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String Id { get; set; }
        public ITranslationData? Title { get; set; }
        public ITranslationData? Description { get; set; }
        /// <summary>
        /// Image property for DTO.
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        /// Active property for DTO.
        /// </summary>
        public Boolean Active { get; set; }
        /// <summary>
        /// Url property for DTO.
        /// </summary>
        public String Url { get; set; }
        public ICollection<AdvertisementTabResponseBuildDto>? AdvertisementTabs { get; set; }
    }
}