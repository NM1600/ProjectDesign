using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDesign.Classes
{
    public class Products
    {
        int productId;
        string productName;
        int quantity;
        decimal cost;
        decimal price;

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal Cost { get => cost; set => cost = value; }
        public decimal Price { get => price; set => price = value; }
    }
}
