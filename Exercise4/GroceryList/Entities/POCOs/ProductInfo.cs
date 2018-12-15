using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Entities.POCOs
{
    public class ProductInfo
    {
        public int OrderListID { get; set; }
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public double QtyOrdered { get; set; }
        public double QtyPicked { get; set; }
        public string CustomerComment { get; set; }
        public string PickIssue { get; set; }
    }
}
