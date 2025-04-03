using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// EventRequest  property for VM Create.
    /// </summary>
    public class EventRequestCreateVM : ITVM
    {
        ///
        public String? Status { get; set; }
        ///
        public String? Details { get; set; }
        ///
        public DateTime CreatedAt { get; set; }
        ///
        public String? RequestId { get; set; }
    }
}