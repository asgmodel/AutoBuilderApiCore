using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// ServiceMethod  property for VM Create.
    /// </summary>
    public class ServiceMethodCreateVM : ITVM
    {
        ///
        public String? Method { get; set; }
        ///
        public String? InputParameters { get; set; }
        ///
        public String? OutputParameters { get; set; }
        ///
        public String? ServiceId { get; set; }
    }
}