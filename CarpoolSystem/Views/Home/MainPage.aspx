<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MainMenu
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Main Menu</h2>

    <h3><%: ViewData["Message"] %></h3>

    <% %>
    <div style = "clear: left;font-weight: bold">
            <div class="display-label">Please choose your option: </div>
    </div>

    <div style = "background-color: Black; width: 200px; height:200px;">
        <%: Html.ActionLink("Search events", "Search", "Home") %> 
    </div>


    <p>
        <%: Html.ActionLink("Search events", "Search", "Home") %> |
        <%: Html.ActionLink("Create an event", "Event", "Home") %> |
        <%: Html.ActionLink("My Profile", "Profile","Account") %>|
        <%: Html.ActionLink("Manage your Carpools", "ManageEvent", "Home")%>
    </p>


</asp:Content>
