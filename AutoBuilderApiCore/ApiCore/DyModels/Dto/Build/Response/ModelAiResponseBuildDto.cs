using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Responses
{
    public class ModelAiResponseBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        /// <summary>
        /// Name property for DTO.
        /// </summary>
        public String? Name { get; set; }
        /// <summary>
        /// Token property for DTO.
        /// </summary>
        public String? Token { get; set; }
        /// <summary>
        /// AbsolutePath property for DTO.
        /// </summary>
        public String? AbsolutePath { get; set; }
        /// <summary>
        /// Category property for DTO.
        /// </summary>
        public String? Category { get; set; }
        /// <summary>
        /// Language property for DTO.
        /// </summary>
        public String? Language { get; set; }
        /// <summary>
        /// IsStandard property for DTO.
        /// </summary>
        public Nullable<Boolean> IsStandard { get; set; }
        /// <summary>
        /// Gender property for DTO.
        /// </summary>
        public String? Gender { get; set; }
        /// <summary>
        /// Dialect property for DTO.
        /// </summary>
        public String? Dialect { get; set; }
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