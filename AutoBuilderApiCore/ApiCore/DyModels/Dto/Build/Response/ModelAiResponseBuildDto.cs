using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Helper.Translation;
using AutoGenerator.Models;
using AutoGenerator.Config;
using System;

namespace ApiCore.DyModels.Dto.Build.Responses
{
    public class ModelAiResponseBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        public TranslationData? Name { get; set; } = new();
        /// <summary>
        /// Token property for DTO.
        /// </summary>
        public String? Token { get; set; }
        /// <summary>
        /// AbsolutePath property for DTO.
        /// </summary>
        public String? AbsolutePath { get; set; }
        public TranslationData? Category { get; set; } = new();
        public TranslationData? Language { get; set; } = new();
        public TranslationData? IsStandard { get; set; } = new();
        public TranslationData? Gender { get; set; } = new();
        public TranslationData? Dialect { get; set; } = new();
        /// <summary>
        /// Type property for DTO.
        /// </summary>
        public String? Type { get; set; }
        /// <summary>
        /// ModelGatewayId property for DTO.
        /// </summary>
        public String? ModelGatewayId { get; set; }
        public ModelGatewayResponseBuildDto? ModelGateway { get; set; }
        public ICollection<ServiceResponseBuildDto>? Services { get; set; }
        public ICollection<UserModelAiResponseBuildDto>? UserModelAis { get; set; }
    }
}