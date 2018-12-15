using GroceryList.DAL;
using GroceryList.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.BLL
{
   public class PickerController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<KeyValueOption> ListPickers()
        {
            using (var context = new GroceryListContext())
            {
                var Pickers = (from data in context.Pickers

                               select new KeyValueOption
                               {
                                   Key = data.PickerID.ToString(),
                                   Text = data.LastName + ", " + data.FirstName


                               }).ToList();
                Pickers.Insert(0, new KeyValueOption { Key = null, Text = "select a Picker" });
                return Pickers;
            }
        }
    }
}
