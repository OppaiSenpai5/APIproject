using Models.Dtos;
using System.ComponentModel.DataAnnotations;

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
