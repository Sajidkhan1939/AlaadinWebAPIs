using AlaadinWebAPIs.Models;
using InventoryApi.Model;

namespace InventoryApi.Repositories
{
    public interface IUserRepository
    {
        Result Register(User objRegister);
        Result Update(User objRegister, string Id);
        Result ReadByUserId(string userId);
        Result Login(string username, string password);
    }
}
