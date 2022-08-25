using AlaadinWebAPIs.Models;
using InventoryApi;

namespace AlaadinWebAPIs.Repositories
{
    public interface IRole
    {
         List<Role> GetAll();
        Result Add(Role objAdd);
        Result Update(Role objAdd, string UserId);
        Result ReadById(string Id);
        Result Delete(string Id);
    }
}
