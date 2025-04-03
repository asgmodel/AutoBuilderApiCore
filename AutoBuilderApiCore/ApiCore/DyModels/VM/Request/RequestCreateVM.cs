using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Request  property for VM Create.
    /// </summary>
    public class RequestCreateVM : ITVM
    {
        ///
        public String? Status { get; set; }
        ///
        public String? Question { get; set; }
        ///
        public String? Answer { get; set; }
        ///
        public String? ModelGateway { get; set; }
        ///
        public String? ModelAi { get; set; }
        ///
        public DateTime CreatedAt { get; set; }
        ///
        public DateTime UpdatedAt { get; set; }
        ///
        public String? UserId { get; set; }
        ///
        public String? SubscriptionId { get; set; }
        ///
        public String? ServiceId { get; set; }
        ///
        public String? SpaceId { get; set; }
        //
        public ICollection<EventRequestCreateVM>? Events { get; set; }
    }
}