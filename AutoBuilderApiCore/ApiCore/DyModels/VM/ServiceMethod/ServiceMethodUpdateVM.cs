using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// ServiceMethod  property for VM Update.
    /// </summary>
    public class ServiceMethodUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public ServiceMethodCreateVM? Body { get; set; }
    }
}