using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPost
{
    public class LoginModel
    {
        [JsonProperty("error")]
        public string error { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
    }
}
