using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Core.Dtos
{
    public class CustomResponseDto<T> 
    {
        public T Data { get; set; }
        public ErrorDto Error { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
        public static CustomResponseDto<T> Success(int statusCode,T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode,IsSuccessful =true };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> {StatusCode = statusCode , IsSuccessful = true };
        }
        //----------------------------------------------------------------------------------
        public static CustomResponseDto<T> Fail(int statusCode ,ErrorDto errorDto)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Error = errorDto, IsSuccessful = false };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string errorMessage, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new CustomResponseDto<T> { StatusCode = statusCode, Error = errorDto, IsSuccessful = false };
        }
        
    }
}
