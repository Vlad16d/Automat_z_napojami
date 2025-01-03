using System;

namespace Automat_z_napojami
{
    public class Admin
    {
        private VendingMachine vendingMachine;

        public Admin(VendingMachine machine)
        {
            vendingMachine = machine;
        }

        public void ManageProducts()
        {
            Console.WriteLine("Wyświetlam listę produktów:");
            vendingMachine.DisplayProducts();
        }

        public void AddProduct(string name, double price)
        {
            vendingMachine.AddProduct(new Drink(name, price));
        }

        public void RemoveProduct(int index)
        {
            vendingMachine.RemoveProduct(index);
        }

        public void EditProduct(int index, string newName, double newPrice)
        {
            vendingMachine.EditProduct(index, newName, newPrice);
        }

        public void ViewTransactions()
        {
            vendingMachine.DisplayTransactions();
        }
    }
}
