using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Service  property for VM Output.
    /// </summary>
    public class ServiceOutputVM : ITVM
    {
        ///
        public String? Id { get; set; }
        ///
        public String? Name { get; set; }
        ///
        public String? AbsolutePath { get; set; }
        ///
        public String? Token { get; set; }
        ///
        public String? ModelAiId { get; set; }
        //
        public ICollection<ServiceMethodOutputVM>? ServiceMethods { get; set; }
        //
        public ICollection<UserServiceOutputVM>? UserServices { get; set; }
        //
        public ICollection<RequestOutputVM>? Requests { get; set; }
    }
}