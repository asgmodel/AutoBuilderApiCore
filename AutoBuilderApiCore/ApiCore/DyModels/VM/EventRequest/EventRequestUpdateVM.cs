using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// EventRequest  property for VM Update.
    /// </summary>
    public class EventRequestUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public EventRequestCreateVM? Body { get; set; }
    }
}