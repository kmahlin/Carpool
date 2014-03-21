<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MainMenu
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Main Menu</h2>
    <div style = "clear: left;font-weight: bold">
            <div class="display-label">Please choose your option: </div>
    </div>
    <!--
        <form method="get" action="Search.aspx">
            <input type="submit" value="Search an event" style = "clear: left;font-weight: bold;color: Black"/>
        </form>
       
        <form method="get" action="Event.aspx">
            <input type="submit" value="Create an event" style = "clear: left;font-weight: bold;color: Black"/>
        </form>

        <form method="get" action="../Account/Profile.aspx">
            <input type="submit" value="My Profile" style = "clear: left;font-weight: bold;color: Black"/>
        </form>
     --> 
    <p>
        <%: Html.ActionLink("Search an event", "Search", "Home") %> |
        <%: Html.ActionLink("Create an event", "Event", "Home") %> |
        <%: Html.ActionLink("My Profile", "Profile","Account") %>
    </p>

    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>


</asp:Content>
