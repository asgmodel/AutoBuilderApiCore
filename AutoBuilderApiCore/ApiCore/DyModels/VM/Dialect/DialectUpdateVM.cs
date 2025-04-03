using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Dialect  property for VM Update.
    /// </summary>
    public class DialectUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public DialectCreateVM? Body { get; set; }
    }
}