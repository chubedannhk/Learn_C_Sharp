// tính kế thừa trong c sharp

/* 
 * tính kế thừa A, B
 * B kế thừa A
 * A - cơ sở, cha
 * B - kế thừa , con
 
    Class B:A{}
 * */

using System.Text;


// sealed: không cho phép kế thừa, nếu 1 class nào cố tình muốn kế thừa sẽ bị lỗi
//sealed class Aminal { }

class Aminal
{
    public int Legs { set; get; }
    public int Weight { set; get; }
    
    public void ShowLop()
    {
        Console.WriteLine($"Số chân: {Legs}");
    }
}
class Cat : Aminal
{
    public string Food;
    public Cat()
    {
        this.Legs = 4;
        this.Weight = 29;
        this.Food = "mouse";
    }
    
    public void Eat()
    {
        Console.WriteLine(Food);
    }
}

class Program
{

    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;
        Cat cat = new();
        cat.ShowLop();
        cat.Eat();
    }
}
