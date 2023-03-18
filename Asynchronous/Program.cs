class Program
{
    // asynchrnous (multi thread : chay da luong)
    static void DoSomeThing(int seconds, string mgs, ConsoleColor color)
    {
        // 1000mm = 1s
        for (int i = 1; i <= seconds; i++)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{mgs}, {i}");
            Console.ResetColor();
            Thread.Sleep(1000);

        }

    }
    static async Task Task1()
    {
        //Task t1 = new Task(Action);
        Task t1 = new Task(
            () =>
            {
                //lam cai gi do
                DoSomeThing(5, "nguyenhoangkhai", ConsoleColor.Green);
            });
        t1.Start();
        await t1;
        Console.WriteLine("Task 1 hoan thanh");
    }
    static async Task Task2()
    {
        //Task t2 = new Task(Action<Object>, Object); 

        Task t2 = new Task(
            (object obj) =>
            {
                string task = (string)obj;
                DoSomeThing(4, task, ConsoleColor.Blue);
            }, "Task2");
        t2.Start();
        await t2;
        Console.WriteLine("Task 2 hoan thanh");
    }
    static void Main(string[] args)
    {

        //Console.WriteLine("hello nguyen hoang khai");
        //DoSomeThing(5, "nguyenhoangkhai",ConsoleColor.Green);
        //Console.WriteLine("hello nguyen hoang khai");

        // synchronous (dong bo): don luong
        //DoSomeThing(5, "nguyenhoangkhai", ConsoleColor.Green);
        //DoSomeThing(5, "nguyenhoangkhai", ConsoleColor.Red);

        // asynchonous ( bat dong bo) : da luong
        //dung  Task
        Task t1 = Task1();
        Task t2 = Task2();
        DoSomeThing(5, "nguyenhoangkhai", ConsoleColor.Red);
    }
  
}