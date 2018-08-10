using System;

namespace ExampleService.Models
{
    public class Item
    {
        public ulong ItemId { get; }
        public string ItemName { get; }
        public int ItemValue { get; }
        public DateTime Created { get; }

        public Item(ulong itemId, string itemName, DateTime created, int value)
        {
            this.ItemId = itemId;
            this.ItemName = itemName;
            this.Created = created;
            this.ItemValue = value;
        }

        public Item()
        {
            ItemId = 55;
            ItemName = "item";
            ItemValue = 1;
            Created = DateTime.Now;
        }
    }
}
