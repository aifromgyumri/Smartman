using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smartman.Models;

namespace Smartman.Repository
{
    public class UserRepository : AbstractRepository<UserModel, long>
    {
        public UserRepository(SmartmanDbContext context) : base(context)
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

        public bool FindByEmailandLoginandPhone(string email, string login, string phone)
        {
            return _dbContext.User.AsNoTracking().Any(x => x.Email == email || x.Login == login || x.Phone == phone);
        }

        public UserModel TestByEmailAndHashedPassword(string email, string password)
        {
            return _dbContext.User.AsNoTracking().FirstOrDefault(x => x.Email==email && x.Password==password);
        }
    }
}