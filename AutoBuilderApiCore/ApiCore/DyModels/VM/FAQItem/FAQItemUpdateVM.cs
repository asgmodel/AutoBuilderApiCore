using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// FAQItem  property for VM Update.
    /// </summary>
    public class FAQItemUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public FAQItemCreateVM? Body { get; set; }
    }
}