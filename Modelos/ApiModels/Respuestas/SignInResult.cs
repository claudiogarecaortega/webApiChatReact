using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Modelos.ApiModels.Respuestas
{
    public class SignInResult
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        //Included to show all the available properties, but unused in this sample
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public uint ExpiresIn { get; set; }

        [JsonProperty(".issued")]
        public DateTimeOffset Issued { get; set; }

        [JsonProperty(".expires")]
        public DateTimeOffset Expires { get; set; }

        #region Propiedades Usuario

        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("userNameShort")]
        public string UserNameShort { get; set; }
        [JsonProperty("usuarioId")]
        public string Id { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }
        [JsonProperty("hasImage")]
        public string HasImage { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
      
        #endregion

        public JsonResult JsonResult { get; set; }

    }
}
