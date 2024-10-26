using System;
using System.ComponentModel.DataAnnotations;

namespace BlogMVCProject.Models
{
    public class Article
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The article title cannot be blank")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Please enter a title between 3 and 100 characters in length")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Please enter a title with only letters, numbers, and spaces")]
        [Display(Name = "Article Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The article content cannot be blank")]
        [StringLength(5000, MinimumLength = 50, ErrorMessage = "Please enter content between 50 and 5000 characters in length")]
        public string Content { get; set; }

        [Required(ErrorMessage = "The published date cannot be blank")]
        [DataType(DataType.Date)]
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
