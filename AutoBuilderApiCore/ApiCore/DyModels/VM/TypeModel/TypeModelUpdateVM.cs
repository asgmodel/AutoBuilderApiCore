using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// TypeModel  property for VM Update.
    /// </summary>
    public class TypeModelUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public TypeModelCreateVM? Body { get; set; }
    }
}