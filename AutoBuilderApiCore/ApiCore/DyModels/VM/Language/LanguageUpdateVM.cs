using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Language  property for VM Update.
    /// </summary>
    public class LanguageUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public LanguageCreateVM? Body { get; set; }
    }
}