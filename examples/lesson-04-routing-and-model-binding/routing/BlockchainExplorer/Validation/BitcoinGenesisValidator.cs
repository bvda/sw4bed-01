using System.ComponentModel.DataAnnotations;

namespace BlockchainExplorer.Validation 
{
  public class BitcoinGenesisRangeAttribute : RangeAttribute
  {
      public BitcoinGenesisRangeAttribute() : base(1230980400, DateTimeOffset.UtcNow.ToUnixTimeSeconds()) 
      { 
      } 
  }

}