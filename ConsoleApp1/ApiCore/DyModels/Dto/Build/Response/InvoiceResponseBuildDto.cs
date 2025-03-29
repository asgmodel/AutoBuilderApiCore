using Microsoft.CodeAnalysis;
using AutoGenerator;
using System;

namespace Dto.Build.Response
{
    public class InvoiceResponseBuildDto : ITBuildDto
    {
        public Int32 Itd { get; set; }
        //
        public String CustomerId { get; set; }
        //
        public String Status { get; set; }
        //
        public String Url { get; set; }
        //
        public Nullable<DateTime> InvoiceDate { get; set; }
        //
        public String Description { get; set; }
        public ITranslationData? Id { get; set; }
    }
}