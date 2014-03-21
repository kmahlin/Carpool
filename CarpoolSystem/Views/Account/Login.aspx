<%@ Page Title="Login" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.LogInModel>" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LogIn
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       
    <h2>Welcome to Kalonji's Carpool System</h2>

    <h3><%: ViewData["Message"] %></h3>
     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Login failed. Check your login details") %>
                <div>
     
                    <fieldset>
                        <legend>Please Log in</legend>
                 
                           <div><% = Html.LabelFor(m => m.UserName) %></div>
                            <div><% = Html.TextBoxFor(m => m.UserName)%>
                                <% = Html.ValidationMessageFor(m => m.UserName)%>
                            </div>

                             <div><% = Html.LabelFor(m => m.Password)%></div>
                            <div><% = Html.PasswordFor(m => m.Password)%>
                                <% = Html.ValidationMessageFor(m => m.Password)%>
                            </div>
                            
                    </fieldset>


                </div>

                <p>
                    <input type="submit" value="Log in" />
                </p> 

        <% } %>
             <div>Not registered? <%: Html.ActionLink("Click Here", "Registration", "Account")%></div>
             <div>Forgot your password? <%: Html.ActionLink("recover account", "PasswordRetrieval", "Account")%></div>
</asp:Content>