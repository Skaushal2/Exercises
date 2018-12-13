<Query Kind="Expression">
  <Connection>
    <ID>75292ae8-7fde-41a4-b273-2d4d0f3eb75b</ID>
    <Server>.</Server>
    <Database>GroceryList</Database>
  </Connection>
</Query>

//6.List all the products a customer (use Customer #1) has purchased and the number of times the product was purchased.
//Order by number of times purchased then description

from order in Orders
where order.Customer.CustomerID == 1
group order by order.Customer into ordergroup 
select new 
{
    Customer = ordergroup.Key.LastName + ", " + ordergroup.Key.FirstName,
    OrdersCount = ordergroup.Key.Orders.Count(),
    Items = from b in ordergroup
            from c in OrderLists
            where c.OrderID.Equals(b.OrderID)            
            group c by c.Product into cProducts
            orderby cProducts.Count() descending, cProducts.Key.Description
            select new
            {
                descr = cProducts.Key.Description,
                noOfBuyings = cProducts.Count(),
            }
}