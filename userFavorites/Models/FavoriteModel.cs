using System.ComponentModel.DataAnnotations;

namespace userFavorites.Models
{
    public class FavoriteModel
    {
        [Key]
        public int FavoriteID { get; set; }
        public int stockID { get; set; }
        public string UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
