using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Data.Models;
using SimpleImageGallery.Models;

namespace SimpleImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {

            var hikingImageTags = new List<ImageTag>();
            var cityImageTags = new List<ImageTag>();

            var tag1 = new ImageTag()
            {
                Id = 0,
                Description = "Adventure"
            };
            var tag2 = new ImageTag()
            {
                Id = 1,
                Description = "Urban"
            };
            var tag3 = new ImageTag()
            {
                Id = 2,
                Description = "New York"
            };

            hikingImageTags.Add(tag1);
            cityImageTags.AddRange(new List<ImageTag>(){ tag2, tag3});

            var imageList = new List<GalleryImage>()
            {
                new GalleryImage()
                {
                    Created=DateTime.Now,
                    Url="https://i.kinja-img.com/gawker-media/image/upload/s--H3qvJyfF--/c_scale,f_auto,fl_progressive,q_80,w_800/lass9u84jcpjgznzdp22.jpg",
                    Title ="Hiking Trip",
                    Tags = hikingImageTags
                },

                  new GalleryImage()
                {
                    Created=DateTime.Now,
                    Url="https://outdoorgearpicks.com/wp-content/uploads/2018/12/Mens-Hiking-Short.jpg",
                    Title ="On the trail",
                    Tags = hikingImageTags
                },

                    new GalleryImage()
                {
                    Created=DateTime.Now,
                    Url="https://assets.experiencescottsdale.com/simpleview/image/upload/c_fill,h_433,q_60,w_650/v1/clients/scottsdale/McDows003_6f5701de-ee70-4083-8f7a-f92305585f26.jpg",
                    Title ="Downtown",
                    Tags = cityImageTags
                }
            };
            var model = new GalleryIndexModel()
            {
                Images = imageList,
                SearchQuery = ""
            };
            return View(model);
        }
    }
}