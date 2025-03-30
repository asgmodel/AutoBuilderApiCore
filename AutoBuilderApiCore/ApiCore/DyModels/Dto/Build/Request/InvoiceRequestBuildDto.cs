using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Requests
{
    public class InvoiceRequestBuildDto : ITBuildDto
    {
        public ITranslationData? Id { get; set; }
        /// <summary>
        /// Itd property for DTO.
        /// </summary>
        public Int32 Itd { get; set; }
        /// <summary>
        /// CustomerId property for DTO.
        /// </summary>
        public String CustomerId { get; set; }
        /// <summary>
        /// Status property for DTO.
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// Url property for DTO.
        /// </summary>
        public String Url { get; set; }
        /// <summary>
        /// InvoiceDate property for DTO.
        /// </summary>
        public Nullable<DateTime> InvoiceDate { get; set; }
        /// <summary>
        /// Description property for DTO.
        /// </summary>
        public String Description { get; set; }
    }
}