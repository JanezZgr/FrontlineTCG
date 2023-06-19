using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FrontlineTCG.Cards
{
    public class CardAbilityDTO:EntityDto<int>
    {
        public string AbilityName { get; set; }
        public string AbilityDescription { get; set; }
        public byte ActivationCount { get; set; }
        public int ActivationRange { get; set; }

    }
}
