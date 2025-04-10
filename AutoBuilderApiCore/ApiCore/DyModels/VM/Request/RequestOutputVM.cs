using AutoGenerator;
using AutoGenerator.Helper.Translation;
using LAHJAAPI.Models;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Request  property for VM Output.
    /// </summary>
    public class RequestOutputVM : ITVM
    {
        ///
        public String? Id { get; set; }
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
        public ICollection<EventRequestOutputVM>? Events { get; set; }
    }
}