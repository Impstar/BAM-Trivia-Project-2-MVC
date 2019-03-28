using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTriviaProject2MVC.ApiModels
{
    public class ApiUserQuiz
    {
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int QuizMaxScore { get; set; }
        public int QuizActualScore { get; set; }
        public DateTime QuizDate { get; set; }
    }
}
