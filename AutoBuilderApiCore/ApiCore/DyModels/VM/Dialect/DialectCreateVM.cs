using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Dialect  property for VM Create.
    /// </summary>
    public class DialectCreateVM : ITVM
    {
        //
        public ITranslationData? Name { get; set; }
        //
        public ITranslationData? Description { get; set; }
        ///
        public String? LanguageId { get; set; }
        //
        public LanguageCreateVM? Language { get; set; }
    }
}