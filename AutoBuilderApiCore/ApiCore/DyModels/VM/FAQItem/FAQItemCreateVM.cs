using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// FAQItem  property for VM Create.
    /// </summary>
    public class FAQItemCreateVM : ITVM
    {
        //
        public TranslationData? Question { get; set; }
        //
        public TranslationData? Answer { get; set; }
        //
        public TranslationData? Tag { get; set; }
    }
}