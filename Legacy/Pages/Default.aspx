<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Welcome!</h2>
    <div class="alert alert-primary" role="alert">
        Total of <strong>
            <asp:Label ID="lblProductCount" runat="server" Text=""></asp:Label></strong>
        products ordered amounting to <strong>EUR 
       <asp:Label ID="lblOrdersTotal" runat="server" Text=""></asp:Label></strong>
    </div>

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

