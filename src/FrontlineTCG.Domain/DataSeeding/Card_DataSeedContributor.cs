using FrontlineTCG.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace FrontlineTCG.DataSeeding
{
    public class Card_DataSeedContributor //: IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Card, Guid> _cardRepository;

        public Card_DataSeedContributor(IRepository<Card, Guid> bookRepository)
        {
            _cardRepository = bookRepository;
        }

       /* public async Task SeedAsync(DataSeedContext context)
        {
            if (await _cardRepository.GetCountAsync() <= 0)
            {
                await _cardRepository.InsertAsync(
                       new Card
                       {
                           CardType=CardType.Unarmored,
                           CardName="MG squad",
                           CostManpower=2,
                           CostMaterial=3,
                           Ability1=0
                           
                           
                       },
                       autoSave: true
                   );
            }
            }*/

    }
}
