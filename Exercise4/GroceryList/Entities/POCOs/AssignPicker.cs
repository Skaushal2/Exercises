using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Entities.POCOs
{
    public class AssignPicker
    {
        public int PickerID { get; set; }
        public int OrderID { get; set; }
        public string PickIssue { get; set; }
        public double QtyPicked { get; set; }
        public int OrderListID { get; set; }
        public int CustomerID { get; set; }

    }
}
