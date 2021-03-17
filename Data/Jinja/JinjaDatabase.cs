﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Wadatsumi.Data.Jinja
{
    public class JinjaDbContext : DbContext
    {
        public DbSet<Jinja> JinjaDbSet { get; set; }
        public DbSet<Kami> KamiDbSet { get; set; }
        public DbSet<Ryouseikoku> RyouseikokuDbSet { get; set; }
        public DbSet<Shinmei> ShinmeiDbSet { get; set; }
        public DbSet<Saijin> SaijinDbSet { get; set; }
        public DbSet<Region> RegionDbSet { get; set; }
        public DbSet<Goshuin> GoshuinDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=wwwroot/database/jinja.db")
                .UseLazyLoadingProxies();
        }
    }
}