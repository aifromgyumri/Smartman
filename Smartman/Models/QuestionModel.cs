using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartman.Models
{
    public class QuestionModel
    {
        public long Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public string Correct_answer { get; set; }

        public int Level { get; set; }

    }
}
