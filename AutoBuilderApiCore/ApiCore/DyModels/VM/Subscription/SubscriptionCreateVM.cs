using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Subscription  property for VM Create.
    /// </summary>
    public class SubscriptionCreateVM : ITVM
    {
        ///
        public String? CustomerId { get; set; }
        ///
        public DateTime StartDate { get; set; }
        ///
        public DateTime CurrentPeriodStart { get; set; }
        ///
        public DateTime CurrentPeriodEnd { get; set; }
        ///
        public String? Status { get; set; }
        ///
        public Boolean CancelAtPeriodEnd { get; set; }
        ///
        public Int32 NumberRequests { get; set; }
        ///
        public Int32 AllowedRequests { get; set; }
        ///
        public Int32 AllowedSpaces { get; set; }
        ///
        public Nullable<DateTime> CancelAt { get; set; }
        ///
        public Nullable<DateTime> CanceledAt { get; set; }
        ///
        public String? PlanId { get; set; }
        ///
        public String? UserId { get; set; }
        //
        public ICollection<RequestCreateVM>? Requests { get; set; }
        //
        public ICollection<SpaceCreateVM>? Spaces { get; set; }
    }
}