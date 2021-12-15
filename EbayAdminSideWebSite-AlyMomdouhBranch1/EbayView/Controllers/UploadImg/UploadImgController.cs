using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Hosting;
using static System.Net.Mime.MediaTypeNames;
using Azure.Storage.Blobs;
using EbayView.Services;
using Microsoft.Extensions.Options;
using Azure.Storage.Blobs.Models;
//using Microsoft.Azure.Storage;
//using Microsoft.Azure.Storage.Blob;
//using System.Web.Mvc;
//using System.Web.HttpContext.Current;
//using System.Web.Optimization;

namespace EbayView.Controllers.UploadImg
{
    public class UploadImgController : Controller //Microsoft.AspNetCore.Mvc.Controller
    {   // to run add services.AddSingleton<UploadImgController>();
        //static string connectionstring =  "DefaultEndpointsProtocol=https;AccountName=itiprojectuploadingimgs;AccountKey=GF2Yq/tvZe+J7bUExxjRVJ6Qa319TUo3AsbsSY1kfSC4HlyykU4cShguZsnspbjMACFSQYy3QXbq+4Yr5PfgJA==;EndpointSuffix=core.windows.net";
        //static string containerName = "ProductsImages";

        private readonly AzureStorage azureStorage;
         
        private readonly IWebHostEnvironment webHostEnvironment;
        [Obsolete]
        private IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public UploadImgController(IWebHostEnvironment _webHostEnvironment, IHostingEnvironment hostingEnvironment,
            IOptions<AzureStorage> _azureStorage)
        {
             webHostEnvironment = _webHostEnvironment;
            _hostingEnvironment = hostingEnvironment;
            azureStorage = _azureStorage.Value;
        } 
        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> UploadLogo(IFormFile file)
        {
            var fileName = "";
            var fullPath = "";
            var imgazureurl = "";
             try
             {
                if (file.Length > 0)
                {
                    //string webRootPath = _hostingEnvironment.WebRootPath + "\\ProfileImages\\";
                    string  webRootPath = _hostingEnvironment.WebRootPath + "\\img\\Uploads\\Photos";
                //var rn = new Random();
                      fileName = "prodimg"+ Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                     //fileName = "prodimg"+ rn.Next(10,10000).ToString() + Path.GetExtension(file.FileName);
                fullPath = Path.Combine(webRootPath, fileName); 
                    using (FileStream fileStream = System.IO.File.Create(fullPath))
                    {
                        await file.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                    }
                    imgazureurl= await UploadToAzureAsync(file, fileName);
            }
                                              
               return Json(new { success = true, imgazureurl= imgazureurl, imageURL = fullPath, imagename = fileName, responseText = "wellcom" }); 
             }
             catch (Exception ex)
            {
                // return Ok(fileName);
                return Json(new { Success = false, Message = ex.Message });
             }
        }
         //private async Task<OkObjectResult> UploadToAzureAsync(IFormFile file,string fileName)
         private async Task<string> UploadToAzureAsync(IFormFile file,string fileName)
        {
            #region  some comment codes
            /* 
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient(); 
            var cloudBlobContainer = cloudBlobClient.GetContainerReference("Productsimages"); 
            if (await cloudBlobContainer.CreateIfNotExistsAsync())
            {
                await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Off });
            } 
            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(file.FileName);
            cloudBlockBlob.Properties.ContentType = file.ContentType; 
            await cloudBlockBlob.UploadFromStreamAsync(file.OpenReadStream()); 
            var myfiles = Directory.GetFiles(filepath);
            StreamReader streamReader = new StreamReader(file.OpenReadStream());
            containerClient.UploadBlob(file.FileName,streamReader.BaseStream,);
            using (MemoryStream stream = new MemoryStream( System.IO.File.ReadAllBytes(filepath)))
            {
                 containerClient.UploadBlob(fileName,stream);
            }
            Stream outStream = new MemoryStream();
            var cloudBlockBlob = containerClient.GetBlockBlobReference(file.FileName);
            cloudBlockBlob.Properties.ContentType = file.ContentType; 
            await cloudBlockBlob.UploadFromStreamAsync(file.OpenReadStream());

            using (MemoryStream stream = new MemoryStream(System.IO.File.ReadAllBytes(file.FileName)))
            {
                containerClient.UploadBlob(file.Name, stream);
            }
            string localFilePath = Path.Combine(azureStorage.SourceFolder, file.FileName);
             string localFilePath =  azureStorage.SourceFolder+fileName ;
            await blobClient.UploadAsync(fullPath, false);
            /
            string localPath1 = ".\\wwwroot\\img\\Uploads\\Photos";
            string fileName1 = "quickstart" + Guid.NewGuid().ToString() + ".txt";
                    string localFilePath2 = Path.Combine(localPath1, fileName);
            await System.IO.File.WriteAllTextAsync(localFilePath1, "Hello, World!");
            BlobClient blobClient1 = containerClient.GetBlobClient(fileName1);
            await blobClient.UploadAsync(localFilePath2, true);
            "SourceFolder": "D:\\finalproject\\newversionAdminSide\\EbayAdminSideWebSite\\EbayView\\wwwroot\\img\\Uploads\\Photos"
            */
            #endregion
            BlobServiceClient blobServiceClient = new BlobServiceClient(azureStorage.ConnectionString);
            BlobContainerClient containerClient;
            if (blobServiceClient.GetBlobContainerClient(azureStorage.ContainerName) != null)
            {
                containerClient = blobServiceClient.GetBlobContainerClient(azureStorage.ContainerName);
            }
            else
            {
                containerClient = blobServiceClient.CreateBlobContainer(azureStorage.ContainerName);
            }
            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            // Upload data from the local file
            try
            {
                
                var httpheaders = new BlobHttpHeaders()
                {
                    ContentType = file.ContentType,
                };
                var res = await blobClient.UploadAsync(file.OpenReadStream(),httpheaders);// if given file in IFormFile
                if (res!=null) { return blobClient.Uri.AbsoluteUri; }
                else { return ""; }
                 
            }
            catch (Exception e) { return e.Message.ToString() ; }
             
        }
        
