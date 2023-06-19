using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FrontlineTCG.Cards;
using FrontlineTCG.EntityFrameworkCore;
using System.Text;
using Volo.Abp.UI.Navigation;
using static Volo.Abp.UI.Navigation.DefaultMenuNames.Application;
using Azure.Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;

namespace FrontlineTCG.Web.Pages.Cards
{
    
    public class DetailsModel : PageModel
    {
        private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;
        private IAuthorizationService authorizationService;

        public DetailsModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            this.authorizationService = authorizationService;
        }

        public Card Card { get; set; } = default!;
        public FullCardInfo FullCardInfo { get; set; }
        public CardFeedback[] CardFeedback { get; set; }
        public bool logdIn;

       
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {logdIn = false;
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FirstOrDefaultAsync(m => m.Id == id);

            var aut = await authorizationService.AuthorizeAsync("Modify_Cards");
            if (aut.Succeeded)
            { logdIn = true; }

            UnitCard uc;
            CardAbility ca1, ca2;
            if (card == null)
            {
                return NotFound();
            }
            else
            {
                Card = card;

                uc = await _context.UnitCards.FirstOrDefaultAsync(f => f.Card == Card.Id);
                if (uc == null) { uc = new UnitCard(); }

                ca1 = await _context.CardAbilities.FirstOrDefaultAsync(a => a.Id == card.Ability1);
                if (ca1 == null) { ca1 = _context.CardAbilities.First(); }//prvi je none

                ca2 = await _context.CardAbilities.FirstOrDefaultAsync(a => a.Id == uc.Ability2);
                if (ca2 == null) { ca2 = _context.CardAbilities.First(); }//prvi je none

                FullCardInfo = new FullCardInfo(card, uc, ca1, ca2);
            
                try 
                {

                    CardFeedback[] cfb= await getFB();
                    CardFeedback = cfb;
                }
                catch (Exception ex) { CardFeedback = null; }

            }
            return Page();
        }
      
        private async Task<CardFeedback[]> getFB()
        {
            var cf = await _context.CardFeedbacks.ToArrayAsync(); 
            List<CardFeedback> fbs = new List<CardFeedback>();
            for (int i = 0; i < cf.Length; i++)
            {
                if (cf[i].Card==Card.Id)
                    fbs.Add(cf[i]);

            }

            return fbs.ToArray();
        }
       
    }
}
