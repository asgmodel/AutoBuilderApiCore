using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// AuthorizationSession  property for VM Update.
    /// </summary>
    public class AuthorizationSessionUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public AuthorizationSessionCreateVM? Body { get; set; }
    }
}