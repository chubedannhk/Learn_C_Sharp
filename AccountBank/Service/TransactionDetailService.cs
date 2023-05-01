using AccountBank.Models;

namespace AccountBank.Service;

public interface TransactionDetailService
{
    public List<TransactionDetail> searchTrans(int accid);

    public List<TransactionDetail> searchTransWithDraw(int accid);
}
