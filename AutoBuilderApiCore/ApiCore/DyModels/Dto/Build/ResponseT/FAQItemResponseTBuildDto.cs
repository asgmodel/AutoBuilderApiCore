using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.Dto.Build.ResponseTs
{
    public class FAQItemResponseTBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        public ITranslationData? Question { get; set; }
        public ITranslationData? Answer { get; set; }
        public ITranslationData? Tag { get; set; }
    }
}