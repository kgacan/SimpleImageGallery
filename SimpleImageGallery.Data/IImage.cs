using SimpleImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleImageGallery.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();
        GalleryImage GetById(int id);
        IEnumerable<GalleryImage> GetWithTags(string tag);
    }
}
