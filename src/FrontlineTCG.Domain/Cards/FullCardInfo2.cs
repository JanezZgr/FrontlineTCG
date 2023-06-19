using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontlineTCG.Cards
{
    public class FullCardInfo
    {
        public CardType CardType { get; set; }
        public string CardName { get; set; }
        public int CostMaterial { get; set; }
        public int CostManpower { get; set; }
        public string Ability1Name { get; set; }
        public int Ability1ID { get; set; }
        public byte[] icon;

        public int? HP { get; set; }
        public int? DmgUnarmored { get; set; }
        public int? DmgArmored { get; set; }
        public int? DmgStructure { get; set; }
        public int? DmgAir { get; set; }

        public string? Ability2Name { get; set; }
        public int? Ability2ID { get; set; }

        public FullCardInfo()
        { }
        public FullCardInfo(Card card, UnitCard unitCard, CardAbility abil1, CardAbility abil2)
        {
            CardType = card.CardType;
            CardName = card.CardName;
            CostManpower = card.CostManpower;
            CostMaterial = card.CostMaterial;
            icon = card.Icon;


            Ability1ID = abil1.Id;
            Ability1Name = abil1.AbilityName;

            HP = unitCard.HP;
            DmgAir = unitCard.DmgAir;
            DmgArmored = unitCard.DmgArmored;
            DmgStructure = unitCard.DmgStructure;
            DmgUnarmored = unitCard.DmgUnarmored;

            Ability2ID = abil2.Id;
            Ability2Name = abil2.AbilityName;
        }
    }
}
