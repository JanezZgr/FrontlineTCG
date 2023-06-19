using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrontlineTCG.Cards
{
    public class CreateUpdateAbilityDTO
    {
        [Required]
        public string AbilityName { get; set; }
        [Required]
        public string AbilityDescription { get; set; }
        [Required]
        public byte ActivationCount { get; set; }
        [Required]
        public int ActivationRange { get; set; }

        public CreateUpdateAbilityDTO() { }
        public CreateUpdateAbilityDTO(CardAbilityDTO dto) 
        {
            AbilityName = dto.AbilityName;
        AbilityDescription = dto.AbilityDescription;
            ActivationCount = dto.ActivationCount;
            ActivationRange = dto.ActivationRange;

        }
    }
}
