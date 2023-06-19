using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FrontlineTCG.Cards;
using FrontlineTCG.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FrontlineTCG.Web.Pages.CardAbilities
{
    [Authorize("Modify_Abilities")]
    public class CreateModel : PageModel
    {

        private readonly CardAbilityAppService appService;
        public CreateModel(CardAbilityAppService cardAbilityAppService)
        {
            appService = cardAbilityAppService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CardAbilityDTO CardAbility { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || appService == null || CardAbility == null)
            {
                return Page();
            }
            await appService.CreateAsync(new CreateUpdateAbilityDTO(CardAbility));
            //  _context.CardAbilities.Add(CardAbility);
            //  await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        /*   private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;


            public CreateModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context)
            {
                _context = context;
            }

            public IActionResult OnGet()
            {
                return Page();
            }

            [BindProperty]
            public CardAbility CardAbility { get; set; } = default!;


            // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
            public async Task<IActionResult> OnPostAsync()
            {
              if (!ModelState.IsValid || _context.CardAbilities == null || CardAbility == null)
                {
                    return Page();
                }

                _context.CardAbilities.Add(CardAbility);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }*/
    }
}
