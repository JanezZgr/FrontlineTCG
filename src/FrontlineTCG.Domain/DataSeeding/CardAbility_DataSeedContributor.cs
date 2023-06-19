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
    public class CardAbility_DataSeederContributor
     : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<CardAbility, int> _abilityRepository;

        public CardAbility_DataSeederContributor(IRepository<CardAbility, int> bookRepository)
        {
            _abilityRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _abilityRepository.GetCountAsync() <= 0)
            {
                await _abilityRepository.InsertAsync(
                    new CardAbility
                    {
                        AbilityName = "None",
                        AbilityDescription = "None",
                        ActivationCount = 0,
                        ActivationRange = 0,
                    },
                    autoSave: true
                );

                await _abilityRepository.InsertAsync(
                    new CardAbility
                    {
                        AbilityName = "Suppresive fire",
                        AbilityDescription = "Can disable unarmored enemies",
                        ActivationRange = 1,
                        ActivationCount = 1,
                    },
                    autoSave: true
                );
                await _abilityRepository.InsertAsync(
                    new CardAbility
                    {
                        AbilityName = "Scouting",
                        AbilityDescription = "Can reveal an adjacent enemy card",
                        ActivationRange = 1,
                        ActivationCount = 1,
                    },
                    autoSave: true
                );
                await _abilityRepository.InsertAsync(
                    new CardAbility
                    {
                        AbilityName = "Crack codes",
                        AbilityDescription = "Can reveal all enemy cards",
                        ActivationRange = 5,
                        ActivationCount = 100,
                    },
                    autoSave: true
                );

            }
        }
    }
}
