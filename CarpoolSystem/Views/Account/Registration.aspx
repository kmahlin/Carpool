
<%@ Page Title="registration" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.AccountModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Registration
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Welcome to sign up</h2>

     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Registration failed. Check your registration details") %>
                <div class="form-horizontal">
                        <fieldset >
                            <legend>Registration Form</legend>
                                <div class="form-group">
                                   <div>User name</div>
                                    <div><% = Html.TextBoxFor(m => m.UserName, new { Class = "form-control"})%>
                                        <% = Html.ValidationMessageFor(m => m.UserName)%>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div>First name</div>
                                    <div><% = Html.TextBoxFor(m => m.FirstName, new { Class = "form-control" })%>
                                        <% = Html.ValidationMessageFor(m => m.FirstName)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div>Last name</div>
                                    <div><% = Html.TextBoxFor(m => m.LastName, new { Class = "form-control" })%>
                                        <% = Html.ValidationMessageFor(m => m.LastName)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div>Email</div>
                                    <div><% = Html.TextBoxFor(m => m.Email, new { Class = "form-control" })%>
                                        <% = Html.ValidationMessageFor(m => m.Email)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div>Phone</div>
                                    <div><% = Html.TextBoxFor(m => m.Phone, new { Class = "form-control" })%>
                                        <% = Html.ValidationMessageFor(m => m.Phone)%>
                                    </div>
                                </div>
                            
                                <div class="form-group">
                                    <div>Password</div>
                                    <div><% = Html.PasswordFor(m => m.Password, new { Class = "form-control" })%>
                                        <% = Html.ValidationMessageFor(m => m.Password) %>
                                    </div>
                                </div>
                            </fieldset >
                        
                </div>

                <div class="form-group">
                  <div class=" col-lg-offset-2">
                    <button type="submit" class="btn btn-primary">Submit</button>
                  </div>
                </div>

        <% } %>

</asp:Content>
