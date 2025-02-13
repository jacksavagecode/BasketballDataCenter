using BasketballDataCenter.Models;

namespace BasketballDataCenter.ViewModels
{
    public class FeedsViewModel
    {
        public PaginatedList Feeds { get; set; }
        public Comment Comment { get; set; }
    }
}
