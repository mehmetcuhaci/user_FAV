using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace userFavorites.Models
{
    public class StockModel
    {
        [Key]
        public int stockID { get; set; }
        public string stockname { get; set;}
        public string Code { get; set;} 
        public decimal lastprice { get; set;}
        public decimal volume { get; set;}

    }
}
