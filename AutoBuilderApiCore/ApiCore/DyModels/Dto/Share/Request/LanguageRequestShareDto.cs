using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using ApiCore.DyModels.Dto.Build.Requests;
using System;

namespace ApiCore.DyModels.Dto.Share.Requests
{
    public class LanguageRequestShareDto : LanguageRequestBuildDto, ITShareDto
    {
    }
}