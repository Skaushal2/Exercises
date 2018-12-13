<Query Kind="Expression">
  <Connection>
    <ID>75292ae8-7fde-41a4-b273-2d4d0f3eb75b</ID>
    <Server>.</Server>
    <Database>GroceryList</Database>
  </Connection>
</Query>

//4. Print out all product items on a requested order (use Order #33). 
//Group by Category and order by Product Description. 
//You do not need to format money as this would be done at the presentation level. 
//Use the QtyPicked in your calculations. 
//Hint: You will need to using type casting (decimal). 
//Use of the ternary operator will help.

from product in Products
group product by product.Category into prodCategory
orderby prodCategory.Key.Description
select new
{
    Category = prodCategory.Key.Description,
    OrderProducts = from odrpro in prodCategory
                    join odrlis in OrderLists
                    on odrpro.ProductID equals odrlis.ProductID
                    where odrlis.OrderID == 33
                    orderby odrpro.Description
                    select new
                    {
                        Product = odrpro.Description,
                        Price = odrlis.Price,
                        PickedQty = odrlis.QtyPicked,
                        Discount = odrlis.Discount,
                        Subtotal = (odrlis.Price-odrlis.Discount)*(decimal)odrlis.QtyPicked,
                        tax = odrpro.Taxable == false? (decimal)0 : (odrlis.Price-odrlis.Discount)*(decimal)odrlis.QtyPicked*(decimal)0.05,
                        ExtendedPrice =  odrpro.Taxable == false? (odrlis.Price-odrlis.Discount)*(decimal)odrlis.QtyPicked : (odrlis.Price-odrlis.Discount)*(decimal)odrlis.QtyPicked*(decimal)1.05,
                    }                        
}