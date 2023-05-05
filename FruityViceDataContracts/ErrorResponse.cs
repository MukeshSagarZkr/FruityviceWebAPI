using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruityViceDataContracts
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; } 
    }
}
