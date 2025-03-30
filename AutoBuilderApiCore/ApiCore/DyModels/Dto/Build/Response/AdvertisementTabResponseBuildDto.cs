using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Responses
{
    public class AdvertisementTabResponseBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String Id { get; set; }
        /// <summary>
        /// AdvertisementId property for DTO.
        /// </summary>
        public String AdvertisementId { get; set; }
        /// <summary>
        /// Title property for DTO.
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// Description property for DTO.
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// ImageAlt property for DTO.
        /// </summary>
        public String ImageAlt { get; set; }
        public AdvertisementResponseBuildDto? Advertisement { get; set; }
    }
}