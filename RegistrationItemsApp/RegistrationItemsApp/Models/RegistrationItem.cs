using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationItemsApp.Models
{
    public class RegistrationItem : Entity
    {
        public int SelectedValueId { get; set; } = 1;
        public List<Value> Values { get; set; }
    }
}
