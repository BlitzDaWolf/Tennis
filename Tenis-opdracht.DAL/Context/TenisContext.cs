﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tenis_opdracht.DAL.Configuration;
using Tenis_opdracht.Data.Model;
using Tenis_opdracht.Data.Model.Interface;

namespace Tenis_opdracht.DAL.Context
{
    public class TenisContext : DbContext
    {
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameResult> GameResults{ get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<League> Leagues{ get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberRole> memberRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public TenisContext() : base() { }
        public TenisContext(DbContextOptions<TenisContext> options) : base(options) { }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            foreach (var item in markedAsDeleted)
            {
                if (item.Entity is IIsDeleted entity)
                {
                    item.State = EntityState.Unchanged;
                    entity.IsDeleted = true;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new FineConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new GameResultConfiguration());
            modelBuilder.ApplyConfiguration(new LeagueConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new MemberRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
