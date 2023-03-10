// virtual method: phuong thuc ao: là phương thức có thể ghi đè, đc định nghĩa lại 

//class Product
//{
//    protected int Price { set; get; }
//    public virtual void ProductInfo()
//    {
//        Console.WriteLine($"gia sp: {Price}");
//    }

//    public  void Test() => ProductInfo();
//}

//class Iphone : Product
//{
//    public Iphone() => Price = 40000;

//    //override: cho phep ghi lại phương thức đã định nghĩa ở lớp cơ sở -> nạp chồng phương thức
//    public override void ProductInfo()
//    {
//        Console.WriteLine("Dien thoai iphone");
//        // neu muon goi lai phuong thuc phia tren da duoc nap chong thi dung "base.Tenphuongthuc()" de goi lai phuong thuc do
//        base.ProductInfo();
//    }
//}
//class Program
//{
//   static void Main(string[] args)
//    {
//        Iphone iphone = new Iphone();
//        iphone.ProductInfo();
//        iphone.Test();
//    }
//}

//======== Abstract ========= 
// abstract la co so cho ke thua
//abstract class Product
//{
//    protected int Price { set; get; }
//    // phuong thuc chieu tuong chi co ten phuong thuc, khong co phan than
//    public abstract void ProductInfo();

//    public void Test() => ProductInfo();
//}

//class Iphone : Product
//{
//    public Iphone() => Price = 40000;
//    public override void ProductInfo()
//    {
//        Console.WriteLine($"gia sp: {Price}");
//        Console.WriteLine("Dien thoai iphone");
//    }

//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        Iphone iphone = new Iphone();
//        iphone.ProductInfo();
//        iphone.Test();
//    }
//}


//======== Interface =========
// khai bao ra cau truc 1 class nhung khong dc dung de tao ra doi tuong, chi duoc dung de lam co so cho cac lop ke thua

interface IHinhHoc
{
    public double TinhChuVi();
    public double TinhDienTich();
}

class HinhChuNhat : IHinhHoc
{
    public HinhChuNhat(double _a, double _b) { 
        a= _a; b= _b;
    }
    public double a { set; get; }
    public double b { set; get; }

    public double TinhChuVi()
    {
       return 2*(a+b);
    }

    public double TinhDienTich()
    {
        return a * b;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Nhap a: ");
        double a = Double.Parse(Console.ReadLine());
        Console.WriteLine("Nhap b: ");
        double b = Double.Parse(Console.ReadLine());
        HinhChuNhat h = new HinhChuNhat(a,b);
        Console.WriteLine($"Dien tich: {h.TinhDienTich()}, Chu vi: {h.TinhChuVi()}");
    }
}

