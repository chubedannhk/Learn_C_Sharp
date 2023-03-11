/* Lambda  - anonymous function ( bieu thuc khong ten)
 * 1> (tham_so) => bieu_thuc;
 * 2> (tham_so) =>{
    cac_bieu_thuc
    return bieu_thuc
}
*/

//Action<string> thongbao; // delegate
//thongbao = (string s) => Console.WriteLine(s);
//thongbao?.Invoke("Xin chao");

//Action<string,string> Welcome; // delegate
//Welcome = (string s, string y) =>
//{
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine(s + " " + y);
//    Console.ResetColor();
//};
//Welcome?.Invoke("Xin chao","nguyenhoangkhai");


// khai bao co kieu tra ve thi dung Func ->delegate
//(int a, int b) =>
//{
//    int kq = a + b;
//    return kq;
//}
//Func<int, int, int> tinhtoan;
//tinhtoan = (int a, int b) =>
//{
//    int kq = a + b;
//    return kq;
//};
//Console.WriteLine(tinhtoan.Invoke(3,5));


//int[] arr = { 3, 4, 2, 42, 4, 52, 3 };
//var result = arr.Select( (int x) =>
//{
//    return Math.Sqrt(x);
//});
//foreach(var result2 in result)
//{
//    Console.WriteLine(result2);
//}

int[] arr = { 3, 4, 2, 42, 4, 52, 3 };
arr.ToList().ForEach(
    (int x) =>
    {
        if(x%2 == 0)
        {
            Console.WriteLine(x);
        }
    }
    );