using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Request  property for VM Update.
    /// </summary>
    public class RequestUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public RequestCreateVM? Body { get; set; }
    }
}