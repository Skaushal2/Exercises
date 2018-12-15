using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Entities.POCOs
{
    public class KeyValueOption
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public IEnumerable<CustomerInfo> Customer{ get; set; }
    }
}
