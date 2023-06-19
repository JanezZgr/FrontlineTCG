using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FrontlineTCG.Cards;
using FrontlineTCG.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FrontlineTCG.Web.Pages.Cards
{
    [Authorize("Modify_Cards")]
    public class DeleteModel : PageModel
    {
        private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;

        public DeleteModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Card Card { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FirstOrDefaultAsync(m => m.Id == id);

            if (card == null)
            {
                return NotFound();
            }
            else 
            {
                Card = card;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }
            var card = await _context.Cards.FindAsync(id);

            if (card != null)
            {
                Card = card;
                _context.Cards.Remove(Card);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
