// delegate (type) bien = phuong thuc

public delegate void ShowLog(string message);
class Program
{
    static void Info(string s)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(s);
        Console.ResetColor();
    }
    static void Warning(string s)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(s);
        Console.ResetColor();
    }
    static void Main(string[] args) {
        ShowLog log = null; // +=
      //  log = Info;
        log += Info;
        log += Warning;
        log?.Invoke("Nguyen Hoang Khai");
    }
}
