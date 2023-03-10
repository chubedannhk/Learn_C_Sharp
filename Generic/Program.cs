// generic
// khi khoi tao nhu vay thi thay doi thuoc tinh cua bien the nao cung chay duoc
static void Swap<T>(ref T x,ref T y)
{
    T t;
    t = x; x = y; y = t;
    
}

float a = 3;
float b = 4;
Console.WriteLine($"ban dau: a={a}, b={b}");
Swap(ref a,ref b);
// khi viet the nay thi kieu du lieu truyen vao phai trung voi kieu du lieu mong muon
//Swap<int>(ref a, ref b);
Console.WriteLine($"sau khi swap: a={a}, b={b}");
