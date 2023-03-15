//int[] arr = { 1, 21, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
//int max = arr.Max();
//Console.WriteLine($"Max is {max}");


// extension method
// tao lop tinhx
static class abc
{
    public static void Print(this string s, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(s);
    }
}
class Program
{
    

    static void Main(string[] args)
    {
        "Xin".Print(ConsoleColor.Red);
        "chao".Print(ConsoleColor.Blue);
        "cac".Print(ConsoleColor.Yellow);
        "ban".Print(ConsoleColor.Green);
    }
}
