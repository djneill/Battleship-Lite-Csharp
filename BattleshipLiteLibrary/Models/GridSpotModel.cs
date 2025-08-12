using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BattleshipLiteLibrary.Models.Enums;

namespace BattleshipLiteLibrary.Models
{
    public class GridSpotModel
    {
        public required string SpotLetter { get; set; }
        public int SpotNumber { get; set; }
        public GridSpotStatus Status { get; set; } = GridSpotStatus.Empty;
        // 0 = empty, 1 = ship, 2 = miss, 3 = hit, 4 = sunk 
    }
}