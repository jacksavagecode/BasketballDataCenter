using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasketBallDataCenter.Models
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public double OffensiveHomePPG { get; set; }
        public double OffensiveAwayPPG { get; set; }
        public double DefensiveHomePPG { get; set; }
        public double DefensiveAwayPPG { get; set; }
        public double HomeRecord { get; set; }
        public double AwayRecord { get; set; }
        public double TotalRecord { get; set; }
        public double Streak { get; set; }
    }
}
