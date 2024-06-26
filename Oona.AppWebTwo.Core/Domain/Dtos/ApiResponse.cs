using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Core.Domain.Dtos
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public int Count { get; set; }
        public string Message { get; set; }

        public ApiResponse() { }
        public ApiResponse(object data , int count , string message)
        {
            Data = data;
            Count = count;
            Message = message;
        }
    }
}
