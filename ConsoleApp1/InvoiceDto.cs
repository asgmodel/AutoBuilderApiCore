using Microsoft.CodeAnalysis;
using AutoGenerator;
using System;

namespace MyDtos
{
    public class InvoiceDto : BaseDto, ITDto
    {
        public String Id { get; set; }
        //
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

        public void PrintDetails()
        {
            Console.WriteLine($"Id: {Id}, CustomerId: {CustomerId}, Status: {Status}");
        }
    }
}