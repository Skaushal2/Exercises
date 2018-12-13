<Query Kind="Expression">
  <Connection>
    <ID>75292ae8-7fde-41a4-b273-2d4d0f3eb75b</ID>
    <Server>.</Server>
    <Database>GroceryList</Database>
  </Connection>
</Query>

//1. Create a product list which indicates what products are purchased by our customers and how many times that product was purchased. 
// Order the list by most popular product by alphabetic description

from prd in Products
where prd.OrderLists.Count()>0
orderby prd.OrderLists.Count() descending, prd.Description
select new
{
    Product = prd.Description,    
    TimesPurchased = prd.OrderLists.Count(),
}