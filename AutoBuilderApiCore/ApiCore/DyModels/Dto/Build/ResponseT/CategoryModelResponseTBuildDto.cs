using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.Dto.Build.ResponseTs
{
    public class CategoryModelResponseTBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        public ITranslationData? Name { get; set; }
        public ITranslationData? Description { get; set; }
    }
}