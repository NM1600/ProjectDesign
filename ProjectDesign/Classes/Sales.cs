using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDesign.Classes
{
    public class Sales
    {
        int receiptId;
        DateTime transDate;
        string customerName;
        int productId;
        string productName;
        decimal price;
        int quantity;
        decimal totalAmount;
        decimal amountPaid;

        public int ReceiptId { get => receiptId; set => receiptId = value; }
        public DateTime TransDate { get => transDate; set => transDate = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public decimal Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
        public decimal AmountPaid { get => amountPaid; set => amountPaid = value; }
    }
}
