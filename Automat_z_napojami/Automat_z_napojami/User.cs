using System;

namespace Automat_z_napojami
{
    public class User
    {
        private VendingMachine vendingMachine;

        public User(VendingMachine machine)
        {
            vendingMachine = machine;
        }

        public void DisplayProducts()
        {
            vendingMachine.DisplayProducts();
        }

        public void BuyProduct(int index, double money)
        {
            vendingMachine.BuyProduct(index, money);
        }
    }
}
