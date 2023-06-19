using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace FrontlineTCG.Cards
{
    public class UnitCard : Entity<Guid>
    {
        public Guid Card { get; set; }
        public int HP { get; set; }
        public int DmgUnarmored { get; set; }
        public int DmgArmored { get; set; }
        public int DmgStructure { get; set; }
        public int DmgAir { get; set; }

        public int? Ability2 { get; set; }

        public UnitCard() { Id = Guid.NewGuid(); }
        public void setID(Guid gid) { Id = gid; }

    }
}