        public async Task<IActionResult> UploadadminImg(IFormFile file)
        {
            var fileName = "";
            var fullPath = "";
            var imgazureurl = "";
            try
            {
                if (file.Length > 0)
                {
                    fileName = "adminimg" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    BlobServiceClient blobServiceClient = new BlobServiceClient(azureStorage.ConnectionString);
                    BlobContainerClient containerClient;
                    if (blobServiceClient.GetBlobContainerClient(azureStorage.ContainerName) != null)
                    {
                        containerClient = blobServiceClient.GetBlobContainerClient(azureStorage.ContainerName);
                    }
                    else
                    {
                        containerClient = blobServiceClient.CreateBlobContainer(azureStorage.ContainerName);
                    }
                    // Get a reference to a blob
                    BlobClient blobClient = containerClient.GetBlobClient(fileName);
                    // Upload data from the local file 
                    var httpheaders = new BlobHttpHeaders()
                    {
                        ContentType = file.ContentType,
                    };
                    var res = await blobClient.UploadAsync(file.OpenReadStream(), httpheaders);// if given file in IFormFile
                    if (res != null) { imgazureurl = blobClient.Uri.AbsoluteUri; }
                    return Json(new { success = true, imgazureurl = imgazureurl, imageURL = fullPath, imagename = fileName });
                }
            }
            catch (Exception ex)
            {
                // return Ok(fileName);
                return Json(new { Success = false, Message = ex.Message });
            }
            return Json(new { Success = false, Message ="image not save to server try again" });
        }
        // not working  yet
        public static string DeleteFile(string folderName, string fileName)
        {
            try
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\img\\Uploads\\Photos" + folderName + fileName))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\img\\Uploads\\Photos" + folderName + fileName);
                }
                var result = "File Deleted!";
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } 
    } 
}
