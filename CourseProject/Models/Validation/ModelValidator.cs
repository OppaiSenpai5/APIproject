using Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validation
{
    public static class ModelValidator
    {
        public static ValidationResult ValidEndDate(DateTime endDate, ValidationContext context)
        {
            var isValid =
                context.ObjectInstance is AnimeDto request && request.StartDate <= endDate;

            return isValid ? ValidationResult.Success! : new ValidationResult(null);
        }
    }
}
