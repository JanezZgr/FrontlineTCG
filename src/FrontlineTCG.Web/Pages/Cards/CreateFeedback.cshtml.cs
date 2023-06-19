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
using Volo.Abp.Users;

namespace FrontlineTCG.Web.Pages.Cards
{
    [Authorize]
    public class CreateFeedbackModel : PageModel
    {
        private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;

        public CreateFeedbackModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context,CurrentUser cr)
        {
            _context = context;
            currentUser = cr;
        }

        [BindProperty]
        public CardFeedback CardFeedback { get; set; } = default!;
        public readonly ICurrentUser currentUser;
        public static Guid pID,cID;
        public static bool obstaja;
       

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.CardFeedbacks == null)
            {
                return NotFound();
            }
            obstaja = true;
         CardFeedback cf= await _context.CardFeedbacks.FirstOrDefaultAsync(e=>e.UserPosted== (Guid)currentUser.Id &&e.Card== (Guid)id);
            if (cf==null)
            {
                obstaja = false;
                cf= new CardFeedback();
                cf.Card = (Guid)id;
                cf.UserPosted = (Guid)currentUser.Id;
            }
            CardFeedback = cf;
            cID = cf.Card;
            pID = CardFeedback.Id;
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
            CardFeedback.TimePosted = DateTime.Now;
           
            CardFeedback.UserPosted= (Guid)currentUser.Id;
            CardFeedback.Card = cID;
            CardFeedback.setID(pID);
            if (obstaja)
                _context.Attach(CardFeedback).State = EntityState.Modified;
            else
                _context.CardFeedbacks.Add(CardFeedback);
            
            try
            {
                await _context.SaveChangesAsync();
            
                 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardFeedbackExists(CardFeedback.Id))
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

        private bool CardFeedbackExists(Guid id)
        {
          return (_context.CardFeedbacks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
