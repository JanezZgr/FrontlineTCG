using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FrontlineTCG.Cards;
using FrontlineTCG.EntityFrameworkCore;
using Polly;
using Volo.Abp.Application.Dtos;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace FrontlineTCG.Web.Pages.Cards
{
    public class IndexModel : PageModel
    {
        public class FileUpload
        {
            [Required]
            [Display(Name = "File")]
            public IFormFile FormFile { get; set; }
        }

        private  CardAbilityAppService cardAbilityAppService;
        public CardAppService cardAppService;
        private IAuthorizationService authorizationService;




        public IndexModel(CardAbilityAppService cardAbilityAppService, CardAppService cardAppService,IAuthorizationService asrv)
        {
            this.cardAbilityAppService = cardAbilityAppService;
            this.cardAppService = cardAppService;
            authorizationService = asrv;
        }
        public IList<CardDTO> Card { get; set; } = default!;
        public IList<FullCardInfo> FullCards { get; set; }
        public bool logdIn;

        public async Task OnGetAsync()
        {
            if (cardAppService != null)
            { logdIn = false;

                Card = await cardAppService.GetListAsync();
                  UnitCardDTO[] uDTO = new UnitCardDTO[Card.Count];
                List<UnitCardDTO> uList = new List<UnitCardDTO>();

                for (int i = 0; i < Card.Count; i++)//dodajanje unitcard
                {
                    uDTO[i] = uList.FirstOrDefault(b => b.Card == Card[i].Id,null);
                }


                var aut = await authorizationService.AuthorizeAsync("Modify_Cards");
                if (aut.Succeeded)
                { logdIn=true; }


            }
        }

            /* private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;

             public IndexModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context)
             {
                 _context = context;
             }

             public IList<Card> Card { get;set; } = default!;

             public async Task OnGetAsync()
             {
                 if (_context.Cards != null)
                 {
                     Card = await _context.Cards.ToListAsync();
                 }
                }*/
        }
}
