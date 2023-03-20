// linq (language integrated query): ngon ngu triy van tich hop

using System.Linq;
using System.Threading.Channels;

class Program
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string[] Colors { get; set; }

        public int Brand { get; set; }
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            Id = id;
            Name = name;
            Price = price;
            Colors = colors;
            Brand = brand;
        }

        // lay chuoi thong tin san pham gon id, name, price,..
        public override string ToString()
        => $"{Id,5} {Name,5} {Price,5}{Brand,5}{string.Join(",", Colors)}";
    }
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    static void Main(string[] args)
    {

        var brands = new List<Brand>() {
        new Brand{Id = 1, Name = "Công ty AAA"},
        new Brand{Id = 2, Name = "Công ty BBB"},
        new Brand{Id = 4, Name = "Công ty CCC"},
        };

        var products = new List<Product>()
        {
             new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
             new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
             new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
             new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
             new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
             new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
             new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
        };

        // lay san pham gia 400
        //var query = from p in products where p.Price == 400 select p;
        //foreach(var item in query)
        //{
        //    Console.WriteLine(item);
        //}

        // select ============================
        //var result = products.Select(
        //    (p) =>
        //    {
        //        //return p.Name;
        //        return new
        //        {
        //            ten = p.Name,
        //            Gia = p.Price
        //        };
        //    });
        //foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}

        // where ===========================
        //var result = products.Where(
        //    (p) =>
        //    {
        //        //return p.Name.Contains("tr");
        //        return p.Price >= 200 & p.Price <= 300;
        //    }
        //    );

        // selectMany

        //var result = products.SelectMany(
        //    (p) =>
        //    {

        //        return p.Colors;
        //    }
        //    );

        // min, max, sum, avg
        //var result = products.Min(
        //    (p) =>
        //    {

        //        return p.Price;
        //    }
        //    );
        //Console.WriteLine(result);

        // Join
        //var result = products.Join(brands, p => p.Brand, b => b.Id, (p, b)=>{
        //    return new
        //    {
        //        Ten = p.Name,
        //        Thuonghieu = b.Name
        //    };
        //});
        //foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}

        // groupJoin
        //var result = brands.GroupJoin(products, b => b.Id, p => p.Brand, (b, p) =>
        //{
        //    return new
        //    {
        //        thuongHieu = b.Name,
        //        listSp = p
        //    };
        //});
        //foreach (var item in result)
        //{
        //    Console.WriteLine(item.thuongHieu);
        //    foreach (var item2 in item.listSp)
        //    {
        //        Console.WriteLine(item2);
        //    }
        //}


        // take => lay ra 1 so sp dau tien
        // products.Take(3).ToList().ForEach(p=> Console.WriteLine(p));

        //skip => luot qua mot so phan tu
        // products.Skip(3).ToList().ForEach(p => Console.WriteLine(p));

        // OrderBy (Tang dan) /OrderBydescending(giam dan)
        //products.OrderBy(p=> p.Price).ToList().ForEach(p=>Console.Write(p));

        // Reverse: dao nguoc 
        //products.Reverse();
        //products.ForEach(p => Console.Write(p));

        // GroupBy

        //var kq = products.GroupBy(p => p.Price);
        //foreach (var item in kq)
        //{
        //    Console.WriteLine(item.Key);
        //    foreach(var item2 in item)
        //    {
        //        Console.WriteLine(item2);
        //    }
        //}

        // Distinct: loai bo phan tu co cung gia tri
        //products.SelectMany(p=>p.Colors).Distinct().ToList()
        //       .ForEach(mau => Console.WriteLine(mau));


        // Single , SingleOrDefault
        //var p =products.Single(p => p.Price == 400);
        //Console.WriteLine(p);

        //var p = products.SingleOrDefault(p => p.Price == 600);
        //if(p != null)
        //Console.WriteLine(p);

        // Any
        //var p = products.Any(p => p.Price == 600);
        //Console.WriteLine(p);

        //All
        //var p = products.All(p => p.Price >= 600);
        //Console.WriteLine(p);

        // Count
        var p = products.Count(p=>p.Price>=300);
        Console.WriteLine(p);
    }
}