using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Xor : ValidationAttribute
    {
        private string xorTargetAttribute;

        public Xor(string target)
        {
            this.xorTargetAttribute = target;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetAttribute = validationContext.ObjectType
                                                   .GetProperty(xorTargetAttribute)
                                                   .GetValue(validationContext.ObjectInstance);

            if ((targetAttribute == null && value != null) || (targetAttribute !=  null && value == null))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The target attribute and the value must be of opposite values");
        }
    }
}
