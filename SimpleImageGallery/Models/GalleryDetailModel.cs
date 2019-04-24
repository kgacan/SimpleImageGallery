using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleImageGallery.Models
{
    public class GalleryDetailModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }
        public virtual List<string> Tags { get; set; }
    }
}
