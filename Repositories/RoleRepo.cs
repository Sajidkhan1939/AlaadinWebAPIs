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
            try
            {
                if (_aladin_Prp_DbContext.Roles==null)
                {
                    return new Result { Status = false, Message = "Role data is null" };
                }
                 _aladin_Prp_DbContext.Roles.Add(objAdd);
                _aladin_Prp_DbContext.SaveChanges();
                    return new Result { Status = true, Message = "Role added Succesfully" };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public Result Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public  List<Role> GetAll()
        {
            List<Role> rolelist;
            try
            {
                rolelist = _aladin_Prp_DbContext.Set<Role>().ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex);
            }
            return rolelist;
        }

        public Result ReadById(string Id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Id))
                {
                  
                    Role role = _aladin_Prp_DbContext.Find<Role>(Id);
                    return new Result
                    {
                        Message = "Success",
                        Status = true,
                        Data = role
                    };
                }
                else
                {
                    return new Result
                    { Status = false, Message = "id require" };
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex);
            }
        }

        public Result Update(Role role, string id)
        {

            try
            {
                if(id != role.Id)
                {
                    return new Result { Message="Id is not valid",Status = false,Data=role };
                }
                else 
                {
                   //var update = _aladin_Prp_DbContext.Roles.Update(s=>s.ti)
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new Result { Message = "Id is not valid", Status = false, Data = role };
        }
        private bool RoleExists(string id)
        {
            return (_aladin_Prp_DbContext?.Roles.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
