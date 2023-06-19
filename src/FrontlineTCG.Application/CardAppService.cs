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
    public class CardAppService : CrudAppService<Card, CardDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateCardDTO>
    {
        public CardAppService(IRepository<Card, Guid> repository) : base(repository)
        {
        }

       public async Task<List<CardDTO>> GetListAsync() 
        {
            List<Card> result = await Repository.GetListAsync() ;
            List<CardDTO> res2=ObjectMapper.Map<List<Card>,List<CardDTO>>(result) ;
            return res2;
        }

    }
}
