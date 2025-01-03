using System;
using System.Collections.Generic;

namespace Automat_z_napojami
{
    public class VendingMachine
    {
        private List<Product> products = new List<Product>();
        private List<Transaction> transactions = new List<Transaction>();

        public VendingMachine()
        {
            // napoje standardowe (beda zawsze po uruchomeniu programu)
            products.Add(new Drink("Coca Cola", 3.43));
            products.Add(new Drink("Pepsi Cola", 3.49));
            products.Add(new Drink("fanta", 3.33));
            products.Add(new Drink("Dr. Pepper", 3.0));
            products.Add(new Drink("Lipton", 3.75));
            products.Add(new Drink("Energetyk Monster", 3.99));
            products.Add(new Drink("Sprite", 2.89));
            products.Add(new Drink("7up", 4.0));
            products.Add(new Drink("Mirinda", 3.99));
            products.Add(new Drink("woda Rzeszowianka", 2.08));
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Dostępne produkty:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price:F2} PLN");
            }
        }

        public void BuyProduct(int index, double money)
        {
            if (index < 0 || index >= products.Count)
                throw new ArgumentException("Nieprawidłowy numer produktu.");

            Product product = products[index];
            if (money < product.Price)
                throw new InvalidOperationException("Za mało środków!");

            double change = money - product.Price;
            Console.WriteLine($"Kupiony produkt: {product.Name}");
            Console.WriteLine($"Twoja reszta: {change:F2} PLN");

            transactions.Add(new Transaction(product.Name, product.Price));
        }

        public void DisplayTransactions()
        {
            Console.WriteLine("Lista transakcji:");
            foreach (var transaction in transactions)
            {
                transaction.DisplayTransaction();
            }
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Produkt został dodany.");
        }

        public void RemoveProduct(int index)
        {
            if (index < 0 || index >= products.Count)
            {
                Console.WriteLine("Nieprawidłowy numer produktu!");
                return;
            }
            products.RemoveAt(index);
            Console.WriteLine("Produkt został usunięty.");
        }

        public void EditProduct(int index, string newName, double newPrice)
        {
            if (index < 0 || index >= products.Count)
            {
                Console.WriteLine("Nieprawidłowy numer produktu!");
                return;
            }
            products[index].Name = newName;
            products[index].Price = newPrice;
            Console.WriteLine("Produkt został zaktualizowany.");
        }
    }
}
