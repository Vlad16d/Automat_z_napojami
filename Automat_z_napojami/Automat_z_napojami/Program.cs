using Automat_z_napojami;
using System;

class Program
{
    static void Main(string[] args)
    {
        VendingMachine vendingMachine = new VendingMachine();
        Admin admin = new Admin(vendingMachine);
        User user = new User(vendingMachine);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Tryb użytkownika");
            Console.WriteLine("2. Menu administracyjne");
            Console.WriteLine("0. Wyjście");
            Console.Write("Twój wybór: ");

            if (!int.TryParse(Console.ReadLine(), out int mode) || mode < 0 || mode > 2)
            {
                Console.WriteLine("Nieprawidłowy wybór! Naciśnij dowolny klawisz, aby spróbować ponownie.");
                Console.ReadKey();
                continue;
            }

            if (mode == 0) break;
            if (mode == 1) UserMode(user);
            if (mode == 2) AdminMenu(admin);
        }
    }
    static void UserMode(User user)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wybierz numer produktu:");

            user.DisplayProducts(); 

            Console.WriteLine("0. Powrót do menu głównego");
            Console.Write("Twój wybór: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0)
            {
                Console.WriteLine("Nieprawidłowy wybór!");
                Console.ReadKey();
                continue;
            }

            if (choice == 0) break;

            Console.Write("Wprowadź kwotę: ");
            if (!double.TryParse(Console.ReadLine(), out double money) || money < 0)
            {
                Console.WriteLine("Nieprawidłowa kwota!");
                Console.ReadKey();
                continue;
            }

            try
            {
                user.BuyProduct(choice - 1, money); 
                Console.WriteLine("\nDziękujemy za skorzystanie z automatu! Miłego dnia!");
                Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nBłąd: {ex.Message}");
                Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
            }
        }
    }

    static void AdminMenu(Admin admin)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu administracyjne:");
            Console.WriteLine("1. Wyświetl listę produktów");
            Console.WriteLine("2. Dodaj nowy produkt");
            Console.WriteLine("3. Usuń produkt");
            Console.WriteLine("4. Edytuj produkt");
            Console.WriteLine("5. Wyświetl listę transakcji");
            Console.WriteLine("0. Powrót do menu głównego");
            Console.Write("Twój wybór: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 5)
            {
                Console.WriteLine("Nieprawidłowy wybór!");
                Console.ReadKey();
                continue;
            }

            if (choice == 0) break;

            switch (choice)
            {
                case 1:
                    admin.ManageProducts();
                    break;
                case 2:
                    Console.Write("Podaj nazwę nowego produktu: ");
                    string name = Console.ReadLine();
                    Console.Write("Podaj cenę nowego produktu: ");
                    if (!double.TryParse(Console.ReadLine(), out double price) || price < 0)
                    {
                        Console.WriteLine("Nieprawidłowa cena!");
                    }
                    else
                    {
                        admin.AddProduct(name, price);
                    }
                    break;
                case 3:
                    admin.ManageProducts();
                    Console.Write("Wybierz numer produktu do usunięcia: ");
                    if (!int.TryParse(Console.ReadLine(), out int removeIndex) || removeIndex <= 0)
                    {
                        Console.WriteLine("Nieprawidłowy wybór!");
                    }
                    else
                    {
                        admin.RemoveProduct(removeIndex - 1);
                    }
                    break;
                case 4:
                    admin.ManageProducts();
                    Console.Write("Wybierz numer produktu do edycji: ");
                    if (!int.TryParse(Console.ReadLine(), out int editIndex) || editIndex <= 0)
                    {
                        Console.WriteLine("Nieprawidłowy wybór!");
                    }
                    else
                    {
                        Console.Write("Podaj nową nazwę produktu: ");
                        string newName = Console.ReadLine();
                        Console.Write("Podaj nową cenę produktu: ");
                        if (!double.TryParse(Console.ReadLine(), out double newPrice) || newPrice < 0)
                        {
                            Console.WriteLine("Nieprawidłowa cena!");
                        }
                        else
                        {
                            admin.EditProduct(editIndex - 1, newName, newPrice);
                        }
                    }
                    break;
                case 5:
                    admin.ViewTransactions();
                    break;
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
    }

}
