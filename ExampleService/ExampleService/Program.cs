using System;
using System.Collections.Generic;

namespace ExampleService
{
    class Program
    {
        static void Main(string[] args)
        {
            Models.Item item = new Models.Item();
            ItemProcessor processor = new ItemProcessor();
            Models.Item item2 = processor.Process(item);
            Console.WriteLine($"OG: {item.ItemValue}");
            Console.WriteLine($"NG: {item2.ItemValue}");
            ItemIncrementer incrementer = new ItemIncrementer();
            //incrementer.OnReceived += new ItemIncrementer.dgRaiseEvent
            IReadOnlyCollection<string> readonlyCollection = new List<string>();
            
            Console.ReadKey();
        }
    }

    class ItemIncrementer
    {
        public delegate void dgRaiseEvent();
        public event dgRaiseEvent OnReceived;

        public Models.Item Increment(Models.Item item)
        {
            return new Models.Item(item.ItemId, item.ItemName, item.Created, item.ItemValue + 1);
        }
    }

    class ItemProcessor : ProcessorBase<Models.Item>
    {
        public new Models.Item Process(Models.Item item)
        {
            return new Models.Item(item.ItemId, item.ItemName, item.Created, item.ItemValue + 1);
        }

    }

    public abstract class ProcessorBase<T> : IProcessor<T>
    {
        public virtual T Process(T item)
        {
            Console.WriteLine($"{item.GetType()} Item processed.");
            return item;
        }
    }
        

    interface IProcessor<T>
    {
        T Process(T item);
    }


    interface INode
    {
        INode Next();
    }





    
}