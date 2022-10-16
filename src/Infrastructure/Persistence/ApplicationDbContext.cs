using Domain.Entities.media;
using Infrastructure.Identity.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public virtual DbSet<Media> Medias { get; set; }
    
    public virtual DbSet<MediaCategory> MediaCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Media>()
            .HasOne<MediaCategory>(a => a.MediaCategory)
            .WithMany(a => a.Medias)
            .HasForeignKey(a => a.MediaCategoryId);
        
        base.OnModelCreating(builder);
    }
}

