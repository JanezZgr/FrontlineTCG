using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FrontlineTCG.Cards;
using FrontlineTCG.EntityFrameworkCore;

namespace FrontlineTCG.Web.Pages.CardAbilities
{
   public class DetailsModel : PageModel
    {
        private readonly CardAbilityAppService appService;
        public DetailsModel(CardAbilityAppService cardAbilityAppService)
        {
            appService = cardAbilityAppService;
        }
        public async Task<IActionResult> OnGet(int? id)
        {

            if (id == null || appService == null)
            {
                return NotFound();
            }

            var cardability = await appService.GetAsync((int)id);

            if (cardability == null)
            {
                return NotFound();
            }
            else
            {
                CardAbility = cardability;
            }
            return Page();
        }

        [BindProperty]
        public CardAbilityDTO CardAbility { get; set; } = default!;

        /*
        private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;

        public DetailsModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context)
        {
            _context = context;
        }

      public CardAbility CardAbility { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CardAbilities == null)
            {
                return NotFound();
            }

            var cardability = await _context.CardAbilities.FirstOrDefaultAsync(m => m.Id == id);
            if (cardability == null)
            {
                return NotFound();
            }
            else 
            {
                CardAbility = cardability;
            }
            return Page();
        }*/
    }
}
