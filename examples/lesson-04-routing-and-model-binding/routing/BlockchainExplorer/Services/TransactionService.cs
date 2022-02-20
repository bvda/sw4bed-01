using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

using BlockchainExplorer.Models;

namespace BlockchainExplorer.Services {

  public class TransactionService {
    private IList<Transaction> _transactions = new List<Transaction>();
    public IList<Transaction> Transactions { get; set; } = new List<Transaction>();
    public IList<Transaction> Wallets { get; } = new List<Transaction>();
    public TransactionService() {
      using FileStream fs = File.OpenRead("transactions.out");
      var transactions = JsonSerializer.Deserialize<Transaction[]>(fs, new JsonSerializerOptions {
        PropertyNameCaseInsensitive = true,
      });
      _transactions = transactions;
      Wallets = Transactions;
    }

    public TransactionService OrderBy(bool ascending) {
       if(ascending) {
          Transactions = _transactions.Select(m => m).OrderBy(t => t.Timestamp).ToList();
      } else {
          Transactions = _transactions.Select(m => m).OrderByDescending(t => t.Timestamp).ToList();
      }
      return this; 
    }

      public TransactionService Filter(int? from, int? to) {
      if (from != 0 && to != 0)
      {
        Transactions = _transactions.Select(t => t).Where(t => t.Timestamp >= from && t.Timestamp <= to).ToList();
      }
      else
      {
        if (from != 0)
        {
          Transactions = _transactions.Select(t => t).Where(t => t.Timestamp >= from).ToList();
        }
        if (to != 0)
        {
          Transactions = _transactions.Select(t => t).Where(t => t.Timestamp <= to).ToList();
        }
      }
      return this;
    }
  }
}
