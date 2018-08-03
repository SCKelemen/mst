using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Item
    {
        public ulong ItemId { get; }
        public string ItemName { get; }
        public DateTime Created { get; }

        public Item (  ulong itemId, string itemName, DateTime created )
        {
            this.ItemId = itemId;
            this.ItemName = itemName;
            this.Created = created;
        }
    }
}
