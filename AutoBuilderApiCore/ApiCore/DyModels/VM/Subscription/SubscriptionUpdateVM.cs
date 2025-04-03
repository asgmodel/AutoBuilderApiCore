using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Subscription  property for VM Update.
    /// </summary>
    public class SubscriptionUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public SubscriptionCreateVM? Body { get; set; }
    }
}