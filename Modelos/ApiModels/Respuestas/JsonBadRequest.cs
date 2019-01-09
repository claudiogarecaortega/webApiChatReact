using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Modelos.ApiModels.Respuestas
{
    public class JsonBadRequest
    {
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        public string Message { get; set; }

        public Dictionary<string, ICollection<string>> ModelState { get; set; }
    }
}
