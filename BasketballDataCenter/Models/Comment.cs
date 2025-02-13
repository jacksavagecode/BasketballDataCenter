using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BasketballDataCenter.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int FeedId { get; set; }
        [ForeignKey("FeedId")]
        public Feed Feed { get; set; }
        public string CommentText { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime CommentDate { get; set; } = DateTime.Now;
        [StringLength(450)]
        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User User { get; set; }
    }
}
