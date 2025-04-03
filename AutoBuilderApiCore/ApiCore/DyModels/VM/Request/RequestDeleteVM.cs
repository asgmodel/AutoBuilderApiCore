using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Request  property for VM Delete.
    /// </summary>
    public class RequestDeleteVM : ITVM
    {
        ///
        public string? Id { get; set; }
    }
}