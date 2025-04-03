using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// ModelAi  property for VM Create.
    /// </summary>
    public class ModelAiCreateVM : ITVM
    {
        //
        public ITranslationData? Name { get; set; }
        ///
        public String? Token { get; set; }
        ///
        public String? AbsolutePath { get; set; }
        //
        public ITranslationData? Category { get; set; }
        //
        public ITranslationData? Language { get; set; }
        //
        public ITranslationData? IsStandard { get; set; }
        //
        public ITranslationData? Gender { get; set; }
        //
        public ITranslationData? Dialect { get; set; }
        ///
        public String? Type { get; set; }
        ///
        public String? ModelGatewayId { get; set; }
        //
        public ModelGatewayCreateVM? ModelGateway { get; set; }
        //
        public ICollection<ServiceCreateVM>? Services { get; set; }
        //
        public ICollection<UserModelAiCreateVM>? UserModelAis { get; set; }
    }
}