namespace BlockchainExplorer.Models;

public class Transaction {
  public int Timestamp { get; set; }
  public string Sender { get; set; }
  public string Recipient { get; set; }
  public double amount { get; set; }
}