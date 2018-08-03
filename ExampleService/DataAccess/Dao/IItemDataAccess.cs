using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public interface IItemDataAccess
    {
        Task CreateItemAsync(ulong itemId, string itemName);
        Task<Models.Item> GetItemAsync(ulong itemId);
        Task DeleteItemAsync(ulong itemId);

    }
}
