using AutoGenerator;
using AutoGenerator.Helper.Translation;
using LAHJAAPI.Models;
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