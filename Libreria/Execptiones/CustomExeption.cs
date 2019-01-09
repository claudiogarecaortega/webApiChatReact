using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Execptiones
{
    public class CustomExeption:Exception
    {
        public CustomExeption(string mensaje)
        :base(mensaje)
        {
        }
    }
    public class ExceptionCredencialInstrasferible : Exception
    {
        public ExceptionCredencialInstrasferible(string mensaje)
            : base(mensaje)
        {
        }
    }
    public class ExceptionEntrada: Exception
    {
        public ExceptionEntrada(string mensaje)
            : base(mensaje)
        {
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string mensaje)
            : base(mensaje)
        {
        }
    }

}
