using Microsoft.AspNetCore.Components.Forms;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SLK.TryEdu.Abstract;

public static class UploadHelper
{
    public async static Task<Tuple<string, string>> ImageBase64(IBrowserFile file, int size = 5, string accept = ".png, .jpg, .jpeg")
    {
        if (file != null)
        {
            if (file.Size > size * 1024 * 1024)
            {
                return new Tuple<string, string>("error", $"Kích thước file vượt quá {size}MB");
            }

            var ext = Path.GetExtension(file.Name).ToLowerInvariant();

            string[] extensions = accept.Split(',').Select(x => x.Trim().ToLower()).ToArray();
            
            if (!extensions.Contains(ext))
            {
                return new Tuple<string, string>("error", $"File không đúng định dạng ({accept})");
            }

            using var stream = new MemoryStream();
            using var readStream = file.OpenReadStream(maxAllowedSize: size * 1024 * 1024);
            await readStream.CopyToAsync(stream);
            stream.Seek(0, SeekOrigin.Begin);

            byte[] imageBytes = stream.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);

            string imageBase64 = $"data:{file.ContentType};base64,{base64String}";

            return new Tuple<string, string>("success", imageBase64);
        }
        else
        {
            return new Tuple<string, string>("error", "File không tồn tại ..");
        }
    }
}