using Microsoft.EntityFrameworkCore;
using Smartman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartman.Repository
{
    public class QuestionRepository : AbstractRepository<QuestionModel, long>
    {
        public QuestionRepository(SmartmanDbContext context) : base(context)
        {
        }

        public override IEnumerable<QuestionModel> Get()
        {
            return _dbContext.Question.AsNoTracking().ToArray();
        }

        public override QuestionModel GetById(long id)
        {
            return _dbContext.Question.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<long> GetByLevel(int level)
        {
            return _dbContext.Question.AsNoTracking().Where(x => x.Level == level).Select(arg => arg.Id).ToArray();
        }
    }
}
