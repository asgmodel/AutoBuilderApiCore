using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Helper.Translation;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.Dto.Build.Requests
{
    public class CategoryModelRequestBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        public TranslationData? Name { get; set; } = new();
        public TranslationData? Description { get; set; } = new();
    }
}