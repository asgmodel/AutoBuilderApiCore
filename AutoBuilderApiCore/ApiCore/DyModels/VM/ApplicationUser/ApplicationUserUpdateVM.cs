using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// ApplicationUser  property for VM Update.
    /// </summary>
    public class ApplicationUserUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public ApplicationUserCreateVM? Body { get; set; }
    }
}