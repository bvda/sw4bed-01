using System.ComponentModel.DataAnnotations;

namespace BlockchainExplorer.Validation 
{
  public class BitcoinGenesisRangeAttribute : RangeAttribute
  {
      public BitcoinGenesisRangeAttribute() : base(1231006505, DateTimeOffset.UtcNow.ToUnixTimeSeconds()) 
      { 
      } 
  }

}