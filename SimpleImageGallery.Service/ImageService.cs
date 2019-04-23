using Microsoft.EntityFrameworkCore;
using SimpleImageGallery.Data;
using SimpleImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleImageGallery.Service
{
    public class ImageService : IImage
    {
        private readonly SimpleImageGalleryDbContext _ctx;

        public ImageService(SimpleImageGalleryDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages.Include(x => x.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return _ctx.GalleryImages.Find(id);
        }

        public IEnumerable<GalleryImage> GetWithTags(string tag)
        {
            return GetAll().Where(x => x.Tags.Any(t => t.Description == tag));
        }
    }
}
