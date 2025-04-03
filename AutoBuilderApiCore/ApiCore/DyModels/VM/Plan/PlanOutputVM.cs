using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Plan  property for VM Output.
    /// </summary>
    public class PlanOutputVM : ITVM
    {
        ///
        public String? Id { get; set; }
        ///
        public String? ProductId { get; set; }
        //
        public string? ProductName { get; set; }
        //
        public string? Description { get; set; }
        //
        public ICollection<String>? Images { get; set; }
        ///
        public String? BillingPeriod { get; set; }
        ///
        public Double Amount { get; set; }
        ///
        public Boolean Active { get; set; }
        ///
        public DateTime UpdatedAt { get; set; }
        ///
        public DateTime CreatedAt { get; set; }
        //
        public ICollection<SubscriptionOutputVM>? Subscriptions { get; set; }
        //
        public ICollection<PlanFeatureOutputVM>? PlanFeatures { get; set; }
    }
}