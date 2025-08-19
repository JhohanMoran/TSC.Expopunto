using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Domain.Models;

namespace TSC.Expopunto.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(
            int statusCode,
            object data = null,
            string message = null
        )
        {
            bool success = false;

            if (statusCode >= 200 && statusCode < 300)
            {
                success = true;
            }   

            var result = new BaseResponseModel
            {
                statusCode = statusCode,
                success = success,
                message = message ?? (success ? "Success" : "Error"),
                data = data
            };                   
            
            return result;
        }
    }
}
