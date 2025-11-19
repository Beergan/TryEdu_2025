using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using SLK.TryEdu.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

namespace SLK.TryEdu.Base.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UploadController : ControllerBase
{
    private IWebHostEnvironment _hostingEnv;

    public UploadController(IWebHostEnvironment env)
    {
        this._hostingEnv = env;
    }

    [HttpPost("SaveDocument")]
    public void SaveDocument(IList<IFormFile> chunkFile, IList<IFormFile> UploadFiles)
    {
        long size = 0;
        try
        {
            foreach (var file in UploadFiles)
            {
                var contentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var originalFileName = contentDisposition.FileName?.Trim('"') ?? file.FileName;

                var fileExt = Path.GetExtension(originalFileName);

                var fileName = $"{DateTime.Now:yyyyMMddHHmmss}{fileExt}";

                var relativePath = $"/upload/document{fileName}";

                var serverPath = Path.Combine(_hostingEnv.WebRootPath, "upload", "document", fileName);

                size += file.Length;

                var folderPath = Path.GetDirectoryName(serverPath);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (!System.IO.File.Exists(serverPath))
                {
                    using (var fs = new FileStream(serverPath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }

                Response.Headers.Append(nameof(relativePath), relativePath);
            }
        }
        catch (Exception e)
        {
            Response.Clear();
            Response.StatusCode = 204;
            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
        }
    }

    [HttpPost]
    public void Remove(IList<IFormFile> UploadFiles)
    {
        try
        {
            var filename = _hostingEnv.ContentRootPath + $@"{UploadFiles[0].FileName}";
            if (System.IO.File.Exists(filename))
            {
                System.IO.File.Delete(filename);
            }
        }
        catch (Exception e)
        {
            Response.Clear();
            Response.StatusCode = 200;
            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
        }
    }
}