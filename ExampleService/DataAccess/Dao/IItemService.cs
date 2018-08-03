using System;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public interface IItemService : IDisposable
    {
        Task CreateItemAsync(ulong itemId, string itemName);
        Task<Models.Item> GetItemAsync(ulong itemId);
        Task DeleteItemAsync(ulong itemId);
    }
}
