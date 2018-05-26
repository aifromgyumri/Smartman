using Microsoft.EntityFrameworkCore;
using Smartman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartman.Repository
{
    public class HistoryRepository : AbstractRepository<HistoryModel, long>
    {
        public HistoryRepository(SmartmanDbContext context) : base(context)
        {
        }

        public override IEnumerable<HistoryModel> Get()
        {
            return _dbContext.History.Include(x => x.User).Include(x => x.Question).AsNoTracking().ToArray();
        }

        public override HistoryModel GetById(long id)
        {
            return _dbContext.History.Include(x => x.User).Include(x => x.Question).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<long> GetAnsweredQuestionsIdByLevel(int level, long userId)
        {
            return _dbContext.History.Include(x => x.User).Include(x => x.Question)
                .AsNoTracking()
                .Where(x => x.Question != null && x.Question.Level == level)
                .Where(x => x.User != null && x.User.Id == userId)
                .Select(x => x.Question)
                .Select(x => x.Id)
                .ToArray();
        }
    }
}
