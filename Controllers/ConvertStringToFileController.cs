using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ConvertBase64StringToFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertStringToFileController : ControllerBase
    {
        private static string _filesPath = @"C:\Images\";

        [HttpPost]
        [Route("upload")]
        public IActionResult ConvertBase64StringToFile(IFormFile file) => file != null ? Ok(uploadFile(file)) : NotFound();

        private string uploadFile(IFormFile file)
        {
            MemoryStream stream = new MemoryStream();

            file.CopyTo(stream);

            byte[] bytes = stream.ToArray();

            var path = _filesPath + file.FileName;

            if (!System.IO.File.Exists(path))
            {
                System.IO.File.WriteAllBytes(path, bytes);
            }

            return path;
        }
    }
}
