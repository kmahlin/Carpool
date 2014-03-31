<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.ManageEventModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ManageEvent
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Carpools you're a part of:</h2>
    <br />



    <h4>You're the driver of:</h4>
    <table>

    <% foreach (var item in Model.DriverEvent) { %>
        <tr>
            <td><%: Html.ActionLink(item.Title, "EventDisplay", new { id = item.EventId })%></td>
            <td>
                <%--<%: Html.ActionLink("Edit", "Edit", new { id=item.EventId }) %> |--%>
                <%--<%: Html.ActionLink("Delete carpool?", "RemoveCarpool", new { id = item.EventId })%>--%>
                <a href="<%: Url.Action("RemoveCarpool", "Home", new { id = item.EventId }) %>">
                    <button class="btn btn-danger">Delete carpool?</button>
                </a>
            </td>
        </tr>
    
    <% } %>

    </table>

        <h4>You're a passenger of:</h4>
    <table>

    <% foreach (var item in Model.PassengerEvent) { %>
    
        <tr>
            <td><%: Html.ActionLink(item.Title, "EventDisplay", new { id = item.EventId })%></td>
            <td>
            <%--<%: Html.ActionLink("Leave carpool?", "LeaveCarpool", new { id = item.EventId })%>--%>
            <a href="<%: Url.Action("LeaveCarpool", "Home", new { id = item.EventId }) %>">
                <button class="btn btn-warning">Leave carpool?</button>
            </a>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

