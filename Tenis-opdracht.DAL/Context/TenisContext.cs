using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Drawing;
using Tenis_opdracht.Data;

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
            modelBuilder.Entity<Gender>(e =>
            {
                e.Property(c => c.Name).HasMaxLength(5);
                e.ToTable("tblGenders");
            });
            modelBuilder.Entity<Member>(e =>
            {
                e.Property(c => c.FederationNr).IsRequired().HasMaxLength(10);
                e.Property(c => c.FirstName).IsRequired().HasMaxLength(25);
                e.Property(c => c.LastName).IsRequired().HasMaxLength(35);
                e.Property(c => c.BirthDate).IsRequired();
                e.Property(c => c.Address).IsRequired().HasMaxLength(70);
                e.Property(c => c.Number).IsRequired().HasMaxLength(6);
                e.Property(c => c.Address).HasMaxLength(2);
                e.Property(c => c.Zipcode).IsRequired().HasMaxLength(6);
                e.Property(c => c.City).IsRequired().HasMaxLength(30);
                e.Property(c => c.PhoneNr).HasMaxLength(15);

                e.HasIndex(c => c.FederationNr).IsUnique();
                // e.HasOne(c => c.Gender).WithMany(c => c.Members);

                e.ToTable("tblMembers");
            });
        }
    }
}
