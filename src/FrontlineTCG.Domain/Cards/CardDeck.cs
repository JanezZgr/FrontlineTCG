using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace FrontlineTCG.Cards
{
    public class CardDeck : Entity<Guid>
    {
        public Guid UserID { get; set; }
        public ICollection<Card> CardList { get; set; }
    }
}
