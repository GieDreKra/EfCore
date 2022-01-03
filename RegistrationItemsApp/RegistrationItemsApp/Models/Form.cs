using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationItemsApp.Models
{
    public class Form : Entity
    {
        public List<RegistrationItem> RegistrationItems { get; set; }
    }
}
