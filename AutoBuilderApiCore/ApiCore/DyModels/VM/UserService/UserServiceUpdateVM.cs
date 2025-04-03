using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// UserService  property for VM Update.
    /// </summary>
    public class UserServiceUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public UserServiceCreateVM? Body { get; set; }
    }
}