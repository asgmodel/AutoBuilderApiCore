using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Advertisement  property for VM Update.
    /// </summary>
    public class AdvertisementUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public AdvertisementCreateVM? Body { get; set; }
    }
}