using FrontlineTCG.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FrontlineTCG
{
    public class UnitCardAppService : CrudAppService<UnitCard, UnitCardDTO, Guid, CreateUpdate_UnitCardDTO>
    {
        public UnitCardAppService(IRepository<UnitCard, Guid> repository) : base(repository)
        {
        }
        public async Task<List<UnitCardDTO>> GetListAsync()
        {
            List<UnitCard> result = await Repository.GetListAsync();
            List<UnitCardDTO> res2 = ObjectMapper.Map<List<UnitCard>, List<UnitCardDTO>>(result);
            return res2;
        }
    }
}
