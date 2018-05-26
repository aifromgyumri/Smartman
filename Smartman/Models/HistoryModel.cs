using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartman.Models
{
    public class HistoryModel
    {
        public long Id { get; set; }
        public UserModel User { get; set; }

        public QuestionModel Question { get; set; }

        
    }
}