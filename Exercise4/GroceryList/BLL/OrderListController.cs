using GroceryList.DAL;
using GroceryList.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.BLL
{
    public class OrderListController
    {
        public CustomerInfo CustomerDetails(int OrderID)
        {
            using (var context = new GroceryListContext())
            {
                var details = (from ord in context.Orders
                               where OrderID == ord.OrderID
                               select new CustomerInfo
                               {
                                   CustomerID = ord.Customer.CustomerID,
                                   FullName = ord.Customer.FirstName + " " + ord.Customer.LastName,
                                   Contact = ord.Customer.Phone
                               }).Single();
                return details;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ProductInfo> ProductDetails(int OrderId)
        {
            using (var context = new GroceryListContext())
            {
                var pros = (from order in context.OrderLists
                            where order.OrderID == OrderId && order.ProductID == order.Product.ProductID
                            select new ProductInfo
                            {
                                OrderListID = order.OrderListID,
                                ProductID = order.Product.ProductID,
                                ProductDescription = order.Product.Description,
                                QtyOrdered = order.QtyOrdered,
                                QtyPicked = order.QtyPicked,
                                CustomerComment = order.CustomerComment,
                                PickIssue = order.PickIssue
                            }).ToList();
                return pros;

            }
        }

        public void PickerAssign(int OrderID, int PickerID, List<AssignPicker> data)
        {

            using (var context = new GroceryListContext())
            {

                var orderDetID = context.Orders.Find(OrderID);
                orderDetID.PickedDate = DateTime.Now;
                orderDetID.PickerID = PickerID;


                foreach (var item in data)
                {
                    var orderListFilter = context.OrderLists.Find(item.OrderListID);

                    orderListFilter.QtyPicked = item.QtyPicked;
                    orderListFilter.PickIssue = item.PickIssue;

                }
                context.Entry(orderDetID).State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
