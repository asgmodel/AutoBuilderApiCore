using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Helper.Translation;
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
        public TranslationData? Question { get; set; }
        public TranslationData? Answer { get; set; }
        public TranslationData? Tag { get; set; }
    }
}