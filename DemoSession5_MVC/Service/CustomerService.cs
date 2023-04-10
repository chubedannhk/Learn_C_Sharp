using QuanLyHoaDon.Models;

namespace QuanLyHoaDon.Service;

public interface CustomerService
{
    public List<Customer> findAll();
    public Customer findById(int id);

    public bool Update(Customer customer);
}
