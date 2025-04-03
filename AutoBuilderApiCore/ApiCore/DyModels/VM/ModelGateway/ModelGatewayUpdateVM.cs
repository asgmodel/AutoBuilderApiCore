using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// ModelGateway  property for VM Update.
    /// </summary>
    public class ModelGatewayUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public ModelGatewayCreateVM? Body { get; set; }
    }
}