using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationItemsApp.Models
{
    public class Value : Entity
    {
        public RegistrationItem RegistrationItem { get; set; }
    }
}
