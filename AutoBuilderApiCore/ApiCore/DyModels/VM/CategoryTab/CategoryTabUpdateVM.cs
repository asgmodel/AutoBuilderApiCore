using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// CategoryTab  property for VM Update.
    /// </summary>
    public class CategoryTabUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public CategoryTabCreateVM? Body { get; set; }
    }
}