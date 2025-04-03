using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Invoice  property for VM Create.
    /// </summary>
    public class InvoiceCreateVM : ITVM
    {
        ///
        public String? CustomerId { get; set; }
        ///
        public String? Status { get; set; }
        ///
        public String? Url { get; set; }
        ///
        public Nullable<DateTime> InvoiceDate { get; set; }
    }
}