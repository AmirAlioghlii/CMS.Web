using Domain.Entities.media;
using Infrastructure.Identity.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public virtual DbSet<Media> Medias => Set<Media>();

    public virtual DbSet<MediaCategory> MediaCategories => Set<MediaCategory>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Media

        builder.Entity<Media>().Property(a => a.Alt).HasMaxLength(255);

        builder.Entity<Media>().Property(a => a.Title).HasMaxLength(255);

        builder.Entity<Media>().Property(a => a.Url).IsRequired();

        builder.Entity<Media>()
            .HasOne<MediaCategory>(a => a.MediaCategory)
            .WithMany(a => a.Medias)
            .HasForeignKey(a => a.MediaCategoryId);

        #endregion

        base.OnModelCreating(builder);
    }
}

