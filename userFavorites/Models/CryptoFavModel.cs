using System.ComponentModel.DataAnnotations;

namespace userFavorites.Models
{
    public class CryptoFavModel
    {
        [Key]
        public int CrFavID { get; set; }
        public int cryptoID { get; set; }
        public string UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
