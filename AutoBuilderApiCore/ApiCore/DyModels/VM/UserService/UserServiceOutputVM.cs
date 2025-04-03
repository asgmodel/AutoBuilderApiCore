using AutoGenerator;
using AutoGenerator.Models;
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
        //
        public ApplicationUserOutputVM? User { get; set; }
        ///
        public String? ServiceId { get; set; }
        //
        public ServiceOutputVM? Service { get; set; }
    }
}