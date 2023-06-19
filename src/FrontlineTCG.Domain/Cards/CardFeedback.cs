using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace FrontlineTCG.Cards
{
    public class CardFeedback:Entity<Guid>
    {
        public Guid UserPosted { get; set; }
        public Guid Card { get; set; }
        public DateTime TimePosted { get; set; }
        [Range(0,5)]
        public byte BalanceScore { get; set; }
        public string Text { get; set; }
        public CardFeedback() { Id = Guid.NewGuid(); }
        public void setID(Guid id) { Id = id;}
    }
}
