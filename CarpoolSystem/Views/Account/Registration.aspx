
<%@ Page Title="Login" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.AccountModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Registration
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registration</h2>

     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Login failed. Check your login details") %>
                <div>
                    <fieldset>
                        <legend>Login Form</legend>

                           <div><% = Html.LabelFor(m => m.UserName) %></div>
                            <div><% = Html.TextBoxFor(m => m.UserName)%>
                                <% = Html.ValidationMessageFor(m => m.UserName)%>
                            </div>

                            <div><% = Html.LabelFor(m => m.FirstName) %></div>
                            <div><% = Html.TextBoxFor(m => m.FirstName)%>
                                <% = Html.ValidationMessageFor(m => m.FirstName)%>
                            </div>

                            <div><% = Html.LabelFor(m => m.LastName) %></div>
                            <div><% = Html.TextBoxFor(m => m.LastName)%>
                                <% = Html.ValidationMessageFor(m => m.LastName)%>
                            </div>

                            <div><% = Html.LabelFor(m => m.Email) %></div>
                            <div><% = Html.TextBoxFor(m => m.Email)%>
                                <% = Html.ValidationMessageFor(m => m.Email)%>
                            </div>

                            <div><% = Html.LabelFor(m => m.Address) %></div>
                            <div><% = Html.TextBoxFor(m => m.Address)%>
                                <% = Html.ValidationMessageFor(m => m.Address)%>
                            </div>

                            <div><% = Html.LabelFor(m => m.Phone) %></div>
                            <div><% = Html.TextBoxFor(m => m.Phone)%>
                                <% = Html.ValidationMessageFor(m => m.Phone)%>
                            </div>
                            S
                            <div><% = Html.LabelFor(m => m.Password) %></div>
                            <div><% = Html.PasswordFor(m => m.Password) %>
                                <% = Html.ValidationMessageFor(m => m.Password) %>
                            </div>

                    </fieldset>


                </div>

                <p>
                    <input type="submit" value="Create" />
                </p>

        <% } %>

</asp:Content>
