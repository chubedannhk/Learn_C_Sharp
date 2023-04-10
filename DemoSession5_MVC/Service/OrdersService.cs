using QuanLyHoaDon.Models;

namespace QuanLyHoaDon.Service;

public interface OrdersService
{
    public bool Create(Order order);
    public List<Order> findCustomerId(int customerId);

    public bool Delete(int id);

}