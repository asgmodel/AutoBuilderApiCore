using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Helper.Translation;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.Dto.Build.Requests
{
    public class ModelAiRequestBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        public TranslationData? Name { get; set; }
        /// <summary>
        /// Token property for DTO.
        /// </summary>
        public String? Token { get; set; }
        /// <summary>
        /// AbsolutePath property for DTO.
        /// </summary>
        public String? AbsolutePath { get; set; }
        public TranslationData? Category { get; set; }
        public TranslationData? Language { get; set; }
        public TranslationData? IsStandard { get; set; }
        public TranslationData? Gender { get; set; }
        public TranslationData? Dialect { get; set; }
        /// <summary>
        /// Type property for DTO.
        /// </summary>
        public String? Type { get; set; }
        /// <summary>
        /// ModelGatewayId property for DTO.
        /// </summary>
        public String? ModelGatewayId { get; set; }
        public ModelGatewayRequestBuildDto? ModelGateway { get; set; }
        public ICollection<ServiceRequestBuildDto>? Services { get; set; }
        public ICollection<UserModelAiRequestBuildDto>? UserModelAis { get; set; }
    }
}