using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// ModelAi  property for VM Update.
    /// </summary>
    public class ModelAiUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public ModelAiCreateVM? Body { get; set; }
    }
}