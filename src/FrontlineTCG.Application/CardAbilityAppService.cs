using FrontlineTCG.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FrontlineTCG
{
    public class CardAbilityAppService : CrudAppService<CardAbility, CardAbilityDTO, int, PagedAndSortedResultRequestDto, CreateUpdateAbilityDTO>
    {
        public CardAbilityAppService(IRepository<CardAbility, int> repository) : base(repository)
        {
        }

        public async Task<List<CardAbilityDTO>> GetListAsync()
        {
            List<CardAbility> result = await Repository.GetListAsync();
            List<CardAbilityDTO> res2 = ObjectMapper.Map<List<CardAbility>, List<CardAbilityDTO>>(result);
            return res2;
        }
    }
}
