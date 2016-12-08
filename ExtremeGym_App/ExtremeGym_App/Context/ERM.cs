using ExtremeGym_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExtremeGym_App.Context
{
    public class ERMDBContext: DbContext
    {
        public ERMDBContext()
            : base("MembersDBContext")
        {
        }

        public DbSet<Members> Members { get; set; }

        public DbSet<Purchases> Purchases { get; set; }
    }
}
