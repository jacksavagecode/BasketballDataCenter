using BasketBallDataCenter.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketBallDataCenter.ViewModels
{
    public class PredictionViewModel
    {
        public List<Team> Teams { get; set; }
        public List<SelectListItem> TeamSelectList { get; set; }
        public SelectedTeam SelectedTeam { get; set; }

        public Team FavouriteTeam { get; set; }
        public SelectedTeams SelectedTeams { get; set; }

        public double HomeTeamPoints { get; set; }
        public double AwayTeamPoints { get; set; }

        public double TeamPrecentage { get; set; }
    }
}
