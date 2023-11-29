using ECommerceBL.DTOs.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace ECommerce_App.Controllers.FilesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public ActionResult<UploadFileDto>Upload (IFormFile file) 
        {


            #region Check Extension
            var extension = Path.GetExtension(file.FileName);
            var allowedExtensions = new string[]
            {
                ".png",
                ".jpg", 
                ".svg"
            };
            bool IsExtensionAllowed = allowedExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase);
            if (!IsExtensionAllowed)
            {
                return BadRequest(new UploadFileDto(false, "Not Valid Extension"));
            }

            #endregion

            #region Check Length

                 // bool isSizeAllowed = file.Length is > 0 and < 4_000_000;  //Sugar  Syntax
                bool isSizeAllowed = file.Length > 0 && file.Length < 1_000_000;  
            if (!isSizeAllowed)
            {
                return BadRequest(new UploadFileDto(false, "File Size Is NOT Allowed", " "));
            }

            #endregion

             #region Image Storing

            var newFileName = $"{Guid.NewGuid()}{extension}";
            var imagePath = Path.Combine (Environment.CurrentDirectory,"Images");

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }


            var fullFilePath = Path .Combine (imagePath,newFileName);

            Console.WriteLine($"Full File Path: {fullFilePath}");

            using var stream = new FileStream(fullFilePath,FileMode.Create);
            file.CopyTo(stream);

            #endregion

            #region Generating URL

            var url = $"{Request.Scheme}://{Request.Host}/Images/{newFileName}";
            return new UploadFileDto(true, "Successful Storage", url);

            #endregion

        }
    }

}
