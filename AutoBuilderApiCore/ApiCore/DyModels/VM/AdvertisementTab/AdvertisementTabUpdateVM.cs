using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// AdvertisementTab  property for VM Update.
    /// </summary>
    public class AdvertisementTabUpdateVM : ITVM
    {
        ///
        public string? Id { get; set; }
        ///
        public AdvertisementTabCreateVM? Body { get; set; }
    }
}