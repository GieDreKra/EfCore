using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Models
{
    public class Cleaner : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public List<RoomCleaner> RoomCleaners { get; set; }
    }
}
