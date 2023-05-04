using AccountBank.Models;
using System.Diagnostics;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace AccountBank.Service;

public class TransactionDetailServiceImpl : TransactionDetailService
{
    private DatabaseContext db;
    public TransactionDetailServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }

    public bool CreateTransactionDetail(TransactionDetail transaction)
    {
        try
        {
            db.TransactionDetails.Add(transaction);
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public List<TransactionDetail> searchTrans(int accid)
    {
       return db.TransactionDetails.Where(p => p.AccId == accid && p.TransType == 1).OrderByDescending(p => p.DateOfTrans).ToList();
            
    }

    public List<TransactionDetail> searchTransWithDraw(int accid)
    {
        return db.TransactionDetails.Where(p => p.AccId == accid && p.TransType == 2).OrderByDescending(p => p.DateOfTrans).ToList();
    }
}
