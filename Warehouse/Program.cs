using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Початкові склади
        List<Warehouse> warehouses = new List<Warehouse>
        {
            new Warehouse("AlphaDepot", "Київ", 1500, 800, WarehouseType.Central),
            new Warehouse("EastHold", "Львів", 1000, 400, WarehouseType.Regional),
            new Warehouse("TempStore", "Одеса", 500, 200, WarehouseType.Temporary)
        };

        int choice;
        do
        {
            Console.WriteLine("\n===== МЕНЮ =====");
            Console.WriteLine("1 – Додати склад");
            Console.WriteLine("2 – Переглянути всі склади");
            Console.WriteLine("3 – Знайти склад");
            Console.WriteLine("4 – Продемонструвати поведінку");
            Console.WriteLine("5 – Видалити склад");
            Console.WriteLine("6 – Продемонструвати static-методи (Parse/TryParse)");
            Console.WriteLine("0 – Вийти з програми");
            Console.Write("Ваш вибір: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("❌ Неправильне введення!");
                continue;
            }

            switch (choice)
            {
                case 1: // ✅ Додавання складу
                    Console.Write("Введіть місто: ");
                    string location = Console.ReadLine();

                    Console.Write("Введіть назву складу: ");
                    string name = Console.ReadLine();

                    Console.Write("Введіть максимальну місткість (т): ");
                    int capacity;
                    while (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
                        Console.Write("❌ Введіть правильне число (>0): ");

                    Console.Write("Введіть поточне завантаження (т): ");
                    int currentLoad;
                    while (!int.TryParse(Console.ReadLine(), out currentLoad) || currentLoad < 0 || currentLoad > capacity)
                        Console.Write("❌ Введіть правильне число (0 <= завантаження <= місткість): ");

                    Console.WriteLine("Оберіть тип складу:");
                    Console.WriteLine("0 – Центральний");
                    Console.WriteLine("1 – Регіональний");
                    Console.WriteLine("2 – Тимчасовий");

                    int typeChoice;
                    while (!int.TryParse(Console.ReadLine(), out typeChoice) || typeChoice < 0 || typeChoice > 2)
                        Console.Write("❌ Введіть 0, 1 або 2: ");

                    WarehouseType type = (WarehouseType)typeChoice;

                    Warehouse newWarehouse = new Warehouse(name, location, capacity, currentLoad, type);
                    warehouses.Add(newWarehouse);

                    Console.WriteLine("✅ Склад успішно додано!");
                    break;

                case 2: // Переглянути
                    if (warehouses.Count == 0)
                        Console.WriteLine("Список порожній.");
                    else
                        foreach (var wh in warehouses) Console.WriteLine(wh);
                    break;

                case 3: // Знайти
                    Console.Write("Введіть назву складу: ");
                    string search = Console.ReadLine();
                    Warehouse found = warehouses.Find(x => x.Name == search);
                    Console.WriteLine(found != null ? found.ToString() : "❌ Не знайдено.");
                    break;

                case 4: // Продемонструвати поведінку
                    if (warehouses.Count == 0) { Console.WriteLine("Немає складів."); break; }
                    warehouses[0].AddCargo(100);
                    warehouses[0].RemoveCargo(50);
                    Console.WriteLine(warehouses[0]);
                    break;

                case 5: // Видалити
                    Console.Write("Введіть назву складу для видалення: ");
                    string del = Console.ReadLine();
                    warehouses.RemoveAll(x => x.Name == del);
                    Console.WriteLine("✅ Видалено (якщо був).");
                    break;

                case 6: // Static-методи
                    string test = "WestDepot;Dnipro;1200;300;Regional";
                    Console.WriteLine($"\nСпроба Parse для рядка: {test}");
                    try
                    {
                        Warehouse parsed = Warehouse.Parse(test);
                        Console.WriteLine("✅ Parse успішний: " + parsed);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("❌ Parse помилка: " + ex.Message);
                    }

                    Console.WriteLine("\nСпроба TryParse (невірний рядок):");
                    if (Warehouse.TryParse("WrongDataString", out Warehouse bad))
                        Console.WriteLine("✅ Успіх: " + bad);
                    else
                        Console.WriteLine("❌ TryParse не зміг перетворити.");
                    break;

                case 0:
                    Console.WriteLine("Вихід...");
                    break;

                default:
                    Console.WriteLine("❌ Невірний пункт меню.");
                    break;
            }

        } while (choice != 0);
    }
}