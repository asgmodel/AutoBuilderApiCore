using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace Dto.Build.Requests
{
    public class ServiceRequestBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String Id { get; set; }
        /// <summary>
        /// Name property for DTO.
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// AbsolutePath property for DTO.
        /// </summary>
        public String AbsolutePath { get; set; }
        /// <summary>
        /// Token property for DTO.
        /// </summary>
        public String Token { get; set; }
        /// <summary>
        /// ModelAiId property for DTO.
        /// </summary>
        public String ModelAiId { get; set; }
        public ModelAiRequestBuildDto? ModelAi { get; set; }
        /// <summary>
        /// ServiceMethods property for DTO.
        /// </summary>
        public ICollection<ServiceMethod> ServiceMethods { get; set; }
        /// <summary>
        /// UserServices property for DTO.
        /// </summary>
        public ICollection<UserService> UserServices { get; set; }
        /// <summary>
        /// Requests property for DTO.
        /// </summary>
        public ICollection<Request> Requests { get; set; }
    }
}