using System;
using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{

    public class CustomNoContentResponseDTO
    {

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }


        public static CustomNoContentResponseDTO Success(int statusCode)
        {
            return new CustomNoContentResponseDTO { StatusCode = statusCode };
        }

        public static CustomNoContentResponseDTO Fail(List<string> errors, int statusCode)
        {
            return new CustomNoContentResponseDTO { StatusCode = statusCode, Errors = errors };
        }
        public static CustomNoContentResponseDTO Fail(string error, int statusCode)
        {
            return new CustomNoContentResponseDTO { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }

    public class CustomResponseDTO<T>
	{
		public T Data { get; set; }

		[JsonIgnore]
		public int StatusCode { get; set; }
		public List<String> Errors { get; set; }

		public static CustomResponseDTO<T> Success(int statusCode,T data)
		{
			return new CustomResponseDTO<T> { Data = data, StatusCode = statusCode, Errors = null };
		}

        public static CustomResponseDTO<T> Success(int statusCode)
        {
            return new CustomResponseDTO<T> {StatusCode = statusCode};
        }

        public static CustomResponseDTO<T> Fail(List<string> errors, int statusCode)
        {
            return new CustomResponseDTO<T> {StatusCode = statusCode, Errors = errors };
        }
        public static CustomResponseDTO<T> Fail(string error, int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}

