using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;

namespace MyScriptureJournal.Models
{
    public class MyScriptureJournalContext : DbContext
    {
        public MyScriptureJournalContext (DbContextOptions<MyScriptureJournalContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptureJournal.Models.Scripture> Scripture { get; set; }
    }
}
