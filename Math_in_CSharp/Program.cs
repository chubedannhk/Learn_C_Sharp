using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

// về hằng số
Console.WriteLine($"Hằng số Pi {Math.PI}, E: {Math.E}");

// max và min
int a = 23;
int b = 32;
int c = 322;

Console.WriteLine($"Max{Math.Max(Math.Max(3,4),32)}");

// Abs, Sign
Console.WriteLine($"Giá trị tuyệt đối: {Math.Abs(-23)}");

// lượng giác: sin, cos, tan, asin , acos, atan
Console.WriteLine($"Sin: {Math.Sin(Math.PI/2)}");

double deg = 60;
double rad = Math.PI*deg/180;
// tính sin của góc deg 60 độ 
Console.WriteLine($"sin: {Math.Sin(rad)}");
// chạy vòng lạp tính sin từ 0 đến 90 độ
for(int i = 0; i <=90; i++)
{
    rad = Math.PI * i / 180;
    Console.WriteLine($"Sin {i} là: {Math.Sin(rad)}");
}

// sqrt: căn bật hai, Pow(a,b), Log(a), Log10(a)
Console.WriteLine($"Sqrp của 2 là: {Math.Sqrt(2)}");
Console.WriteLine($"Luy thua: {Math.Pow(2,3)}");
Console.WriteLine($"Log: {Math.Log(2)}");

// Làm tròn số
//Math.Round(a); 5.6 -> 6 , 5.4 ->5
//Math.Ceiling(a); 5.4, 5.6 ->6
//Math.Floor(a); 5.3, 5.6 ->5

// cắt đi phần thập phân của 1 con số
//Math.Truncate(rad);
