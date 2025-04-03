using AutoGenerator;
using AutoGenerator.Models;
using AutoGenerator.Helper.Translation;
using System;

namespace ApiCore.DyModels.VMs
{
    /// <summary>
    /// Advertisement  property for VM Create.
    /// </summary>
    public class AdvertisementCreateVM : ITVM
    {
        //
        public TranslationData? Title { get; set; }
        //
        public TranslationData? Description { get; set; }
        ///
        public String? Image { get; set; }
        ///
        public Boolean Active { get; set; }
        ///
        public String? Url { get; set; }
        //
        public ICollection<AdvertisementTabCreateVM>? AdvertisementTabs { get; set; }
    }
}