using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SimpleImageGallery.Models;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using SimpleImageGallery.Data;

namespace SimpleImageGallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImage _imageService;

        private IConfiguration _config;
        private string AzureConnectionString { get; }

        public ImageController(IConfiguration config, IImage imageService)
        {
            _imageService = imageService;
            _config = config;
            AzureConnectionString = _config["AzureStorageConnectionString"];
        }
        public IActionResult Upload()
        {
            var model = new UploadImageModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewImage(IFormFile file, string tags, string title)
        {
            var container = GetBlobContainer(AzureConnectionString, "images");
            var content = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var fileName = content.FileName.Trim('"');

            var blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            await _imageService.SetImage(title, tags, blockBlob.Uri);

            return RedirectToAction("Index", "Gallery");
        }



        //This does not work in service layer and I made method here in controller
        public CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(containerName);
        }
    }
}