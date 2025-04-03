using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Language  property for VM Create.
    /// </summary>
    public class LanguageCreateVM : ITVM
    {
        ///
        public String? Name { get; set; }
        ///
        public String? Code { get; set; }
    }
}