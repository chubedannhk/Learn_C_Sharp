using AccountBank.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace AccountBank.Service;

public class TransactionDetailServiceImpl : TransactionDetailService
{
    private DatabaseContext db;
    public TransactionDetailServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
    public List<TransactionDetail> searchTrans(int accid)
    {
       return db.TransactionDetails.Where(p => p.AccId == accid && p.TransType == 1).ToList();
            
    }

    public List<TransactionDetail> searchTransWithDraw(int accid)
    {
        return db.TransactionDetails.Where(p => p.AccId == accid && p.TransType == 2).ToList();
    }
}
