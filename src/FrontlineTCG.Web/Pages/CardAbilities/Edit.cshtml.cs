using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrontlineTCG.Cards;
using FrontlineTCG.EntityFrameworkCore;
using Polly;
using Microsoft.AspNetCore.Authorization;

namespace FrontlineTCG.Web.Pages.CardAbilities
{
    [Authorize("Modify_Abilities")]
    public class EditModel : PageModel
    {

        private readonly CardAbilityAppService appService;
        public EditModel(CardAbilityAppService cardAbilityAppService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if ( appService == null)
            {
                return NotFound();
            }
            var cardability = await appService.GetAsync(CardAbility.Id);

            if (cardability != null)
            {
                await appService.UpdateAsync(CardAbility.Id, new CreateUpdateAbilityDTO(CardAbility));
            }

            return RedirectToPage("./Index");
        }

        /*
        private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;

        public EditModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context)
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

            var cardability =  await _context.CardAbilities.FirstOrDefaultAsync(m => m.Id == id);
            if (cardability == null)
            {
                return NotFound();
            }
            CardAbility = cardability;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CardAbility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardAbilityExists(CardAbility.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CardAbilityExists(int id)
        {
          return (_context.CardAbilities?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
