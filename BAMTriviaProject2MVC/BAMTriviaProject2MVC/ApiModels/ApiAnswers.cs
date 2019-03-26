using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTriviaProject2MVC.ApiModels
{
    public class ApiAnswers
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Answer { get; set; }

        [Required]
        [StringRange(AllowableValues = new[] { "true", "false" }, ErrorMessage = "Boolean values must be 'true' or 'false'")]
        public bool Correct { get; set; }
    }
}
