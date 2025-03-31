using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.Dto.Build.ResponseTs
{
    public class PlanResponseTBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        /// <summary>
        /// ProductId property for DTO.
        /// </summary>
        public String? ProductId { get; set; }
        public ITranslationData? ProductName { get; set; }
        public ITranslationData? Description { get; set; }
        public ICollection<String>? Images { get; set; }
        /// <summary>
        /// BillingPeriod property for DTO.
        /// </summary>
        public String? BillingPeriod { get; set; }
        /// <summary>
        /// Amount property for DTO.
        /// </summary>
        public Double Amount { get; set; }
        /// <summary>
        /// Active property for DTO.
        /// </summary>
        public Boolean Active { get; set; }
        /// <summary>
        /// UpdatedAt property for DTO.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// CreatedAt property for DTO.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        public ICollection<SubscriptionResponseTBuildDto>? Subscriptions { get; set; }
        public ICollection<PlanFeatureResponseTBuildDto>? PlanFeatures { get; set; }
    }
}