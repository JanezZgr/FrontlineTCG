using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FrontlineTCG.Cards
{
   public class CreateUpdateCardDTO:EntityDto<Guid>
    {
        [Required]
        public CardType CardType { get; set; }
        [Required]
        public string CardName { get; set; }
        [Required]
        public int CostMaterial { get; set; }
        [Required]
        public int CostManpower { get; set; }
        [Required]
        public int Ability1 { get; set; }//int
        [Required]
        public byte[]? Icon { get; set; }

        public CreateUpdateCardDTO() { Id = Guid.NewGuid();CardName = ""; }
        public CreateUpdateCardDTO(Guid gd) { Id = gd;CardName = ""; }

        public CreateUpdateCardDTO(Guid gd,CardType cardType, string cardName, int costMaterial, int costManpower, int ability1, byte[]? icon)
        {   Id = gd;
            CardType = cardType;
            CardName = cardName;
            CostMaterial = costMaterial;
            CostManpower = costManpower;
            Ability1 = ability1;
            Icon = icon;
        }
    }
}
