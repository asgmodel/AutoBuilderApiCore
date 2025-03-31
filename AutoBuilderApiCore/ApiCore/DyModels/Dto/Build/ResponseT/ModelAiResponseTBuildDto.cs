using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.Dto.Build.ResponseTs
{
    public class ModelAiResponseTBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        public ITranslationData? Name { get; set; }
        /// <summary>
        /// Token property for DTO.
        /// </summary>
        public String? Token { get; set; }
        /// <summary>
        /// AbsolutePath property for DTO.
        /// </summary>
        public String? AbsolutePath { get; set; }
        public ITranslationData? Category { get; set; }
        public ITranslationData? Language { get; set; }
        public ITranslationData? IsStandard { get; set; }
        public ITranslationData? Gender { get; set; }
        public ITranslationData? Dialect { get; set; }
        /// <summary>
        /// Type property for DTO.
        /// </summary>
        public String? Type { get; set; }
        /// <summary>
        /// ModelGatewayId property for DTO.
        /// </summary>
        public String? ModelGatewayId { get; set; }
        public ModelGatewayResponseTBuildDto? ModelGateway { get; set; }
        public ICollection<ServiceResponseTBuildDto>? Services { get; set; }
        public ICollection<UserModelAiResponseTBuildDto>? UserModelAis { get; set; }
    }
}