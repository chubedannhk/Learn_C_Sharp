class Program
{
    static void Main(string[] args)
    {

        // Queue => vao trc ra truoc
        //Queue<string> queue = new Queue<string>();
        //queue.Enqueue("ho so 1");
        //queue.Enqueue("ho so 2");
        //queue.Enqueue("ho so 3");

        //foreach(var item in queue)
        //{
        //    Console.WriteLine(item);
        //}
        //// phan tu nao co truoc thi su ly trc
        //var hoso = queue.Dequeue();
        //Console.WriteLine($"Xu ly ho so: {hoso} ");
        //hoso = queue.Dequeue();
        //Console.WriteLine($"Xu ly ho so: {hoso} ");
        //hoso = queue.Dequeue();
        //Console.WriteLine($"Xu ly ho so: {hoso} ");

        // stack : nguoc lai vs Queue, cai nao vao trc thi xuong duoi, nao vao sau thi dc lay ra trc => vao sau thi ra trc
        //Stack<string> pro = new Stack<string>();
        //pro.Push("a");
        //pro.Push("b");
        //pro.Push("c");
        //pro.Push("d");

        //var mathang = pro.Pop();
        //Console.WriteLine($"Lay hang ra:{mathang}");

        // LinkedList => danh sach lien ket
        LinkedList<string> list = new LinkedList<string>();
        list.AddFirst("a");
        list.AddFirst("b");
        list.AddLast("c");
        foreach(var s in list)
        {
            Console.WriteLine(s);
        }
    }
}
