using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Cards
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Card> Card { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString {get; set; }

        public SelectList? ExpansionSet {get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Sets {get; set; }

        public async Task OnGetAsync()
        {

            IQueryable<string> setQuery = from s in _context.Card
                                          orderby s.ExpansionSet
                                          select s.ExpansionSet;

            var cards = from s in _context.Card
                        select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                cards = cards.Where(m => m.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(Sets))
            {
                cards = cards.Where(x => x.ExpansionSet == x.Sets);
            }
            ExpansionSet = new SelectList(await setQuery.Distinct().ToListAsync());
            Card = await cards.ToListAsync();
        }
    }
}
