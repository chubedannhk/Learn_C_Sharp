using QuanLyHoaDon.Models;

namespace QuanLyHoaDon.Service;

public class CustomerServiceImpl : CustomerService
{
    private DatabaseContext db;
    public CustomerServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
    public List<Customer> findAll()
    {
        return db.Customers.ToList();
    }

    public Customer findById(int id)
    {
        return db.Customers.Find(id);
    }
    // change profile
    public bool Update(Customer customer)
    {
       
       try
        {
            db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }

    }
}
