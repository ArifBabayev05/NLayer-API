using System;
using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{
	public class NoContentDTO
	{
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }
    }
}

