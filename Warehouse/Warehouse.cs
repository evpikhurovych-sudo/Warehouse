using System;

class Warehouse
{
    private string name;
    private string location;
    private int capacity;
    private int used;
    private WarehouseType type;

    public Warehouse(string name, string location, int capacity, int used, WarehouseType type)
    {
        SetName(name);
        SetLocation(location);
        SetCapacity(capacity);
        SetUsed(used);
        this.type = type;
    }

    public void SetName(string name)
    {
        if (name.Length >= 3 && name.Length <= 20) this.name = name;
        else throw new ArgumentException("Назва складу повинна бути від 3 до 20 символів.");
    }

    public void SetLocation(string location)
    {
        if (location.Length >= 2) this.location = location;
        else throw new ArgumentException("Місто повинно містити щонайменше 2 символи.");
    }

    public void SetCapacity(int capacity)
    {
        if (capacity > 0 && capacity <= 5000) this.capacity = capacity;
        else throw new ArgumentException("Місткість повинна бути в межах 1–5000.");
    }

    public void SetUsed(int used)
    {
        if (used >= 0 && used <= capacity) this.used = used;
        else throw new ArgumentException("Зайнятість повинна бути в межах 0–місткість.");
    }

    public string GetInfo()
    {
        return $"Назва: {name}, Місто: {location}, Місткість: {capacity}, Зайнято: {used}, Тип: {type}";
    }

    public void AddCargo(int amount)
    {
        if (used + amount <= capacity)
        {
            used += amount;
            Console.WriteLine($"  → Додано {amount} палет: тепер {used}/{capacity}.");
        }
        else
        {
            Console.WriteLine("  → Недостатньо місця для додавання вантажу.");
        }
    }

    public void RemoveCargo(int amount)
    {
        if (used - amount >= 0)
        {
            used -= amount;
            Console.WriteLine($"  → Відвантажено {amount} палет: тепер {used}/{capacity}.");
        }
        else
        {
            Console.WriteLine("  → Неможливо відвантажити таку кількість палет.");
        }
    }
}
