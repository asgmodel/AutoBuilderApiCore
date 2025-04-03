using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// ModelAi  property for VM Create.
    /// </summary>
    public class ModelAiCreateVM : ITVM
    {
        //
        public TranslationData? Name { get; set; }
        ///
        public String? Token { get; set; }
        ///
        public String? AbsolutePath { get; set; }
        //
        public TranslationData? Category { get; set; }
        //
        public TranslationData? Language { get; set; }
        //
        public TranslationData? IsStandard { get; set; }
        //
        public TranslationData? Gender { get; set; }
        //
        public TranslationData? Dialect { get; set; }
        ///
        public String? Type { get; set; }
        ///
        public String? ModelGatewayId { get; set; }
        //
        public ICollection<ServiceCreateVM>? Services { get; set; }
        //
        public ICollection<UserModelAiCreateVM>? UserModelAis { get; set; }
    }
}