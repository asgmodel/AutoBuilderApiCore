using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Payment  property for VM Create.
    /// </summary>
    public class PaymentCreateVM : ITVM
    {
        ///
        public String? CustomerId { get; set; }
        ///
        public String? InvoiceId { get; set; }
        ///
        public String? Status { get; set; }
        ///
        public String? Amount { get; set; }
        ///
        public String? Currency { get; set; }
        ///
        public DateOnly Date { get; set; }
    }
}