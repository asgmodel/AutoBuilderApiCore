using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.Dto.Build.ResponseTs
{
    public class UserModelAiResponseTBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// CreatedAt property for DTO.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// UserId property for DTO.
        /// </summary>
        public String? UserId { get; set; }
        public ApplicationUserResponseTBuildDto? User { get; set; }
        /// <summary>
        /// ModelAiId property for DTO.
        /// </summary>
        public String? ModelAiId { get; set; }
        public ModelAiResponseTBuildDto? ModelAi { get; set; }
    }
}