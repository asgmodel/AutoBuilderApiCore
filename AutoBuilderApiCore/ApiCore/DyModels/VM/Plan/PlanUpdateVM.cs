using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Plan  property for VM Update.
    /// </summary>
    public class PlanUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public PlanCreateVM? Body { get; set; }
    }
}