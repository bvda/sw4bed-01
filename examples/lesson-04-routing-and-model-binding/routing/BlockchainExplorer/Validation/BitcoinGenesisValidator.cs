using System.ComponentModel.DataAnnotations;

namespace BlockchainExplorer.Validation 
{
  public class BitcoinGenesisRangeAttribute : ValidationAttribute 
  {
      public BitcoinGenesisRangeAttribute()
      { 
      } 

      public override bool IsValid(object value) 
      {
        var dt = (int)value;
        return dt >= 1231006505 && dt <= DateTimeOffset.UtcNow.ToUnixTimeSeconds();
      }
  }
}