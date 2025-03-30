using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using Dto.Build.Requests;
using System;

namespace Dto.Share.Requests
{
    public class AuthorizationSessionRequestShareDto : AuthorizationSessionRequestBuildDto, ITShareDto
    {
    }
}