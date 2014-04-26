<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <h2>
        Main Menu</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Main Menu</h2>
    <h3>
        <%: ViewData["Message"] %></h3>
    <div style="blue: left; font-weight: bold">
        <div class="display-label">
            Please choose your option:
        </div>
        <div style="width: 500px; height: 500px">
            <div id="menu" style="background-color: #FFD700; height: 200px; width: 250px; float: right;
                display: flex; align-items: center; justify-content: center;">
                <b>
                    <%: Html.ActionLink("Search events", "Search", "Home") %>
                </b>
            </div>
            <div id="menu" style="background-color: #FF9900; height: 200px; width: 250px; float: right;
                display: flex; align-items: center; justify-content: center;">
                <b>
                    <%: Html.ActionLink("Create an event", "Event", "Home") %></b>
            </div>
            <div id="content" style="background-color: #FFD700; height: 200px; width: 250px;
                float: left; display: flex; align-items: center; justify-content: center;">
                <%: Html.ActionLink("My Profile", "Profile","Account") %></div>
            <div id="content" style="background-color: #FF9900; height: 200px; width: 250px;
                float: left; display: flex; align-items: center; justify-content: center;">
                <%: Html.ActionLink("Manage your Carpools", "ManageEvent", "Home")%></div>
        </div>
        <b>
            <%: Html.ActionLink("Search events", "Search", "Home") %>
            |
            <%: Html.ActionLink("Create an event", "Event", "Home") %>
            |
            <%: Html.ActionLink("My Profile", "Profile","Account") %>|
            <%: Html.ActionLink("Manage your Carpools", "ManageEvent", "Home")%>
        </b>
</asp:Content>
