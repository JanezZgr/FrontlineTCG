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
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace FrontlineTCG.Web.Pages.Cards
{
    [Authorize("Modify_Cards")]
    public class Edit2Model : PageModel
    {
        private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;

        public Edit2Model(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context)
        {
            _context = context;
        }
        public static Guid gGUID;
        public static byte[] iconholder;
        [BindProperty]
        
        public Card Card { get; set; } = default!;

        [BindProperty]
        public IList<CardAbility> Abilities { get; set; }

        public class BufferedSingleFileUploadDb
        {
            
            [Display(Name = "File")]
            public IFormFile? FormFile { get; set; }
        }
        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var card =  await _context.Cards.FirstOrDefaultAsync(m => m.Id == id);
            
            if (card == null)
            {
                return NotFound();
            }
            Card = card;
            gGUID = card.Id;
            Abilities=_context.CardAbilities.ToList();
            FileUpload = new BufferedSingleFileUploadDb();
            iconholder = card.Icon;
           
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Card.Icon = iconholder;
            Card.setID(gGUID);
            _context.Attach(Card).State = EntityState.Modified;

            if (FileUpload.FormFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await FileUpload.FormFile.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {
                        byte[] bArr = memoryStream.ToArray();
                        Card.Icon = bArr;
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                }
            }
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(Card.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            if (Card.CardType != CardType.Ability && Card.CardType != CardType.Sabotage)
            {
                UnitCard car = _context.UnitCards.FirstOrDefault(f => f.Card == Card.Id);
                if (car != null)
                {
                    return RedirectToPage("EditUC", new {id=car.Id});
                }
                else
                {
                    UnitCard uc = new UnitCard();
                    uc.Card = Card.Id;
                    _context.UnitCards.Add(uc);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("EditUC", new { id = car.Id });
                }
            }
            else
                return RedirectToPage("./Index");
        }

        private bool CardExists(Guid id)
        {
          return (_context.Cards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
