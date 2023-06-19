using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace FrontlineTCG.Cards
{
    public class Card : Entity<Guid>
    {
        public CardType CardType { get; set; }
        public string CardName { get; set; }
        public int CostMaterial { get; set; }
        public int CostManpower { get; set; }
        public int? Ability1 { get; set; }
        public byte[]? Icon { get; set; }

        public void setID(Guid gid) { Id = gid; }
    }
}
