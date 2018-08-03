using System;
using System.Threading.Tasks;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data.Common;


namespace DataAccess.Dao
{
    public class ItemService : DataAccessBase, IItemService
    {
        private const string CreateItemProcedureName = "create_item";
        private const string GetItemProcedureName = "get_user";
        private const string DeleteItemProcedureName = "delete_item";

        private const string ItemIdParameterName = "@itemId";
        private const string ItemNameParameterName = "@itemName";

        private const string ItemIDColumnName = "itemid";
        private const string ItemNameColumnName = "itemname";
        private const string ItemCreatedColumnName = "created";

        public ItemService(string connectionString) : base(connectionString)
        {

        }

        public async Task CreateItemAsync(ulong itemId, string itemName)
        {
            MySqlCommand cmd = CreateStoredProcedureCommand(CreateItemProcedureName);

            cmd.Parameters.Add(CreateInputParameter(ItemIdParameterName, MySqlDbType.UInt64, itemId));
            cmd.Parameters.Add(CreateInputParameter(ItemNameParameterName, MySqlDbType.VarString, itemName));

            await cmd.ExecuteNonQueryAsync();

        }


        public async Task<Models.Item> GetItemAsync(ulong itemId)
        {
            Models.Item item = null;

            MySqlCommand cmd = CreateStoredProcedureCommand(GetItemProcedureName);

            cmd.Parameters.Add(CreateInputParameter(ItemIdParameterName, MySqlDbType.UInt64, itemId));

            using (DbDataReader reader = await cmd.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    ulong _itemId = Convert.ToUInt64(reader[ItemIDColumnName]);
                    string itemName = Convert.ToString(reader[ItemNameColumnName]);
                    DateTime created = Convert.ToDateTime(reader[ItemCreatedColumnName]);

                    item = new Models.Item(_itemId, itemName, created);

                }
            }

            return item;
        }

        public async Task DeleteItemAsync(ulong itemId)
        {
            MySqlCommand cmd = CreateStoredProcedureCommand(DeleteItemProcedureName);

            cmd.Parameters.Add(CreateInputParameter(ItemIdParameterName, MySqlDbType.UInt64, itemId));

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
