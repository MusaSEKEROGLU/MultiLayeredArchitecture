using System.Text.Json.Serialization;

namespace MultiLayered.Core.Dtos
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore] //Clientlar görmesin
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }


        //static factory metodlar
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
