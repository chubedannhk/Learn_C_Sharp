/* 
 *  publisher -> class => phát sự kiện
 *  subsriber -> class => nhận sự kiện
 */

public delegate void SuKienNhapSo(int x);

// publisher
class Dulieunhap : EventArgs
{
    public int data { set; get; }
    public Dulieunhap(int x) => data = x;
    class UserInput
    {
        // them event
        // public event SuKienNhapSo sukiennhapso;
        public event EventHandler sukiennhapso; // ~delegate void Kieu(object? sender, EvenArgs args)
        public void Input()
        {
            do
            {
                Console.WriteLine("Nhap vao 1 con so");
                string s = Console.ReadLine();
                int i = Int32.Parse(s);
                // phat di su kien
                //  sukiennhapso?.Invoke(i);

                sukiennhapso?.Invoke(this, new Dulieunhap(i));
            } while (true);

        }
    }
    class TinhCan
    {
        public void Sub(UserInput input)
        {
            input.sukiennhapso += Can;
        }

        // ~delegate void Kieu(object? sender, EvenArgs args)
        public void Can(object sender, EventArgs e)
        {
            Dulieunhap dulieunhap = (Dulieunhap)e;
            int i = dulieunhap.data;
            Console.WriteLine($"can bac hai cua so {i} la: {Math.Sqrt(i)}");
        }
    }

    class BinhPhuong
    {
        public void Sub(UserInput input)
        {
            // += : cho phep nhan them su kien
            // -= : nguoc lai +=
            input.sukiennhapso += TinhBinhPhuong;
        }
        public void TinhBinhPhuong(object sender, EventArgs e)
        {

            Dulieunhap dulieunhap = (Dulieunhap)e;
            int i = dulieunhap.data;
            Console.WriteLine($"Binh Phuong cua so {i} la: {i * i}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // su kien thoat ung dung
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine();
                Console.WriteLine("Thoat ung dung");
            };
            //publisher
            UserInput input = new UserInput();
            input.sukiennhapso += (sender, e) =>
            {

                Dulieunhap dulieunhap = (Dulieunhap)e;

                Console.WriteLine($"Ban vua nhap so {dulieunhap.data}");
            };
            //subcriber
            TinhCan tinhCan = new TinhCan();
            tinhCan.Sub(input);

            BinhPhuong binhPhuong = new BinhPhuong();
            binhPhuong.Sub(input);


            input.Input();
        }
    }
}