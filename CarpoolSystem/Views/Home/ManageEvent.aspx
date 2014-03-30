<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.ManageEventModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ManageEvent
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Carpools you're a part of:</h2>
    <br />



    <h3>You're the driver of:</h3>
    <table>
<%--        <tr>
            <th>Title</th>
            <th>Modify event</th>
        </tr>--%>

    <% foreach (var item in Model.DriverEvent) { %>
        <tr>
            <td><%: Html.ActionLink(item.Title, "EventDisplay", new { id = item.EventId })%></td>
            <td>
                <%--<%: Html.ActionLink("Edit", "Edit", new { id=item.EventId }) %> |--%>
                <%: Html.ActionLink("Delete carpool?", "RemoveCarpool", new { id = item.EventId })%>
            </td>
        </tr>
    
    <% } %>

    </table>

        <h3>You're a passenger of:</h3>
    <table>
        <%--<tr>
            <th>Title</th>
        </tr>--%>

    <% foreach (var item in Model.PassengerEvent) { %>
    
        <tr>
            <td><%: Html.ActionLink(item.Title, "EventDisplay", new { id = item.EventId })%></td>
            <td>
            <%: Html.ActionLink("Leave carpool?", "LeaveCarpool", new { id = item.EventId })%>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

