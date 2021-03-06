using Kubex.DAL.Configurations;
using Kubex.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kubex.DAL
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DailyActivityReport> DailyActivityReports { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryType> EntryTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<ZIP> ZIPCodes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PostRole> PostRoles { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }

        public DataContext(DbContextOptions options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AddressConfiguration());

            builder.Entity<ZIP>()
                .HasIndex(x => x.Code)
                .IsUnique();

            builder.Entity<Street>()
                .HasIndex(x => x.Name)
                .IsUnique();   

            builder.Entity<Country>()
                .HasIndex(x => x.Name)
                .IsUnique();
            
            builder.Entity<Post>()
                .HasMany<UserPost>(p => p.Users)
                .WithOne(up => up.Post)
                .IsRequired()
                .HasForeignKey(up => up.PostId);
            
            builder.Entity<UserPost>()
                .HasKey(k => new { k.UserId, k.PostId });
            
            builder.Entity<PostRole>()
                .HasKey(k => new { k.PostId, k.RoleId });
            
            builder.Entity<Post>()
                .HasMany<PostRole>(p => p.Roles)
                .WithOne(pr => pr.Post)
                .IsRequired()
                .HasForeignKey(pr => pr.PostId);
        }
    }
}