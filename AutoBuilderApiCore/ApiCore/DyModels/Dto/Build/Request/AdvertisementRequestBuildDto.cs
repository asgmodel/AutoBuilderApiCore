using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Requests
{
    public class AdvertisementRequestBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String Id { get; set; }
        /// <summary>
        /// Title property for DTO.
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// Description property for DTO.
        /// </summary>
        public String Description { get; set; }
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
        /// <summary>
        /// AdvertisementTabs property for DTO.
        /// </summary>
        public ICollection<AdvertisementTab> AdvertisementTabs { get; set; }
    }
}