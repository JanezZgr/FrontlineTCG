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
using Microsoft.AspNetCore.Authorization;

namespace FrontlineTCG.Web.Pages.Cards
{
    [Authorize("Modify_Cards")]
    public class EditUCModel : PageModel
    {
        private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;

        public EditUCModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UnitCard UnitCard { get; set; } = default!;
        public static Guid gID;
        public static Guid cID;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.UnitCards == null)
            {
                return NotFound();
            }

            var unitcard =  await _context.UnitCards.FirstOrDefaultAsync(m => m.Id == id);
            if (unitcard == null)//{04d8abb2-a0db-4899-9bf9-9628459ed74b} {7a9217b5-59ca-443f-adc1-19f36da1ff2c}
            {
                return NotFound();
            }
            UnitCard = unitcard;
            gID = unitcard.Id;
            cID = unitcard.Card;
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
            UnitCard.setID(gID);
            UnitCard.Card = cID;
            _context.Attach(UnitCard).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitCardExists(UnitCard.Id))
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

        private bool UnitCardExists(Guid id)
        {
          return (_context.UnitCards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
