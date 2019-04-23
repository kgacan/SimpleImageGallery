using Microsoft.EntityFrameworkCore;
using SimpleImageGallery.Data.Models;
using System;

namespace SimpleImageGallery.Data
{
    public class SimpleImageGalleryDbContext : DbContext
    {
        public SimpleImageGalleryDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<GalleryImage> GalleryImages { get; set; }
        DbSet<ImageTag> ImageTags { get; set; }
    }
}
