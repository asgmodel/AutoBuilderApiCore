using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// UserService  property for VM Output.
    /// </summary>
    public class UserServiceOutputVM : ITVM
    {
        ///
        public DateTime CreatedAt { get; set; }
        ///
        public String? UserId { get; set; }
        ///
        public String? ServiceId { get; set; }
    }
}