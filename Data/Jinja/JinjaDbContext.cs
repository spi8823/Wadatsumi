using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Wadatsumi.Jinja.Data
{
    public class JinjaDbContext : DbContext
    {
        public DbSet<Jinja> JinjaDbSet { get; set; }
        public DbSet<Saijin> SaijinDbSet { get; set; }
        public DbSet<Goshuin> GoshuinDbSet { get; set; }

        public DbSet<Kami> KamiDbSet { get; set; }
        public DbSet<Shinmei> ShinmeiDbSet { get; set; }

        public DbSet<Region> RegionDbSet { get; set; }
        public DbSet<Ryouseikoku> RyouseikokuDbSet { get; set; }
        public DbSet<Prefecture> PrefectureDbSet { get; set; }
        public DbSet<Municipality> MunicipalityDbSet { get; set; }
        public DbSet<Location> LocationDbSet { get; set; }

        public DbSet<Theory> TheoryDbSet { get; set; }
        public DbSet<TheoryRelation> TheoryRelationDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=wwwroot/jinja_resource/jinja.db")
                .UseLazyLoadingProxies();
        }
    }
}