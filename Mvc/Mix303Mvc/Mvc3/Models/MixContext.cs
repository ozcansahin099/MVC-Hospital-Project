using Mvc3.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc3.Models
{
    public class MixContext:DbContext
    {
        public MixContext():base("DefCon")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MixContext, Configuration>("DefCon"));
        }
        public DbSet<Ogrenciler> ogrencilers { get; set; }
        public DbSet<Egitmenler> egitmenlers { get; set; }
        public DbSet<Brans> brans { get; set; }
    }
}