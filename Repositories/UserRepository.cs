using AlaadinWebAPIs.Models;
using InventoryApi;
using InventoryApi.Repositories;

namespace AlaadinWebAPIs.Repositories
{
    public class UserRepository:IUserRepository
    {
        private Aladin_prp_dbContext _context;
        public UserRepository(Aladin_prp_dbContext context)
        {
            _context= context;
        }

        public Result Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Result ReadByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Result Register(User objRegister)
        {
            var user = _context.Users.Add(objRegister);
            throw new NotImplementedException();
        }

        public Result Update(User objRegister, string Id)
        {
            throw new NotImplementedException();
        }
    }
 
}
