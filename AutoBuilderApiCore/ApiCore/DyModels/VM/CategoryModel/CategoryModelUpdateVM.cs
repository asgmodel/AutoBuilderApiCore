using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// CategoryModel  property for VM Update.
    /// </summary>
    public class CategoryModelUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public CategoryModelCreateVM? Body { get; set; }
    }
}