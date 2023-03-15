class Program
{
    static void Main(string[] args)
    {
        int a = 3;
        int b = 0;
        try
        {
            // cac lenh
            var c = a / b;
            Console.WriteLine(c);
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            Console.WriteLine(e.GetType().Name);
      
               
            Console.WriteLine("phep chi co loi");
        }
        Console.WriteLine("ket thuc chuong trinh");
    }
}

// neu muon biet them coi o youtube xuanthulab bai 25