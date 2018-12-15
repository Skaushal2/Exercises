using GroceryList.DAL;
using GroceryList.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GroceryList.Entities;

namespace GroceryList.BLL
{
    [DataObject]
    public class OrderController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<KeyValueOption> ListOrders()
        {
            using (var context = new GroceryListContext())
            {
                var orderID = (from data in context.Orders
                               where data.PickerID == null

                             select new KeyValueOption
                             {
                                 Key = data.OrderID.ToString(),
                                 
                                 
                             }).ToList();
                orderID.Insert(0, new KeyValueOption { Key = null, Text = "select a Order" });
                return orderID;
            }
        }

        
      


    }
}
