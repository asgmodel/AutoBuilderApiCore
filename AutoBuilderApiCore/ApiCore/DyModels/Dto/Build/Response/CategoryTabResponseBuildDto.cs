using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Responses
{
    public class CategoryTabResponseBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String Id { get; set; }
        /// <summary>
        /// Name property for DTO.
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Description property for DTO.
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Active property for DTO.
        /// </summary>
        public Boolean Active { get; set; }
        /// <summary>
        /// Image property for DTO.
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        /// UrlUsed property for DTO.
        /// </summary>
        public String UrlUsed { get; set; }
        /// <summary>
        /// CountFalvet property for DTO.
        /// </summary>
        public Int32 CountFalvet { get; set; }
        /// <summary>
        /// Rateing property for DTO.
        /// </summary>
        public Int32 Rateing { get; set; }
    }
}