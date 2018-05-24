using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smartman.Models;

namespace Smartman.Repository
{
    public class UserRepository : AbstractRepository<UserModel, long>
    {
        protected UserRepository(SmartmanDbContext context) : base(context)
        {
        }

        public override IEnumerable<UserModel> Get()
        {
            return _dbContext.User.AsNoTracking().ToArray();
        }

        public override UserModel GetById(long id)
        {
            return _dbContext.User.AsTracking().FirstOrDefault(x => x.Id==id);
        }
    }
}