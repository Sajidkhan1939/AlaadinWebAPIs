using AlaadinWebAPIs.Models;
using InventoryApi;

namespace AlaadinWebAPIs.Repositories
{
    public class RoleRepo: IRole
    {
        private readonly Aladin_prp_dbContext _aladin_Prp_DbContext;
        public RoleRepo(Aladin_prp_dbContext aladin_Prp_DbContext)
        {
            _aladin_Prp_DbContext = aladin_Prp_DbContext;
        }
        public Result Add(Role objAdd)
        {
            _aladin_Prp_DbContext.Roles.Add(objAdd);
            return new Result { Message="added successfully"};
        }

        public Result Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Result GetAll()
        {
            IList<Role> roles = _aladin_Prp_DbContext.Roles.ToList();
            return new Result { Status=true };
        }

        public Result ReadByGunsId(string Id)
        {
            throw new NotImplementedException();
        }

        public Result Update(Role objAdd, string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
