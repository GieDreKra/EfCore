using System.Collections.Generic;

namespace RegistrationItemsApp.Models
{
    public class RegistrationItem : Entity
    {
        public int SelectedValueId { get; set; } = 1;
        public List<Value> Values { get; set; }
        public Form Form { get; set; }
    }
}
