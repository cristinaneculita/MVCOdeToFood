using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
        [StringLength(2000)]
        public string Body { get; set; }
        [Display (Name="User name")]
        [DisplayFormat(NullDisplayText="anonymus")]
        [MaxWords(1)]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }
    }

    public class MaxWordsAttribute : ValidationAttribute
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int i): base("{0} has too many words")
        {
            _maxWords = i;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > _maxWords)
                {
                    var errorMassage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMassage);
                }

            }
            return ValidationResult.Success;
        }
    }
}