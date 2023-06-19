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
    public class IndexModel : PageModel
    {
      
        
        private readonly FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext _context;
        private IAuthorizationService authorizationService;
        public bool logdIn;

        public IndexModel(FrontlineTCG.EntityFrameworkCore.FrontlineTCGDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            this.authorizationService = authorizationService;
            
        }

        public IList<CardAbility> CardAbility { get;set; } = default!;

        public async Task OnGetAsync()
        {
            logdIn = false;
            if (_context.CardAbilities != null)
            {
                CardAbility = await _context.CardAbilities.ToListAsync();
                var aut = await authorizationService.AuthorizeAsync("Modify_Cards");
                if (aut.Succeeded)
                { logdIn = true; }
            }
        }
    }
}
