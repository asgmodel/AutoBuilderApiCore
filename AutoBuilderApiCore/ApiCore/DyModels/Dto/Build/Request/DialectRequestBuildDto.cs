using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Requests
{
    public class DialectRequestBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String Id { get; set; }
        public ITranslationData? Name { get; set; }
        public ITranslationData? Description { get; set; }
        /// <summary>
        /// LanguageId property for DTO.
        /// </summary>
        public String LanguageId { get; set; }
        public LanguageRequestBuildDto? Language { get; set; }
    }
}