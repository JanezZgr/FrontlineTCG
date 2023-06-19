using Volo.Abp.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontlineTCG.Cards
{
    public class CardAbility : Entity<int>
    {
        public string AbilityName { get; set; }//ime
        public string AbilityDescription { get; set; }//opis
        public byte ActivationCount { get; set; }//število aktivacij na potezo
        public byte ActivationRange { get; set; }//doseg aktivacije

    }
}
