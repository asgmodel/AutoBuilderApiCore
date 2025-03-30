using Microsoft.CodeAnalysis;
using AutoGenerator;
using Dto.Share.Requests;
using System;

namespace Dso.Requests
{
    public class InvoiceRequestDso : InvoiceRequestShareDto, ITDso
    {
    }
}