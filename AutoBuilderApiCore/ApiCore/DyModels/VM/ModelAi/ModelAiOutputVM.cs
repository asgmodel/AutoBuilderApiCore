using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// ModelAi  property for VM Output.
    /// </summary>
    public class ModelAiOutputVM : ITVM
    {
        ///
        public String? Id { get; set; }
        //
        public string? Name { get; set; }
        ///
        public String? Token { get; set; }
        ///
        public String? AbsolutePath { get; set; }
        //
        public string? Category { get; set; }
        //
        public string? Language { get; set; }
        //
        public string? IsStandard { get; set; }
        //
        public string? Gender { get; set; }
        //
        public string? Dialect { get; set; }
        ///
        public String? Type { get; set; }
        ///
        public String? ModelGatewayId { get; set; }
        //
        public ICollection<ServiceOutputVM>? Services { get; set; }
        //
        public ICollection<UserModelAiOutputVM>? UserModelAis { get; set; }
    }
}