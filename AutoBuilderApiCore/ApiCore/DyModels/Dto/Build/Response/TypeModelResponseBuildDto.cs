using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Responses
{
    public class TypeModelResponseBuildDto : ITBuildDto
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
    }
}