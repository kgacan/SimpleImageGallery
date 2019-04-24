using Microsoft.EntityFrameworkCore;
using SimpleImageGallery.Data;
using SimpleImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;

using System.Threading.Tasks;

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
            return GetAll().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<GalleryImage> GetWithTags(string tag)
        {
            return GetAll().Where(x => x.Tags.Any(t => t.Description == tag));
        }

        public async Task SetImage(string title, string tags, Uri uri)
        {
            var image = new GalleryImage
            {
                Title = title,
                Tags = ParseTags(tags),
                Url = uri.AbsoluteUri,
                Created = DateTime.Now,

            };
            _ctx.Add(image);
            await _ctx.SaveChangesAsync();
        }

        public List<ImageTag> ParseTags(string tags)
        {
            return tags.Split(",").Select(tag => new ImageTag { Description = tag }).ToList();

            //var imageTags = new List<ImageTag>();
            //foreach (var tag in tagList)
            //{
            //    imageTags.Add(new ImageTag
            //    {
            //        Description = tag
            //    });
            //}
            //return imageTags; 
        }


        //public CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName)
        //{
        //    var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
        //    var blobClient = storageAccount.CreateCloudBlobClient();
        //    return blobClient.GetContainerReference(containerName);
        //}
    }
}
