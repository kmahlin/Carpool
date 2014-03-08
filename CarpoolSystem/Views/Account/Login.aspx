<%@ Page Title="Login" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.AccountModel>" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LogIn
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       
    <h2>Welcome to Kalonji's Carpool System</h2>

     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Search failed. Check your search details") %>
                <div>
     
                    <fieldset>
                        <legend>Log In Form</legend>
                 
                           <div><% = Html.LabelFor(m => m.UserName) %></div>
                            <div><% = Html.TextBoxFor(m => m.UserName)%>
                                <% = Html.ValidationMessageFor(m => m.UserName)%>
                            </div>

                             <div><% = Html.LabelFor(m => m.Password)%></div>
                            <div><% = Html.TextBoxFor(m => m.Password)%>
                                <% = Html.ValidationMessageFor(m => m.Password)%>
                            </div>
                            
                    </fieldset>


                </div>

                <p>
                   </p> <input type="submit" value="Log in" />
                </p>

        <% } %>
             <p>Not registered? <%: Html.ActionLink("Click Here", "Registration", "Account")%></p>
</asp:Content>