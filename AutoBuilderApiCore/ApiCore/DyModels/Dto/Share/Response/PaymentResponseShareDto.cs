using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using ApiCore.DyModels.Dto.Build.Responses;
using System;

namespace ApiCore.DyModels.Dto.Share.Responses
{
    public class PaymentResponseShareDto : PaymentResponseBuildDto, ITShareDto
    {
    }
}