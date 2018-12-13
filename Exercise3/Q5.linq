<Query Kind="Expression">
  <Connection>
    <ID>75292ae8-7fde-41a4-b273-2d4d0f3eb75b</ID>
    <Server>.</Server>
    <Database>GroceryList</Database>
  </Connection>
</Query>

//5. Select all orders a picker has done on a particular week (Sunday through Saturday).
//List by picker and order by picker and date. Hint: you will need to use the join operator.

from picker in Pickers
orderby picker.LastName,picker.FirstName
join order in Orders
on picker.PickerID equals order.PickerID into pickerodrer
select new
{
    picker = picker.LastName + "," + picker.FirstName,
    pickdates = from date in pickerodrer
                where  (date.PickedDate).Value.Month ==12 && (date.PickedDate).Value.Day > 16 && (date.PickedDate).Value.Day < 24
                orderby date.PickedDate
                select new
                {
                    ID = date.OrderID,
                    Date = date.PickedDate,
                }
    
                
}