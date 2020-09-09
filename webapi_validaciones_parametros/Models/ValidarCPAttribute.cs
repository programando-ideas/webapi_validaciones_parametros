using System.ComponentModel.DataAnnotations;

namespace webapi_validaciones_parametros.Models
{
    public class ValidarCPAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string re = "^[0-9]{5}$";

            if (System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), re))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("El código postal es incorrecto");
        }
    }
}
