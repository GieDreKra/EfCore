using RoomCleanerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Dtos
{
    public class CreateCleanerDto
    {
        public List<Cleaner> Cleaners { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }

    }
}
