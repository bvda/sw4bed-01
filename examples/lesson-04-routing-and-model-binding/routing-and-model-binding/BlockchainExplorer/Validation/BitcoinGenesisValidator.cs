using System.ComponentModel.DataAnnotations;

namespace BlockchainExplorer.Validation 
{
  public class BitcoinGenesisRangeAttribute : ValidationAttribute 
  {
    public const int BitCoinGenesis = 1231006505;
    public BitcoinGenesisRangeAttribute()
    { 
    } 

    public override bool IsValid(object? value = null) 
    {
      var dt = 0;
      if(value is not null) {
        dt = (int)value;
      }
      return dt >= BitCoinGenesis && dt <= DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
  }
}