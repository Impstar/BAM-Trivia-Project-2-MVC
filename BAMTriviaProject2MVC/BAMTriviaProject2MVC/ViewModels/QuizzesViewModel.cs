using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTriviaProject2MVC.ViewModels
{
    public class QuizzesViewModel
    {
        public int Id { get; set; }
        public int MaxScore { get; set; }
        public int Difficulty { get; set; }
        public string Category { get; set; }

        public List<string> Categories = new List<string>()
        {
            "QC",
            "Beer",
            "Movies"
        };

        public Dictionary<int, string> Difficulties = new Dictionary<int, string>()
        {
            {1, "Easy" },
            {2, "Medium" },
            {3, "Hard" }
        };

    }
}
