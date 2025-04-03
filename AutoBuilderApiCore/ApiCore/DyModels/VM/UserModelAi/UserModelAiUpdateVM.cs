using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// UserModelAi  property for VM Update.
    /// </summary>
    public class UserModelAiUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public UserModelAiCreateVM? Body { get; set; }
    }
}