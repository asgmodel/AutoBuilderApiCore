using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using Dto.Build.Responses;
using System;

namespace Dto.Share.Responses
{
    public class SpaceResponseShareDto : SpaceResponseBuildDto, ITShareDto
    {
    }
}