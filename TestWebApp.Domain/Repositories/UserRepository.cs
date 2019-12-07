using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Context;
using TestWebApp.Domain.Entities;
using TestWebApp.Domain.IRepositories;

namespace TestWebApp.Domain.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private EFDbContext context;
        public UserRepository()
        {
            context = new EFDbContext();
        }

        public int Add(User entity)
        {
            try {
                context.User.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }

            catch(Exception ex)
            {
                string erro=ex.Message;
                return -1;
            }
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }
        public User GetUser(string email)
        {
            return context.User.SingleOrDefault(x => x.Email.ToLower().Trim() == email.ToLower().Trim());
        }
        public List<User> GetAll()
        {
            List<User> usersList = new List<User>();
            if(context.User ==null)
                return new List<User>();
            usersList = context.User.ToList();
            return usersList;
        }

        bool IRepository<User>.Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
