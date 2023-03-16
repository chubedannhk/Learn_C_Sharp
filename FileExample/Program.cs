// doc file
class Program
{
    static void Main(string[] args)
    {
        //DriveInfo drive = new DriveInfo("/");
        //driveinfo => lay thong tin cua o dia trong may
        //var drives = DriveInfo.GetDrives();
        //foreach(var drive in drives)
        //{

        //    Console.WriteLine($"Drive:{drive.Name}");
        //    Console.WriteLine($"Drive:{drive.DriveType}");
        //    Console.WriteLine($"Drive:{drive.VolumeLabel}");
        //    Console.WriteLine($"Drive:{drive.DriveFormat}");
        //    Console.WriteLine($"Drive:{drive.TotalSize}");
        //    Console.WriteLine($"Drive:{drive.TotalFreeSpace}");
        //    Console.WriteLine("=========================");
        //}

        //-----------------------
        //Directory - thu muc
        string path = "nguyenhoangkhai";
        // tao ra thu muc
       // Directory.CreateDirectory(path);
        // xoa thu muc
        Directory.Delete(path);
        if (Directory.Exists(path))
        {
            Console.WriteLine($"{path} ton tai");
        }else { Console.WriteLine($"{path} khong ton tai"); }
        
    }
}
