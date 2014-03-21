<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%: Page.User.Identity.Name %></b>!
        [ <%: Html.ActionLink("Log Off", "LogOut", "Account") %> ]
        [ <%: Html.ActionLink("Profile", "Profile", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Log On", "Login", "Account") %> ]
<%
    }
%>