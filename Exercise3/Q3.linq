<Query Kind="Expression">
  <Connection>
    <ID>75292ae8-7fde-41a4-b273-2d4d0f3eb75b</ID>
    <Server>.</Server>
    <Database>GroceryList</Database>
  </Connection>
</Query>

//3. Create a Daily Sales per Store request for a specified month. Order stores by city by location. 
//For Sales, show order date, number of orders, total sales without GST tax and total GST tax.

from order in Orders
group order by order.Store into orderStore
orderby orderStore.Key.City,orderStore.Key.Location
select new
{
    city = orderStore.Key.City,
    location = orderStore.Key.Location,
    sales = from str in orderStore    
            where str.OrderDate.Month == 12
            group str by str.OrderDate into bSales
            
            orderby bSales.Key
            select new
            {
                date = bSales.Key,
                numberoforders = bSales.Count(),
                productsales =    bSales.Sum(x => x.SubTotal),
                gst = bSales.Sum(x => x.GST),
            }
}