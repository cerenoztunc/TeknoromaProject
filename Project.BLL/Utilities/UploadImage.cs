using Microsoft.AspNetCore.Http;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Utilities
{
    public static class UploadImage
    {
        public static async Task UploadImageAsync(IFormFile userPicture, AppUser user)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPicture", fileName);
            using var stream = new FileStream(path, FileMode.Create);
            await userPicture.CopyToAsync(stream);
            user.Picture = "/UserPicture/" + fileName;
        }
    }
}
