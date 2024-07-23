
using System.ComponentModel.DataAnnotations;

namespace userFavorites.Models
{
    public class CryptoModel
    {
        [Key]   
        public int cryptoID { get; set; }
        public string crStockName { get; set; }
        public string crCode { get; set; }
        public decimal crLastPrice { get; set; }
        public decimal crVolume { get; set; }
    }
}
