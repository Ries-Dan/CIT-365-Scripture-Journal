using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;
using ScriptureJournal.Models;
using PagedList;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        public string ScriptureBook { get; set; }
        public SelectList Keyword { get; set; }
        public string ScriptureKeyword { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task OnGetAsync(string keyword, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> bookQuery = from m in _context.Scripture
                                            orderby m.Book
                                            select m.Book;

            IQueryable<string> noteQuery = from m in _context.Scripture
                                           orderby m.Note
                                           select m.Note;

            var scriptures = from m in _context.Scripture
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(keyword))
            {
                scriptures = scriptures.Where(x => x.Book == keyword);
            }
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
            SearchString = searchString;
        }
    }
}
