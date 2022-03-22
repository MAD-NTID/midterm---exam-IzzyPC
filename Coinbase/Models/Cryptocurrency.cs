using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coinbase.Models
{
    [Table("cryptocurrency")]
    public class Cryptocurrency
    {
        [Key]
        public int Rank { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Price { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Changes24H { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Changes7D { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Changes30D { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Changes1Y { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string MarketCap { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Volume24H { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string AvailableSupply { get; set; }
    }
}