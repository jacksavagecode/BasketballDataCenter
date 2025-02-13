using BasketballDataCenter.Models;
using BasketballDataCenter.ViewModels;
using BasketBallDataCenter.Models;
using BasketBallDataCenter.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BasketballDataCenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BasketballDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, BasketballDbContext dbContext, UserManager<User> userManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> PostComment(Comment comment)
        {
            var userId = _userManager.GetUserId(User);
            comment.OwnerId = userId;
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Feeds");
        }

        [Authorize]
        public async Task<IActionResult> DeleteFeed(int feedId)
        {
            var userId = _userManager.GetUserId(User);

            var feedLikes = await _dbContext.FeedLikes.Where(like => like.FeedId == feedId).ToListAsync();

            foreach (var f in feedLikes)
            {
                _dbContext.FeedLikes.Remove(f);
                await _dbContext.SaveChangesAsync();
            }


            var feed = await _dbContext.Feeds.FirstOrDefaultAsync(f => f.FeedId == feedId);
            _dbContext.Feeds.Remove(feed);
            await _dbContext.SaveChangesAsync();


            return RedirectToAction("Feeds");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AddFeed(int feedId = 0)
        {
            if (feedId == 0)
            {
                return View(new Feed());
            }
            else
            {
                var userId = _userManager.GetUserId(User);

                var feed = await _dbContext.Feeds.FirstOrDefaultAsync(f => f.FeedId == feedId);
                var user = await _userManager.GetUserAsync(User);
                var userRole = await _userManager.GetRolesAsync(user);
                if (userRole.First() == "Admin" || feed.UserId == userId)
                {
                    return View(feed);
                }
                return View(new Feed());

            }
        }

        [Authorize]
        public async Task<IActionResult> SubmitFeed(Feed feed)
        {
            if (feed.FeedId == 0)
            {
                feed.UserId = _userManager.GetUserId(User);
                await _dbContext.Feeds.AddAsync(feed);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                var userId = _userManager.GetUserId(User);
                var user = await _userManager.GetUserAsync(User);
                var userRole = await _userManager.GetRolesAsync(user);
                if (userRole.First() == "Admin" || feed.UserId == userId)
                {
                    _dbContext.Feeds.Update(feed);
                    await _dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("Feeds");
        }

        [Authorize]
        public async Task<IActionResult> Feeds(int pageIndex = 1)
        {
            var source = _dbContext.Feeds
                .AsNoTracking()
                .Include(feed => feed.User)                // Eager-load the user for the feed
                .Include(feed => feed.Comments)             // Load the comments for the feed
                .ThenInclude(comment => comment.User)      // Eager-load the user for each comment
                .Include(feed => feed.Likes)                // Load the likes for the feed
                .OrderByDescending(f => f.CreationDate);

            var pages = await PaginatedList.CreateAsync(source, pageIndex, 10);

            return View(new FeedsViewModel() { Feeds = pages, Comment = new Comment() });
        }


        [Authorize]
        public async Task<IActionResult> LikeFeed(int feedId)
        {
            var userId = _userManager.GetUserId(User);

            var feed = await _dbContext.Feeds.FirstOrDefaultAsync(f => f.FeedId == feedId);
            feed.LikeCount += 1;
            _dbContext.Feeds.Update(feed);
            await _dbContext.SaveChangesAsync();

            await _dbContext.FeedLikes.AddAsync(new FeedLike() { FeedId = feedId, UserId = userId });
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Feeds");
        }

        [Authorize]
        public async Task<IActionResult> UnlikeFeed(int feedId)
        {
            var userId = _userManager.GetUserId(User);

            var feed = await _dbContext.Feeds.FirstOrDefaultAsync(f => f.FeedId == feedId);
            feed.LikeCount -= 1;
            _dbContext.Feeds.Update(feed);
            await _dbContext.SaveChangesAsync();

            var feedLikes = await _dbContext.FeedLikes.Where(like => like.FeedId == feedId).ToListAsync();

            foreach (var f in feedLikes)
            {
                _dbContext.FeedLikes.Remove(f);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Feeds");
        }

        [Authorize]
        public IActionResult PredictionTools()
        {
            var userId = _userManager.GetUserId(User);
            var favouriteTeam = (from ut in _dbContext.UserTeams
                                 join t in _dbContext.Teams on ut.TeamId equals t.TeamId
                                 where ut.UserId == userId
                                 select t).FirstOrDefault();

            var teams = _dbContext.Teams.ToList();

            var vm = new PredictionViewModel()
            {

                Teams = new List<Team>(),
                TeamSelectList = new List<SelectListItem>(),
                SelectedTeam = new SelectedTeam() { TeamId = favouriteTeam == null ? 0 : favouriteTeam.TeamId },
                FavouriteTeam = favouriteTeam ?? new Team(),
                SelectedTeams = new SelectedTeams()
                {
                    AwayTeam = new SelectedTeam(),
                    HomeTeam = new SelectedTeam()
                }
            };


            teams.ForEach(team => {
                vm.TeamSelectList.Add(new SelectListItem() { Text = team.TeamName, Value = team.TeamId.ToString() });
            });

            var selectedHomeTeamId = TempData["SelectedHomeTeamId"] == null ? 0 : int.Parse(TempData["SelectedHomeTeamId"].ToString());
            var selectedAwayTeamId = TempData["SelectedAwayTeamId"] == null ? 0 : int.Parse(TempData["SelectedAwayTeamId"].ToString());

            if (selectedHomeTeamId != 0 && selectedAwayTeamId != 0)
            {
                var selectedHomeTeam = _dbContext.Teams.FirstOrDefault(team => team.TeamId == selectedHomeTeamId);
                var selectedAwayTeam = _dbContext.Teams.FirstOrDefault(team => team.TeamId == selectedAwayTeamId);

                vm.SelectedTeams.HomeTeam.TeamId = selectedHomeTeam.TeamId;
                vm.SelectedTeams.AwayTeam.TeamId = selectedAwayTeam.TeamId;

                var home_points = (selectedHomeTeam.OffensiveHomePPG + selectedAwayTeam.OffensiveAwayPPG) / 2;
                var away_points = (selectedAwayTeam.OffensiveHomePPG + selectedHomeTeam.DefensiveAwayPPG) / 2;

                var percentage = (0.6 * 0.69) * (selectedHomeTeam.HomeRecord / selectedAwayTeam.AwayRecord) +
                                (0.3 * 0.69) * (selectedHomeTeam.TotalRecord / selectedAwayTeam.TotalRecord) +
                                (0.1 * 0.69) * (selectedHomeTeam.Streak / selectedAwayTeam.Streak);

                vm.HomeTeamPoints = Math.Round(home_points, 3);
                vm.AwayTeamPoints = Math.Round(away_points, 3);
                vm.TeamPrecentage = Math.Round(percentage, 3);
            }

            return View(vm);
        }

        public IActionResult AddFavouriteTeam(SelectedTeam favouriteTeam)
        {
            var userId = _userManager.GetUserId(User);

            var userTeam = _dbContext.UserTeams.FirstOrDefault(team => team.TeamId == favouriteTeam.TeamId && team.UserId == userId);

            if (userTeam == null)
            {
                _dbContext.UserTeams.Add(new UserTeam() { TeamId = favouriteTeam.TeamId, UserId = userId });
                _dbContext.SaveChanges();
            }
            else
            {
                userTeam.TeamId = favouriteTeam.TeamId;
                _dbContext.Update(userTeam);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("PredictionTools");
        }

        [Authorize]
        public IActionResult GetPredictions(SelectedTeams selectedTeams)
        {
            TempData["SelectedHomeTeamId"] = selectedTeams.HomeTeam.TeamId;
            TempData["SelectedAwayTeamId"] = selectedTeams.AwayTeam.TeamId;
            return RedirectToAction("PredictionTools");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
