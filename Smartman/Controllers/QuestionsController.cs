using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smartman.Models;
using Smartman.Repository;
using Smartman.ViewModels;

namespace Smartman.Controllers
{
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly QuestionRepository _questionRepository;
        private readonly HistoryRepository _historyRepository;

        public QuestionsController(SmartmanDbContext dbContext)
        {
            _userRepository = new UserRepository(dbContext);
            _questionRepository = new QuestionRepository(dbContext);
            _historyRepository = new HistoryRepository(dbContext);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Add([FromBody]QuestionViewModel questionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var question = new QuestionModel
            {
                Id = questionViewModel.Id,
                Question = questionViewModel.Question,
                Answer = questionViewModel.Answer,
                Level = questionViewModel.Level,
                Correct_answer = questionViewModel.Correct_answer
            };
            _questionRepository.Add(question);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Edit([FromBody]QuestionViewModel questionViewModel, long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (_questionRepository.GetById(id) == null)
            {
                return NotFound();
            }
            var question = new QuestionModel
            {
                Id=questionViewModel.Id,
                Question=questionViewModel.Question,
                Answer=questionViewModel.Answer,
                Correct_answer=questionViewModel.Correct_answer,
                Level=questionViewModel.Level
            };
            _questionRepository.Edit(question);
            return Ok();
        }

        [Authorize(Roles ="admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody]QuestionViewModel questionViewModel, long id)
        {
            var question = _questionRepository.GetById(id);
            if (question == null)
            {
                return NotFound();
            }
            _questionRepository.Delete(question);
            return Ok();
        }

        [Authorize(Roles ="admin")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_questionRepository.Get().Select(QuestionViewModel.ToViewModel));
        }

        [Authorize(Roles ="admin")]
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var question = _questionRepository.GetById(id);
            if (question==null)
            {
                return NotFound();
            }
            return Ok(QuestionViewModel.ToViewModel(question));
        }
    }
}
