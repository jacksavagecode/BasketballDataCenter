using BasketBallDataCenter.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketballDataCenter.Models
{
    [Table("Feed")]
    public class Feed
    {
        [Key]
        public int FeedId { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string FeedContent { get; set; }
        public int LikeCount { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public ICollection<Comment> Comments { get; set; }
        public ICollection<FeedLike> Likes { get; set; }

    }
}
