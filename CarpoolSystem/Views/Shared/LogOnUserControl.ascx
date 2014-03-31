<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
       
        <li><a href="<%= Url.Action("Profile", "Account") %>">Welcome <b><%: Page.User.Identity.Name %></b>!</a></li>
        <li><a href="<%= Url.Action("LogOut", "Account") %>">Log Off</a></li>

        <%--[ <%: Html.ActionLink("Log Off", "LogOut", "Account") %> ]--%>
        <%--[ <%: Html.ActionLink("Profile", "Profile", "Account") %> ]--%>
<%
    }
    else {
%> 
        <li><a href="<%= Url.Action("Login", "Account") %>">Log On</a></li>
        <%--[ <%: Html.ActionLink("Log On", "Login", "Account") %> ]--%>
<%
    }
%>