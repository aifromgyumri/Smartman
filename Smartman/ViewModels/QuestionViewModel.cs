using Smartman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartman.ViewModels
{
    public class QuestionViewModel
    {
        public long Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public string Correct_answer { get; set; }

        public int Level { get; set; }

        public static QuestionViewModel ToViewModel(QuestionModel question)
        {
            var questionViewModel = new QuestionViewModel
            {
                Id=question.Id,
                Question=question.Question,
                Answer=question.Answer,
                Level=question.Level,
                Correct_answer=question.Correct_answer
            };
            return questionViewModel;
        }

        public static QuestionModel ToModel(QuestionViewModel questionViewModel)
        {
            var question = new QuestionModel
            {
                Id = questionViewModel.Id,
                Question = questionViewModel.Question,
                Answer = questionViewModel.Answer,
                Level = questionViewModel.Level,
                Correct_answer = questionViewModel.Correct_answer,
            };
            return question;
        }
    }
}
