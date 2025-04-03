using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// PlanFeature  property for VM Update.
    /// </summary>
    public class PlanFeatureUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public PlanFeatureCreateVM? Body { get; set; }
    }
}