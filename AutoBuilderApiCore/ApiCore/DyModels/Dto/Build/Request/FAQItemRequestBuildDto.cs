using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Requests
{
    public class FAQItemRequestBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String Id { get; set; }
        public ITranslationData? Question { get; set; }
        public ITranslationData? Answer { get; set; }
        public ITranslationData? Tag { get; set; }
    }
}