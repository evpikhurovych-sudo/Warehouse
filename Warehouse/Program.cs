using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Попередньо створені склади
        List<Warehouse> warehouses = new List<Warehouse>
        {
            new Warehouse("AlphaDepot", "Kyiv", 2000, 1500, WarehouseType.Central),
            new Warehouse("EastHold", "Lviv", 1200, 800, WarehouseType.Regional),
            new Warehouse("TempStore", "Odessa", 300, 50, WarehouseType.Temporary)
        };

        int choice;
        do
        {
            Console.WriteLine("\n=== МЕНЮ ===");
            Console.WriteLine("1 – Переглянути всі склади");
            Console.WriteLine("2 – Знайти склад за назвою");
            Console.WriteLine("3 – Продемонструвати поведінку (додати/відвантажити вантаж)");
            Console.WriteLine("4 – Видалити склад");
            Console.WriteLine("0 – Вийти");

            Console.Write("Ваш вибір: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (warehouses.Count == 0) Console.WriteLine("Список складів порожній.");
                    else
                    {
                        for (int i = 0; i < warehouses.Count; i++)
                            Console.WriteLine($"{i + 1}. {warehouses[i].GetInfo()}");
                    }
                    break;

                case 2:
                    Console.Write("Назва для пошуку: ");
                    string name = Console.ReadLine();
                    bool found = false;
                    foreach (var w in warehouses)
                        if (w.GetInfo().Contains(name))
                        {
                            Console.WriteLine(w.GetInfo());
                            found = true;
                        }
                    if (!found) Console.WriteLine("Склад не знайдено.");
                    break;

                case 3:
                    Console.Write("Оберіть номер складу: ");
                    int idx;
                    if (int.TryParse(Console.ReadLine(), out idx) && idx > 0 && idx <= warehouses.Count)
                    {
                        Console.WriteLine(" 1 – Додати вантаж\n 2 – Відвантажити вантаж");
                        int mode = int.Parse(Console.ReadLine());
                        Console.Write(" Кількість палет: ");
                        int amount = int.Parse(Console.ReadLine());
                        if (mode == 1) warehouses[idx - 1].AddCargo(amount);
                        else if (mode == 2) warehouses[idx - 1].RemoveCargo(amount);
                    }
                    else Console.WriteLine("Некоректний номер складу.");
                    break;

                case 4:
                    Console.Write("Номер складу для видалення: ");
                    if (int.TryParse(Console.ReadLine(), out int delIdx) && delIdx > 0 && delIdx <= warehouses.Count)
                    {
                        warehouses.RemoveAt(delIdx - 1);
                        Console.WriteLine("Склад видалено.");
                    }
                    else Console.WriteLine("Некоректний номер.");
                    break;

                case 0:
                    Console.WriteLine("Програма завершена.");
                    break;

                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        } while (choice != 0);
    }
}
