using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// PlanFeature  property for VM Create.
    /// </summary>
    public class PlanFeatureCreateVM : ITVM
    {
        //
        public ITranslationData? Name { get; set; }
        //
        public ITranslationData? Description { get; set; }
        ///
        public String? PlanId { get; set; }
        //
        public PlanCreateVM? Plan { get; set; }
    }
}