<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcercisePage.aspx.cs" Inherits="WebApp.ExcercisePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row">

        <asp:DropDownList runat="server" DataSourceID="OrderDataSource" DataTextField="Key" ID="OrderDropDown" DataValueField="Key"></asp:DropDownList>

        <asp:LinkButton runat="server" OnClick="FetchingInfo">Fetch</asp:LinkButton>

        <asp:HiddenField  runat="server" ID="CustomerID" />

        <asp:Label runat="server" ID="CustomerNameLabel">Customer: </asp:Label>

        <asp:Label runat="server" ID="CustomerContact">Phone: </asp:Label>

        <asp:DropDownList runat="server" DataSourceID="PickerDataSource" DataTextField="Text" ID="PickerDropDown" DataValueField="Key"></asp:DropDownList>
        <br />
        <hr />
        <asp:GridView CssClass="table table-hover" runat="server" ID="ProductGridView" AutoGenerateColumns="false" ItemType="GroceryList.Entities.POCOs.ProductInfo" DataSourceID="ProDataSource">
            <Columns>
                <asp:TemplateField HeaderText="Product">
                    <ItemTemplate>
                        <asp:HiddenField ID="OrderListID" runat="server" Value="<%# Item.OrderListID %>" />
                        <asp:Label ID="ProductLabel" runat="server"><%# Item.ProductDescription %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="QtyLabel" runat="server"><%# Item.QtyOrdered %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Comment">
                    <ItemTemplate>
                        <asp:Label ID="commentLabel" runat="server"><%# Item.CustomerComment %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Picked">
                    <ItemTemplate>
                        <asp:TextBox ID="qtyPickBox" Text="<%# Item.QtyPicked %>" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Picked Issue">
                    <ItemTemplate>

                        <asp:TextBox ID="pickIssueBox" Text="<%# Item.PickIssue %>" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:LinkButton runat="server" OnClick="SaveData">Save</asp:LinkButton>

        <asp:ObjectDataSource runat="server" ID="ProDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ProductDetails" TypeName="GroceryList.BLL.OrderListController">
            <SelectParameters>
                <asp:ControlParameter ControlID="OrderDropDown" PropertyName="SelectedValue" Name="OrderId" Type="Int32"></asp:ControlParameter>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>




    <asp:ObjectDataSource ID="PickerDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListPickers" TypeName="GroceryList.BLL.PickerController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OrderDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListOrders" TypeName="GroceryList.BLL.OrderController"></asp:ObjectDataSource>
</asp:Content>
