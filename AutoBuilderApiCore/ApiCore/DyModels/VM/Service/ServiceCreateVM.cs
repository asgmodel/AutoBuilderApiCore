using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Service  property for VM Create.
    /// </summary>
    public class ServiceCreateVM : ITVM
    {
        ///
        public String? Name { get; set; }
        ///
        public String? AbsolutePath { get; set; }
        ///
        public String? Token { get; set; }
        ///
        public String? ModelAiId { get; set; }
        //
        public ICollection<ServiceMethodCreateVM>? ServiceMethods { get; set; }
        //
        public ICollection<UserServiceCreateVM>? UserServices { get; set; }
        //
        public ICollection<RequestCreateVM>? Requests { get; set; }
    }
}