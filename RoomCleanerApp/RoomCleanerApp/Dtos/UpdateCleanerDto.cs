using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Dtos
{
    public class UpdateCleanerDto
    {
        public List<CleanRoom> CleanRooms { get; set; }
        public int CleanerId { get; set; }
    }
}
