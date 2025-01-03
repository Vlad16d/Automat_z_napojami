using System;

namespace Automat_z_napojami
{
    public class Transaction
    {
        public string ProductName { get; }
        public double Price { get; }
        public DateTime Date { get; }

        public Transaction(string productName, double price)
        {
            ProductName = productName;
            Price = price;
            Date = DateTime.Now;
        }

        public void DisplayTransaction()
        {
            Console.WriteLine($"Produkt: {ProductName}, Cena: {Price:F2} PLN, Data: {Date}");
        }
    }
}
