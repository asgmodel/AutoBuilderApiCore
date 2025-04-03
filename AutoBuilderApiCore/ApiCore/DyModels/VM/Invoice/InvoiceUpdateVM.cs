using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Invoice  property for VM Update.
    /// </summary>
    public class InvoiceUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public InvoiceCreateVM? Body { get; set; }
    }
}