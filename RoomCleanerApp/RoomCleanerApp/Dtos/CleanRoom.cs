using RoomCleanerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Dtos
{
    public class CleanRoom
    {
        public Room Room { get; set; }
        public bool Cleaned { get; set; }
    }
}
