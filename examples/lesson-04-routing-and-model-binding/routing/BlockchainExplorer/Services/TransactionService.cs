using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

using BlockchainExplorer.Models;

namespace BlockchainExplorer.Services {

  public class TransactionService {
  public IList<Transaction> Transactions { get; } = new List<Transaction>();
  public IList<Transaction> Wallets { get; } = new List<Transaction>();
    public TransactionService() {
      using FileStream fs = File.OpenRead("transactions.out");
      var transactions = JsonSerializer.Deserialize<Transaction[]>(fs, new JsonSerializerOptions {
        PropertyNameCaseInsensitive = true,
      });
      Transactions = transactions;
      Wallets = Transactions;
    }
  }
}
