using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// TypeModel  property for VM Create.
    /// </summary>
    public class TypeModelCreateVM : ITVM
    {
        //
        public ITranslationData? Name { get; set; }
        //
        public ITranslationData? Description { get; set; }
        ///
        public Boolean Active { get; set; }
        ///
        public String? Image { get; set; }
    }
}