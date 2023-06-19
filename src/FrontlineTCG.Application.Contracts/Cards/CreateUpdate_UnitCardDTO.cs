using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrontlineTCG.Cards
{
    public class CreateUpdate_UnitCardDTO
    {
        [Required]
        public Guid Card { get; set; }
        [Required]
        public int HP { get; set; }
        [Required]
        public int DmgUnarmored { get; set; }
        [Required]
        public int DmgArmored { get; set; }
        [Required]
        public int DmgStructure { get; set; }
        [Required]
        public int DmgAir { get; set; }
        [Required]
        public int? Ability2 { get; set; }
    }
}
