using System;

public class Warehouse
{
    private string name;
    private string location;
    private int capacity;
    private int currentLoad;
    private WarehouseType type;

 
    private static int objectCount = 0;

    // Властивості
    public string Name
    {
        get => name;
        set => name = !string.IsNullOrWhiteSpace(value) ? value : "NoName";
    }

    public string Location
    {
        get => location;
        set => location = !string.IsNullOrWhiteSpace(value) ? value : "Unknown";
    }

    public int Capacity
    {
        get => capacity;
        set => capacity = value > 0 ? value : 100;
    }

    public int CurrentLoad
    {
        get => currentLoad;
        set => currentLoad = (value >= 0 && value <= capacity) ? value : 0;
    }

    public WarehouseType Type
    {
        get => type;
        set => type = value;
    }

    public bool IsOverloaded => currentLoad > capacity;

    // Конструктори
    public Warehouse()
    {
        Name = "NoName";
        Location = "Unknown";
        Capacity = 100;
        CurrentLoad = 0;
        Type = WarehouseType.Temporary;
        objectCount++;
    }

    public Warehouse(string name, string location, int capacity)
    {
        Name = name;
        Location = location;
        Capacity = capacity;
        CurrentLoad = 0;
        Type = WarehouseType.Regional;
        objectCount++;
    }

    public Warehouse(string name, string location, int capacity, int currentLoad, WarehouseType type)
    {
        Name = name;
        Location = location;
        Capacity = capacity;
        CurrentLoad = currentLoad;
        Type = type;
        objectCount++;
    }

    // Методи
    public void AddCargo(int amount)
    {
        if (currentLoad + amount <= capacity)
            currentLoad += amount;
        else
            Console.WriteLine("⚠ Перевищено місткість складу!");
    }

    public void AddCargo() => AddCargo(100);

    public void RemoveCargo(int amount)
    {
        if (currentLoad - amount >= 0)
            currentLoad -= amount;
        else
            Console.WriteLine("⚠ Недостатньо вантажу на складі!");
    }

    public string GetInfo()
    {
        return $"Склад: {Name}, Місто: {Location}, Місткість: {Capacity}т, Завантажено: {CurrentLoad}т, Тип: {Type}";
    }

    //  Перевизначення ToString()
    public override string ToString()
    {
        return GetInfo();
    }

    //  Static методи
    public static Warehouse Parse(string s)
    {
        // Формат рядка: "Name;Location;Capacity;CurrentLoad;Type"
        var parts = s.Split(';');
        if (parts.Length != 5)
            throw new FormatException("❌ Невірний формат рядка для Parse!");

        return new Warehouse(
            parts[0],
            parts[1],
            int.Parse(parts[2]),
            int.Parse(parts[3]),
            Enum.Parse<WarehouseType>(parts[4])
        );
    }

    public static bool TryParse(string s, out Warehouse result)
    {
        try
        {
            result = Parse(s);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    public static int GetObjectCount()
    {
        return objectCount;
    }
}
