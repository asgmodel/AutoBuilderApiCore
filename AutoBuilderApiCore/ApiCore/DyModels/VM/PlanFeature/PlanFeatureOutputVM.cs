using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// PlanFeature  property for VM Output.
    /// </summary>
    public class PlanFeatureOutputVM : ITVM
    {
        ///
        public Int32 Id { get; set; }
        //
        public string? Name { get; set; }
        //
        public string? Description { get; set; }
        ///
        public String? PlanId { get; set; }
        //
        public PlanOutputVM? Plan { get; set; }
    }
}