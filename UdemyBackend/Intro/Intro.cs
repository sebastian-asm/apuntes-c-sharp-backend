using System.Text.Json;

var sale = new Sale(123);
var message = sale.GetInfo();
Console.WriteLine(message);

var sale2 = new SaleWithTax(321, 1.21m);
Console.WriteLine(sale2.GetInfo());

var numbers = new MyList<int>(5);
var names = new MyList<string>(5);

numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);
Console.WriteLine(numbers.GetContent());

// LINQ: trabajar con colecciones de manera declarativa
var names2 = new List<string>()
{
    "Belu", "Valen", "Ramsito", "Seba"
};
var nameResult = from name in names2
                 orderby name
                 select name;

Console.WriteLine("*****");
foreach (var name in nameResult)
{
    Console.WriteLine(name);
}
Console.WriteLine("*****");

// Serialización (JSON)
// Llenar las propiedades sin necesidad de un constructor
var people = new People()
{
    Name = "Belu",
    Age = 20
};

string json = JsonSerializer.Serialize(people);
Console.WriteLine(json);
string json2 = @"{""Name"": ""Seba"", ""Age"": 21}";
People? people2 = JsonSerializer.Deserialize<People>(json2);
Console.WriteLine($"Nombre: {people2?.Name}, edad: {people2?.Age}");

public class People
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// Interface
interface ISale
{
    public decimal Total { get; set; }
}

interface ISave
{
    public void Save();
}

class Sale : ISale, ISave
{
    public decimal Total { get; set; }

    public Sale(decimal total)
    {
        Total = total;
    }

    // Virtual indica que el método puede ser sobreescrito en sus clases hijas
    public virtual string GetInfo()
    {
        return $"El total es: ${Total}";
    }

    public void Save()
    {
        Console.WriteLine("Se guardo en la DB");
    }
}

// Herencia
class SaleWithTax : Sale
{
    public decimal Tax { get; set; }

    public SaleWithTax(decimal total, decimal tax) : base(total)
    {
        Tax = tax;
    }

    public override string GetInfo()
    {
        return $"El total es: ${Total}, y el impuesto es de {Tax}%";
    }
}

// Genéricos
public class MyList<T>
{
    private List<T> _list;
    private int _limit;

    public MyList(int limit)
    {
        _limit = limit;
        _list = new List<T>();
    }

    public void Add(T item)
    {
        if (_list.Count < _limit)
        {
            _list.Add(item);
        }
    }

    public string GetContent()
    {
        string content = "";
        foreach (var item in _list)
        {
            content += item + ", ";
        }
        return content;
    }
}