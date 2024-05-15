using System;
namespace CapitalRecruit.Infrastructure.Dtos.ResponseDto
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
