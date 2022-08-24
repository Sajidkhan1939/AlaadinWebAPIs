using AlaadinWebAPIs.Models;
using InventoryApi;

namespace AlaadinWebAPIs.Repositories
{
    public interface IRole
    {
        Result GetAll();
        Result Add(Role objAdd, string UserId);
        Result Update(Role objAdd, string UserId);
        Result ReadByGunsId(string Id);
        Result Delete(string Id);
    }
}
