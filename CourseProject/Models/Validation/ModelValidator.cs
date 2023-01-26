namespace Models.Validation
{
    using Models.Dtos;
    using System.ComponentModel.DataAnnotations;
    
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
