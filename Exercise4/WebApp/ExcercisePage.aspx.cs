using GroceryList.BLL;
using GroceryList.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ExcercisePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void FetchingInfo(object sender, EventArgs e)
        {
            var controller = new OrderListController();
            var detail = controller.CustomerDetails(int.Parse(OrderDropDown.SelectedValue));
            CustomerID.Value = detail.CustomerID.ToString();
            CustomerNameLabel.Text = "Customer:" + detail.FullName;
            CustomerContact.Text = "Phone:" + detail.Contact;
        }

        protected void SaveData(object sender, EventArgs e)
        {
            
            var data = new List<AssignPicker>();
            var pickerDropDown = int.Parse(PickerDropDown.SelectedValue);
            int orderId = int.Parse(OrderDropDown.SelectedValue);

            if (pickerDropDown != null && pickerDropDown != 0 && orderId != null && orderId != 0)
            {

                foreach (GridViewRow row in ProductGridView.Rows)
                {
                    var dataItem = new AssignPicker();
                    var orderListID = row.FindControl("OrderListID") as HiddenField;
                    dataItem.OrderListID = int.Parse(orderListID.Value);
                    var qtypickTextBox = row.FindControl("qtyPickBox") as TextBox;
                    var pickIssueTextBox = row.FindControl("pickIssueBox") as TextBox;


                    dataItem.PickIssue = pickIssueTextBox.Text;
                    //Add thr new DataItem to the list data to send to the BLL
                    dataItem.QtyPicked = double.Parse(qtypickTextBox.Text);

                    data.Add(dataItem);

                }
            }
                var controller = new OrderListController();
                controller.PickerAssign(orderId, pickerDropDown, data);
            
            
        }
            
            
        }
    }
