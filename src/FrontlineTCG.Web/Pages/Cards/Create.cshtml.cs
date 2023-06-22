using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FrontlineTCG.Cards;
using FrontlineTCG.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace FrontlineTCG.Web.Pages.Cards
{
    [Authorize("Modify_Cards")]
    public class CreateModel : PageModel
    {
        public class BufferedSingleFileUploadDb
        {
            [Required]
            [Display(Name = "File")]
            public IFormFile FormFile { get; set; }
        }

        private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;
       

        public CreateModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {Abilities=_context.CardAbilities.ToList();
            return Page();
        }
        private  readonly string[] permittedExtensions = { ".png", ".jpg" };

        [BindProperty]
        public Card Card { get; set; } = default!;
        public IList<CardAbility> Abilities { get; set; }

        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Cards == null || Card == null)
            {
                return Page();
            }

            using (var memoryStream = new MemoryStream())
            {
                if (FileUpload.FormFile.ContentType.Contains("image"))
                {
                    await FileUpload.FormFile.CopyToAsync(memoryStream);
                    if (memoryStream.Length < 2097152)
                    {


                        byte[] bArr = memoryStream.ToArray();
                        Card.Icon = bArr;
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large."); return Page();
                    }
                }
            }
            Card.setID(Guid.NewGuid());
            _context.Cards.Add(Card);
            await _context.SaveChangesAsync();

            if (Card.CardType != CardType.Ability && Card.CardType != CardType.Sabotage)
            {
                UnitCard car = _context.UnitCards.FirstOrDefault(f => f.Card == Card.Id);
                if (car != null)
                {
                    return RedirectToPage("EditUC", new { id = car.Id });
                }
                else
                {
                    UnitCard uc = new UnitCard();
                    uc.Card = Card.Id;
                    _context.UnitCards.Add(uc);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("EditUC", new { id = uc.Id });
                }
            }
            else
                return RedirectToPage("./Index");

        }
    }
}
