using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DJ_UploadFile.Services
{
    public class CloudinaryUpload
    {
        //https://console.cloudinary.com/
        static string cloudName = "";
        static string apiKey = "";
        static string apiSecret = "";
        static private readonly Random rnd = new Random();
        static public
            Account account = new Account(cloudName, apiKey, apiSecret);
        static public Cloudinary _cloudinary = new Cloudinary(account);
        public static async Task<string> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file selected.");
            }

            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = "xyz-abc" + "_" + rnd.Next() + "_" + DateTime.Now.ToShortDateString() // ID công khai tùy ý cho file
                };

                var uploadResult = await CloudinaryUpload._cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {
                    // Xử lý lỗi tải lên
                    throw new Exception(uploadResult.Error.Message);
                }

                // Lấy URL công khai của file tải lên
                string imageUrl = uploadResult.SecureUrl.ToString();

                // Tiếp tục xử lý hoặc lưu thông tin về file trong cơ sở dữ liệu

                return imageUrl;
            }
        }

    }
}
