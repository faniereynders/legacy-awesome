<!DOCTYPE html>
<html>
<body>
    <!-- #Include file="menu.html" -->

    <%
set conn=Server.CreateObject("ADODB.Connection")

conn.Open("Provider=SQLOLEDB;Server=.\sqlexpress;Database=test;Trusted_Connection=yes;")
set rs = Server.CreateObject("ADODB.recordset")
sql="SELECT Companyname, Contactname FROM Customers "

    %>


    <form method="post">
        Search:
        <input type="text" name="searchText" size="20" />
        <input type="submit" value="Submit" />
    </form>
    <%
dim searchText
searchText=Request.Form("searchText")
If searchText<>"" Then
     sql = sql & " WHERE companyname like '%" & searchtext & "%'"
End If

    rs.Open sql, conn
    %>

    <table border="1" width="100%">
        <tr>
            <%for each x in rs.Fields
    response.write("<th>" & x.name & "</th>")
next%>
        </tr>
        <%do until rs.EOF%>
        <tr>
            <%for each x in rs.Fields%>
            <td><%Response.Write(x.value)%></td>
            <%next
    rs.MoveNext%>
        </tr>
        <%loop
rs.close
conn.close
        %>
    </table>

</body>
</html>
