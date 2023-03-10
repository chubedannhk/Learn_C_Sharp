// kieu du lieu struct la kieu du lieu THAM TRI, còn các kiểu dữ liệu class là kiểu THAM CHIẾU
//class Program
//{
//    public struct Product
//    {
//        public string name;
//        public int price;
//        public string GetInfo()
//        {
//            return $"Ten san pham{name}, gia:{price}";
//        }
//        public Product(string names, int prices)
//        {
//            name = names;
//            this.price = prices;
//        }

//    }

//    static void Main(string[] args)
//    {
//        Product pro = new Product("ffks", 23);
//        Console.WriteLine(pro.GetInfo());
//    }
//}

//========= Kiểu liệt kê Enum ====================
class Program
{
    /*
    0 - kém
    1 - tb
    2 - khá
    3 - giỏi
     */
    enum hocLuc
    {
        Kem, //0
        TrungBinh, //1
        Kha, //2
        Gioi
    } //3
    static void Main(string[] args)
    {
        hocLuc hocluc;
        hocluc = hocLuc.Kem;
        //switch (hocluc)
        //{
        //    case hocLuc.Gioi:
        //        Console.WriteLine("học giỏi");
        //        break;
        //    case hocLuc.Kha:
        //        Console.WriteLine("học khá");
        //        break;
        //    case hocLuc.TrungBinh: Console.WriteLine("học trung bình");
        //        break;
        //    case hocLuc.Kem: Console.WriteLine("Học ngu");
        //        break;
        //}

        // tối ưu code
        Console.WriteLine(hocluc switch
        {
            hocLuc.Gioi => "học giỏi",
            hocLuc.Kha => "học khá",
            hocLuc.TrungBinh => "học trung bình",
            hocLuc.Kem => "Học ngu",
            _ => throw new NotImplementedException(),
        });

        // ngoài ra có thể dùng toán tử ba ngôi
        //Console.WriteLine(hocluc == hocLuc.Gioi ? "học giỏi" : hocluc == hocLuc.Kha ? "học khá" : hocluc == hocLuc.TrungBinh ? "học trung bình" : "Học ngu");

    }
}