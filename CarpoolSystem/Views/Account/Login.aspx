<%@ Page Title="Login" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.LogInModel>" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LogIn
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       
    <h2>Welcome to Kalonji's Carpool System</h2>

    <h3><%: ViewData["Message"] %></h3>
     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Login failed. Check your login details") %>
                <div class="form-horizontal">
                        <fieldset>
                            <legend>Please Log in</legend>

                                <div class="form-group">
                                   <%--<div>User name</div>--%>
                                    <div><% = Html.TextBoxFor(m => m.UserName, new { Class = "form-control", PlaceHolder = "user name" })%>
                                        <% = Html.ValidationMessageFor(m => m.UserName)%>
                                    </div>
                                </div>
                                             
                                <div class="form-group">
                                    <%--<div>Password</div>--%>
                                    <div><% = Html.PasswordFor(m => m.Password, new { Class = "form-control", PlaceHolder = "password" })%>
                                        <% = Html.ValidationMessageFor(m => m.Password) %>
                                    </div>
                                </div>
                        </fieldset>
                </div>

                <div class="form-group">
                  <div class=" col-lg-offset-2">
                    <button type="submit" class="btn btn-primary">Submit</button>
                  </div>
                </div>

        <% } %>
             <div>Not registered? <%: Html.ActionLink("Click Here", "Registration", "Account")%></div>
             <div>Forgot your password? <%: Html.ActionLink("recover account", "PasswordRetrieval", "Account")%></div>
</asp:Content>