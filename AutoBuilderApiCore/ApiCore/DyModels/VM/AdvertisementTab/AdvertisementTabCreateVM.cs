using AutoGenerator;
using AutoGenerator.Models;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// AdvertisementTab  property for VM Create.
    /// </summary>
    public class AdvertisementTabCreateVM : ITVM
    {
        ///
        public String? AdvertisementId { get; set; }
        //
        public ITranslationData? Title { get; set; }
        //
        public ITranslationData? Description { get; set; }
        ///
        public String? ImageAlt { get; set; }
        //
        public AdvertisementCreateVM? Advertisement { get; set; }
    }
}