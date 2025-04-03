using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// AuthorizationSession  property for VM Output.
    /// </summary>
    public class AuthorizationSessionOutputVM : ITVM
    {
        ///
        public String? Id { get; set; }
        ///
        public String? SessionToken { get; set; }
        ///
        public String? UserToken { get; set; }
        ///
        public String? AuthorizationType { get; set; }
        ///
        public DateTime StartTime { get; set; }
        ///
        public Nullable<DateTime> EndTime { get; set; }
        ///
        public Boolean IsActive { get; set; }
        ///
        public String? UserId { get; set; }
        ///
        public String? IpAddress { get; set; }
        ///
        public String? DeviceInfo { get; set; }
        ///
        public String? ServicesIds { get; set; }
    }
}