namespace Models.Dtos
{
    using Models.Validation;
    
    using System.ComponentModel.DataAnnotations;
    
    public record AnimeDto
    {
        [Required(AllowEmptyStrings = false,
            ErrorMessage = "The title is required.")]
        [StringLength(200,
            ErrorMessage = "The title must be maximum of 200 characters long.")]
        public string Title { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "The episode count must be a whole positive number.")]
        public int? EpisodeCount { get; set; }

        public DateTime? StartDate { get; set; }

        [CustomValidation(typeof(ModelValidator),
            nameof(ModelValidator.ValidEndDate),
            ErrorMessage = "The ending date cannot precede the starting date.")]
        public DateTime? EndDate { get; set; }

        [Range(1, 10,
            ErrorMessage = "The score must be between 1 and 10.")]
        public double? Score { get; set; }

        [StringLength(10_000,
            ErrorMessage = "The synopsis can only be up to 10,000 characters long.")]
        public string? Synopsis { get; set; }
    }
}
