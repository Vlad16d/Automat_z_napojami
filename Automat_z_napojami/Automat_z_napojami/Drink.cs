namespace Automat_z_napojami
{
    public class Drink : Product
    {
        public Drink(string name, double price) : base(name, price) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Napój: {Name}, Cena: {Price:F2} PLN");
        }
    }
}
