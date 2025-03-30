using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Requests
{
    public class PlanFeatureRequestBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// Name property for DTO.
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Description property for DTO.
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// PlanId property for DTO.
        /// </summary>
        public String PlanId { get; set; }
        public PlanRequestBuildDto? Plan { get; set; }
    }
}