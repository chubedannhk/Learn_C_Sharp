// phuong thuc tinh, du lieu chi doc, qua tai toan tu va indexer trong .net
class CountNumber
{
    public static int number = 0;
    public static void Info()
    {
        Console.WriteLine("so lan truy cap "+number);
    }
    public void Count()
    {
        CountNumber.number++;

    }
}
class Program
{
    static void Main(string[] args)
    {
        //CountNumber.Info();
        //Console.WriteLine(CountNumber.number);
        CountNumber c1 = new CountNumber();
        CountNumber c2 = new CountNumber();
        c1.Count();
        c2.Count();
        CountNumber.Info();
    }
}