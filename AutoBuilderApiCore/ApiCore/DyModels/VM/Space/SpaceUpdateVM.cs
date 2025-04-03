using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Space  property for VM Update.
    /// </summary>
    public class SpaceUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public SpaceCreateVM? Body { get; set; }
    }
}