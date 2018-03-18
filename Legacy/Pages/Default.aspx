<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Welcome!</h2>
   <h3>Total of <asp:Label ID="lblProductCount" runat="server" Text=""></asp:Label> 
       products ordered amounting to EUR 
       <asp:Label ID="lblOrdersTotal" runat="server" Text=""></asp:Label>
   </h3>
    
</asp:Content>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        var repository = new Legacy.Data.OrdersRepository(Legacy.Config.ConnectionString);
        var aggregate = repository.GetOrdersAggregate();
        lblProductCount.Text = aggregate.Item1.ToString();
        lblOrdersTotal.Text = aggregate.Item2.ToString();
    }
</script>

