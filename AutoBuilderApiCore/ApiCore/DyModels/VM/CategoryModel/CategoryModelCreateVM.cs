using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// CategoryModel  property for VM Create.
    /// </summary>
    public class CategoryModelCreateVM : ITVM
    {
        //
        public ITranslationData? Name { get; set; }
        //
        public ITranslationData? Description { get; set; }
    }
}