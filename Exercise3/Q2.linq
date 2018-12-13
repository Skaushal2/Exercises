<Query Kind="Expression">
  <Connection>
    <ID>75292ae8-7fde-41a4-b273-2d4d0f3eb75b</ID>
    <Server>.</Server>
    <Database>GroceryList</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

//2. We want a mailing list for a Valued Customers flyer that is being sent out.
//List the customer addresses for customers who have shopped at each store. 
//List by the store. Include the store location as well as the customer's address. 
//Do NOT include the customer name in the results.

from order in Orders
group order by order.Store.Location into aLocation
orderby aLocation.Key
select new
{
    Location = aLocation.Key,
    Clients = from loc in aLocation
                group loc by loc.Customer into bClients
                orderby bClients.Key.Address
                select new
                        {
                            address = bClients.Key.Address,
                            city = bClients.Key.City,
                            province=bClients.Key.Province,
                        }
}