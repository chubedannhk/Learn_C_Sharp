//class Program
//{
//    static void Main(string[] args)
//    {
//        List<int> list = new List<int>();

//        list.Add(1);
//        list.Add(2);
//        list.AddRange(new int[] { 1, 2, 3 });
//        list.Insert(0, 3);
//        list.RemoveAt(0);
//        list.Remove(1);
//        //Console.WriteLine(list[2]);
//        foreach(var i in list)
//        {
//            Console.WriteLine(i);
//        }
//    }
//}

/// 
class Program
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
    static void Main(string[] args)
    {
    //    List<Product> products = new List<Product>() {
    //   new Product()
    //    {
    //        Id = 1,
    //        Name = "Test",
    //        Description = "Test",
    //        Category = "Test"
    //    },
    //    new Product()
    //    {
    //        Id = 2,
    //        Name = "dfds",
    //        Description = "Test",
    //        Category = "Test"
    //    }
    //};
    //    // tim kiem find hoac findAll
    //    var pro = products.Find(x => x.Id == 2);
    //    Console.WriteLine($"{ pro.Name}");
    //    //foreach (var product in products )
    //    //{
    //    //    Console.WriteLine();
    //    //}

        //====

        SortedList<string, Product> products = new SortedList<string, Product>();
        products["sp1"] = new Product { Id = 1,Name="dsfjls",Description="nguyenhoang",Category="Category"};
        products["sp2"] = new Product { Id = 3, Name = "dsfjfsdfsdls", Description = "ngufsdyenhoang", Category = "Casdtegory" };
        products.Add("sp3", new Product { Id = 4,Name="dfd",Description="dsfd",Category = "Category"});
        var keys = products.Keys;
        var values = products.Values;
        foreach (var item in keys)
        {
            var pro = products[item];
            Console.WriteLine(pro.Name);
        }
    }
}
