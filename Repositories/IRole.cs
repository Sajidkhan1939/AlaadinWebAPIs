using AlaadinWebAPIs.Models;
using InventoryApi;

namespace AlaadinWebAPIs.Repositories
{
    public interface IRole
    {
         List<Role> GetAll();
        Result Add(Role objAdd);
        Result Update(Role role, string id);
        Result ReadById(string Id);
        Result Delete(string Id);
    }
}
