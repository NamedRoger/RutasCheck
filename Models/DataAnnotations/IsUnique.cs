using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RutasCheck.Models.DataAnnotations
{
    public class IsUnique : ValidationAttribute
    {
        public string UserName { get; set; }

        public IsUnique()
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            return ValidationResult.Success;
        }

        public string GetErrorMessage() => $"El usuario {UserName} ya existe";


    }
}
