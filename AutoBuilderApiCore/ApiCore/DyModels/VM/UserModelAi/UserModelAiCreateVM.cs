using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// UserModelAi  property for VM Create.
    /// </summary>
    public class UserModelAiCreateVM : ITVM
    {
        ///
        public DateTime CreatedAt { get; set; }
        ///
        public String? UserId { get; set; }
        ///
        public String? ModelAiId { get; set; }
    }
}