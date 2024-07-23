using System.ComponentModel.DataAnnotations;

namespace userFavorites.Models
{
    public class ArticleModel
    {
        [Key]
        public int ArticleID { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string AuthorID {  get; set; }
       public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
