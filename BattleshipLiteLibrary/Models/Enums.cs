using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary.Models
{
    public class Enums
    {
        public enum GridSpotStatus
        {
            Empty,
            Ship,
            Miss,
            Hit,
            Sunk
        }
    }
}