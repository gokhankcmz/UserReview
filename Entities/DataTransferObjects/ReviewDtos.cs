using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ReviewDtoPublic : ReviewDto_base
    {
    }

    public class ReviewDto_user : ReviewDto_base
    {
        public ReviewStatus reviewStatus { get; set; }

    }
    public class ReviewDto_rejected : ReviewDto_base
    {
        public ReviewStatus reviewStatus { get; set; }
        public string rejectReason { get; set; }

    }
    public class ReviewForCreationDto : ReviewDto_base
    {
        public Guid id = new Guid();

        public ReviewStatus reviewStatus = ReviewStatus.Pending;

    }

    public class ReviewForUpdateDto: ReviewDto_base
    {
    }

    public abstract class ReviewDto_base
    {
        [Required(ErrorMessage = "Content is a required field.")]
        [MaxLength(500, ErrorMessage = "Maximum length for the content is 500 characters.")]
        public string content { get; set; }


        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(500, ErrorMessage = "Maximum length for the title is 50 characters.")]
        public string title { get; set; }


        [Required(ErrorMessage = "Star is a required field.")]
        [MaxLength(1, ErrorMessage = "Maximum length for the star is 1 character.")]
        [Range(0, 5, ErrorMessage = "Star value cannot be greater than 5.")]
        public int star { get; set; }

    }


}
