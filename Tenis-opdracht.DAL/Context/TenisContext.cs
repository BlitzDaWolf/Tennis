using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Drawing;
using Tenis_opdracht.Data;
using System.Reflection;
using System;
using System.Linq.Expressions;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fine>(e => 
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Id).ValueGeneratedOnAdd();

                e.Property(c => c.FineNumber).IsRequired().HasColumnType("INT").HasMaxLength(10);
                e.HasIndex(c => c.FineNumber).IsUnique();

                e.Property(c => c.Amount).IsRequired().HasColumnType("DECIMAL(7, 2)");
                e.Property(c => c.handOutDate).IsRequired().HasColumnType("DATE");
                e.Property(c => c.PaymentDate).HasColumnType("DATE");

                e.HasOne(c => c.Member).WithMany();

                e.HasQueryFilter(p => !p.IsDeleted);
                e.Property(c => c.IsDeleted).HasDefaultValue(false);

                e.HasOne(c => c.Member).WithMany().HasForeignKey(k => k.MemberId);

                e.ToTable("tblMemberFines");
            });
            modelBuilder.Entity<Game>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Id).ValueGeneratedOnAdd();

                e.Property(c => c.GameNumber).HasColumnType("VARCHAR(10)").IsRequired();
                e.HasIndex(c => c.GameNumber).IsUnique();

                e.Property(c => c.Date).IsRequired().HasColumnType("DATE");

                e.HasOne(c => c.Member).WithMany();
                e.HasOne(c => c.League).WithMany();

                e.HasQueryFilter(p => !p.IsDeleted);
                e.Property(c => c.IsDeleted).HasDefaultValue(false);

                e.HasOne(c => c.Member).WithMany().HasForeignKey(k => k.MemberId);
                e.HasOne(c => c.League).WithMany().HasForeignKey(k => k.LeagueId);

                e.ToTable("tblGames");
            });
            modelBuilder.Entity<GameResult>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Id).ValueGeneratedOnAdd();

                e.Property(c => c.SetNr).IsRequired().HasColumnName("INT").HasMaxLength(3);
                e.Property(c => c.ScoreTeamMember).IsRequired().HasColumnType("INT").HasMaxLength(3);
                e.Property(c => c.ScoreOpponent).IsRequired().HasColumnType("INT").HasMaxLength(3);

                e.HasIndex(c => new { c.SetNr, c.GameId }).IsUnique();

                e.HasOne(c => c.Game).WithMany().HasForeignKey(k => k.GameId);

                e.ToTable("tblGameResults");
            });
            modelBuilder.Entity<Gender>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Id).ValueGeneratedOnAdd();

                e.Property(c => c.Name).IsRequired().HasColumnType("VARCHAR(10)").HasMaxLength(10);
                e.HasIndex(c => c.Name).IsUnique();

                e.HasQueryFilter(p => !p.IsDeleted);
                e.Property(c => c.IsDeleted).HasDefaultValue(false);

                e.ToTable("tblGenders");
            });
            modelBuilder.Entity<League>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Id).ValueGeneratedOnAdd();

                e.Property(c => c.Name).IsRequired().HasColumnType("VARCHAR(10)").HasMaxLength(10);
                e.HasIndex(c => c.Name).IsUnique();

                e.HasQueryFilter(p => !p.IsDeleted);
                e.Property(c => c.IsDeleted).HasDefaultValue(false);

                e.ToTable("tblLeagues");
            });
            modelBuilder.Entity<Member>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Id).ValueGeneratedOnAdd();

                e.Property(c => c.FederationNr).IsRequired().HasColumnType("VARCHAR(10)");
                e.HasIndex(c => c.FederationNr).IsUnique();

                e.Property(c => c.FirstName).IsRequired().HasColumnType("VARCHAR(25)");
                e.Property(c => c.LastName).IsRequired().HasColumnType("VARCHAR(35)");
                e.Property(c => c.BirthDate).IsRequired().HasColumnType("DATE");
                e.Property(c => c.Address).IsRequired().HasColumnType("VARCHAR(70)");
                e.Property(c => c.Number).IsRequired().HasColumnType("VARCHAR(6)");
                e.Property(c => c.Addition).HasColumnType("VARCHAR(2)");
                e.Property(c => c.Zipcode).IsRequired().HasColumnType("VARCHAR(6)");
                e.Property(c => c.City).IsRequired().HasColumnType("VARCHAR(30)");
                e.Property(c => c.PhoneNr).HasColumnType("VARCHAR(15)");

                e.HasQueryFilter(p => !p.IsDeleted);
                e.Property(c => c.IsDeleted).HasDefaultValue(false);

                e.HasMany(c => c.Fines).WithOne(c => c.Member).HasForeignKey(c => c.MemberId);
                e.HasMany(c => c.Roles).WithOne(c => c.Member).HasForeignKey(c => c.MemberId);
                e.HasMany(c => c.Games).WithOne(c => c.Member).HasForeignKey(c => c.MemberId);

                e.HasOne(c => c.Gender).WithMany().HasForeignKey(k => k.GenderId);

                e.ToTable("tblMembers");
            });
            modelBuilder.Entity<MemberRole>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Id).ValueGeneratedOnAdd();

                e.Property(c => c.StartDate).IsRequired().HasColumnType("DATE");
                e.Property(c => c.EndDate).HasColumnType("DATE");

                e.HasQueryFilter(p => !p.IsDeleted);
                e.Property(c => c.IsDeleted).HasDefaultValue(false);

                e.HasIndex(c => new { c.MemberId, c.RoleId, c.StartDate, c.EndDate }).IsUnique();

                e.HasOne(c => c.Role).WithMany().HasForeignKey(k => k.RoleId);
                e.HasOne(c => c.Member).WithMany().HasForeignKey(k => k.MemberId);

                e.ToTable("tblMemberRoles");
            });
            modelBuilder.Entity<Role>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Id).ValueGeneratedOnAdd();

                e.Property(c => c.Name).IsRequired().HasColumnType("VARCHAR(20)");
                e.HasIndex(c => c.Name).IsUnique();

                e.HasQueryFilter(p => !p.IsDeleted);
                e.Property(c => c.IsDeleted).HasDefaultValue(false);

                e.ToTable("tblRoles");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
