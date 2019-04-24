using SimpleImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleImageGallery.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();
        GalleryImage GetById(int id);
        IEnumerable<GalleryImage> GetWithTags(string tag);
        Task SetImage(string title, string tags, Uri uri);
        List<ImageTag> ParseTags(string tags);
    }
}
