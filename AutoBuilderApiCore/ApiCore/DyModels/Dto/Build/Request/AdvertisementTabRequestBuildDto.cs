using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Helper.Translation;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.Dto.Build.Requests
{
    public class AdvertisementTabRequestBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        /// <summary>
        /// AdvertisementId property for DTO.
        /// </summary>
        public String? AdvertisementId { get; set; }
        public TranslationData? Title { get; set; }
        public TranslationData? Description { get; set; }
        /// <summary>
        /// ImageAlt property for DTO.
        /// </summary>
        public String? ImageAlt { get; set; }
        public AdvertisementRequestBuildDto? Advertisement { get; set; }
    }
}