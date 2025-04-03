using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Helper.Translation;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.Dto.Build.ResponseTs
{
    public class DialectResponseTBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        public TranslationData? Name { get; set; }
        public TranslationData? Description { get; set; }
        /// <summary>
        /// LanguageId property for DTO.
        /// </summary>
        public String? LanguageId { get; set; }
        public LanguageResponseTBuildDto? Language { get; set; }
    }
}