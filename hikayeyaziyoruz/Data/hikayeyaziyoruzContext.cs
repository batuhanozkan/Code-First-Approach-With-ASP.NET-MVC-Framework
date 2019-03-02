using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hikayeyaziyoruz.Data
{
    public class hikayeyaziyoruzContext : DbContext
    {
        public DbSet<anametin> anametins { get; set; }
        public DbSet<metin> metins { get; set; }
        public DbSet<Uye> Uyes { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
    }
}