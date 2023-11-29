using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBL.DTOs.Files
{
    public class UploadFileDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string URL { get; set; }

        public UploadFileDto(bool isSuccess , string message, string url=" ")
        {
            IsSuccess = isSuccess;
            Message = message;
            URL = url;
        }
        

    }
}
