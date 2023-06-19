using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FrontlineTCG.Cards
{
    public class UnitCardDTO:EntityDto<Guid>
    {
        public Guid Card { get; set; }
        //  public Guid cardID { get; set; }
        public int HP { get; set; }
        public int DmgUnarmored { get; set; }
        public int DmgArmored { get; set; }
        public int DmgStructure { get; set; }
        public int DmgAir { get; set; }

        public int? Ability2 { get; set; }
    }
}
