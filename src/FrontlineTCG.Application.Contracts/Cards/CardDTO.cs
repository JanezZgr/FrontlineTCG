using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FrontlineTCG.Cards
{
    public class CardDTO:EntityDto<Guid>
    {
        public CardType CardType { get; set; }
        public string CardName { get; set; }
        public int CostMaterial { get; set; }
        public int CostManpower { get; set; }
        public int Ability1 { get; set; }//int
        public byte[]? Icon { get; set; }
    }
}
