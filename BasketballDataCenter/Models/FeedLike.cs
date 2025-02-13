using BasketballDataCenter.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BasketBallDataCenter.Models
{
    [Table("FeedLike")]
    public class FeedLike
    {
        [Key]
        public int LikeId { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int FeedId { get; set; }
        [ForeignKey("FeedId")]
        public virtual Feed Feed { get; set; }
    }
}
