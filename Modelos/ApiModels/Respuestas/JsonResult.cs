using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ApiModels.Respuestas
{
    public class JsonResult
    {

        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public string EntityResult { get; set; }

    }
}
