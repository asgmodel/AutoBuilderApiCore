using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Responses
{
    public class FAQItemResponseBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String Id { get; set; }
        /// <summary>
        /// Question property for DTO.
        /// </summary>
        public String Question { get; set; }
        /// <summary>
        /// Answer property for DTO.
        /// </summary>
        public String Answer { get; set; }
        /// <summary>
        /// Tag property for DTO.
        /// </summary>
        public String Tag { get; set; }
    }
}