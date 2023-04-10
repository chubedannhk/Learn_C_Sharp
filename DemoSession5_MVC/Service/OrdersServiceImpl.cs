using QuanLyHoaDon.Models;
using System.Diagnostics;

namespace QuanLyHoaDon.Service;

public class OrdersServiceImpl : OrdersService
{
    private DatabaseContext db;
    public OrdersServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
    public bool Create(Order order)
    {
        try
        {
            db.Orders.Add(order);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    

    public List<Order> findCustomerId(int customerId)
    {
        return db.Orders.Where(p => p.Customerid == customerId).ToList();
    }

    public bool Delete(int id)
    {
        try
        {
            var order = db.Orders.Find(id);
            db.Orders.Remove(order);

            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
