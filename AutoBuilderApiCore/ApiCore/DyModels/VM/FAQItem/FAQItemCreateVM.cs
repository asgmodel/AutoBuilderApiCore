using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// FAQItem  property for VM Create.
    /// </summary>
    public class FAQItemCreateVM : ITVM
    {
        //
        public ITranslationData? Question { get; set; }
        //
        public ITranslationData? Answer { get; set; }
        //
        public ITranslationData? Tag { get; set; }
    }
}