using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Responses
{
    public class SettingResponseBuildDto : ITBuildDto
    {
        /// <summary>
        /// Name property for DTO.
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Value property for DTO.
        /// </summary>
        public String Value { get; set; }
    }
}