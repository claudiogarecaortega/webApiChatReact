using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FechaMenorQueAttribute:ValidationAttribute
    {
        private string FechaComparar { get; set; }
        public FechaMenorQueAttribute(string atributoFechaCoparar)
        {
            FechaComparar = atributoFechaCoparar;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime fechaIncio = (DateTime)value;

            DateTime fechaFin = (DateTime)validationContext.ObjectType.GetProperty(FechaComparar).GetValue(validationContext.ObjectInstance, null);

            if (fechaFin > fechaIncio)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("La fecha de incio no puede ser mayor a la fecha de fin");
            }
        }
    }
}
