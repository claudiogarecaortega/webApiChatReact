﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Resources;
using Libreria.Resource;

namespace Libreria.Attributes
{
    public class PlaceHolderAttribute : Attribute
    {
        private string _name;

        public string Name
        {
            get
            {
                var resourceManager = new ResourceManager(typeof(Resources));
                return resourceManager.GetString(_name);
            }
            set { _name = value; }
        }
    }
    [AttributeUsage(AttributeTargets.Property |AttributeTargets.Field)]
    public sealed class DecimaCustomlAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            return !value.ToString().Contains(',') || !value.ToString().Contains('.');
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture,
              "El campo {0} debe ser en el formato 000.0 sin ',' para separar miles", name);
        }
    }
    [AttributeUsage(AttributeTargets.Property |AttributeTargets.Field)]
    public sealed class DecimalPriceCustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var result = true;
            if (value == null)
                return false;
            decimal convertido;
            var resu = decimal.TryParse(value.ToString(), out convertido);
            return resu;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              "El campo {0} debe ser numero entero o decimal", name);
        }
    }
    [AttributeUsage(AttributeTargets.Property |
 AttributeTargets.Field, AllowMultiple = false)]
    sealed public class TextCustomlAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            // Add validation logic here.
            if (value == null)
                return false;

            return result;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              "El campo {0} no puede ser vacio", name);
        }
    }
    [AttributeUsage(AttributeTargets.Property |
AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CantidadCustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            // Add validation logic here.
            if (value == null)
                return false;
            int resulta = 0;
            bool y = int.TryParse(value.ToString(), out resulta);
            if (y && resulta == 0)
                return false;

            return result;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              "El campo {0} no puede ser cero o vacio", name);
        }
    }
    [AttributeUsage(AttributeTargets.Property |
AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CodigoPostalCustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            // Add validation logic here.
            if (value == null)
                return false;

            int resulta = 0;

            if (!int.TryParse(value.ToString(), out resulta))
                return false;

            return result;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              "El campo {0} no puede contener simbolos o letras", name);
        }
    }
    [AttributeUsage(AttributeTargets.Property |
 AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CuitCustomlAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            // Add validation logic here.
            if (value == null)
                return false;
            if (value.ToString().Contains(',') && value.ToString().Contains('.'))
                return false;

            return result;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              "El campo {0} debe ser en el formato 000.0 sin ',' para separar miles", name);
        }
    }
    [AttributeUsage(AttributeTargets.Property |
 AttributeTargets.Field, AllowMultiple = false)]
    sealed public class NumeralCustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            // Add validation logic here.
            if (value == null)
                return false;
            int outvariable = 0;
            if (!int.TryParse(value.ToString(), out outvariable))
                return false;

            return result;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              "El campo {0} debe ser numero mayor o igual a 0", name);
        }
    }

}
