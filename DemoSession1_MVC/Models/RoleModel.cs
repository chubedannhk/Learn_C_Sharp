namespace DemoSession1_MVC.Models;

public class RoleModel
{
    public List<Role> findAll()
    {
        return new List<Role>()
        {
            new Role() {Id=1, Name="Role admin"},
            new Role() {Id=2, Name="Role user 2"},
            new Role() {Id=3, Name="Role ctv"},
          
        };
    }
}
