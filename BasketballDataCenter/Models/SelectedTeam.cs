using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketBallDataCenter.Models
{
    public class SelectedTeam
    {
        [Required(ErrorMessage = "Select a Team")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Select a Team")]
        public int TeamId { get; set; }
    }
}
