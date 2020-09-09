using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi_validaciones_parametros.Models
{
    public class RequestDireccionWithValidation : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string Numero { get; set; }
        public string Piso { get; set; }
        public string Depto { get; set; }

        [ValidarCP]
        public string CP { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //var (valid, result) = GetVaslidationStatus_v1(Piso, Depto);
            var (valid, result) = GetValidationStatus_v2(Piso, Depto);

            if (!valid)
            {
                yield return result;
            }
        }

        //switch expression: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
        //Lambda expressions: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
        //=> operator: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator
        //Tuple types: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
        //Pattern Matching: https://docs.microsoft.com/en-us/dotnet/csharp/pattern-matching
        private (bool, ValidationResult) GetVaslidationStatus_v1(string Piso, string Depto)
        {
            if (!string.IsNullOrWhiteSpace(Piso) && string.IsNullOrWhiteSpace(Depto))
            {
                return (false, new ValidationResult("El depto. es requerido cuando se indica el nro. de piso"));
            }

            return (true, null);
        }

        private (bool, ValidationResult) GetValidationStatus_v2(string Piso, string Depto)
           => (string.IsNullOrWhiteSpace(Piso), string.IsNullOrWhiteSpace(Depto)) switch
           {
               (false, true) => (false, new ValidationResult("El depto. es requerido cuando indica el piso", new[] { nameof(Depto) })),
                //(true, true) => (true, null),
                //(false, false) => (true, null),
                //(true, false) => (true, null)
                _ => (true, null)
           };
    }
}
