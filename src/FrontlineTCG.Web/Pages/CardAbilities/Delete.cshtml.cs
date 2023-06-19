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
using Microsoft.AspNetCore.Authorization;

namespace FrontlineTCG.Web.Pages.CardAbilities
{
    [Authorize("Modify_Abilities")]
    public class DeleteModel : PageModel
    {

        private readonly CardAbilityAppService appService;
        public DeleteModel(CardAbilityAppService cardAbilityAppService)
        {
            appService = cardAbilityAppService;
        }
        public async Task<IActionResult> OnGet( int? id)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || appService == null)
            {
                return NotFound();
            }
            var cardability = await appService.GetAsync((int)id);

            if (cardability != null)
            {
               await appService.DeleteAsync(cardability.Id);
            }

            return RedirectToPage("./Index");
        }

        /* private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;

         public DeleteModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context)
         {
             _context = context;
         }

         [BindProperty]
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
         }

         public async Task<IActionResult> OnPostAsync(int? id)
         {
             if (id == null || _context.CardAbilities == null)
             {
                 return NotFound();
             }
             var cardability = await _context.CardAbilities.FindAsync(id);

             if (cardability != null)
             {
                 CardAbility = cardability;
                 _context.CardAbilities.Remove(CardAbility);
                 await _context.SaveChangesAsync();
             }

             return RedirectToPage("./Index");
         }*/
    }
}
