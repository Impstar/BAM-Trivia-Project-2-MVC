﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTriviaProject2MVC.ApiModels
{
    public class ApiQuizzes
    {
        public int Id { get; set; }
        public int MaxScore { get; set; }
        public int Difficulty { get; set; }
    }
}
