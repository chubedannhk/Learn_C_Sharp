namespace DemoSession1_MVC.Models;

public class StatusModel
{
    public List<Status> findAll()
    {
        return new List<Status>()
        {
            new Status() {Id=1, Name="No"},
            new Status() {Id=2, Name="Yes"},
            new Status() {Id=3, Name="Cancel"},
          
        };
    }
}
