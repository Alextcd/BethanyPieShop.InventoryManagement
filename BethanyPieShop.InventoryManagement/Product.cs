using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.InventoryManagement
{
    internal class Product
    {
        private int id;
        private string name = string.Empty;
        private string? description;

        private int maxItemsInStock = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value.Length > 50 ? value[..50] : value;
            }
        }

        public string? Description
        {
            get { return description; }
            set
            {
                if(value == null)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.Length > 250 ? value[..250] : value;
                }
            }
        }

        public UnitType UnitiType { get; set; }
        public int AmountInStock { get; private set; }
        public bool IsBelowStockThreshold { get; private set; }

        public void UseProduct(int items)
        {
            if(items <= AmountInStock)
            {
                //use the items
                AmountInStock -= items;
                UpdateLowStock();

                Log($"Amount in stock updated. Now {AmountInStock} items in stock");
            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()} . {AmountInStock} avaible but" +
                    $"{items} required.");
            }
        }

        public void IncreaseStock()
        {
            AmountInStock++;
        }

        private void DecreaseStock(int items, string reason)
        {
            if(items <= AmountInStock)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }

            UpdateLowStock();

            Log(reason);
        }

        private void UpdateLowStock()
        {
            if(AmountInStock < 10)
            {
                IsBelowStockThreshold = true;
            }
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {Id} ({Name})";
        }

        public string DisplayDetailsFull()
        {
            StringBuilder sb = new();

            sb.Append($"{Id} {Name} \n {Description}\n{AmountInStock} item(s) in stock.");

            if (IsBelowStockThreshold) sb.Append($"\n!!STOCK LOW!!");

            return sb.ToString();
        }
    }
}
