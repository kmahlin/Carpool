<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.ChangePasswordModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ChangePassword
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Change Password</h2>

    <h3 style="color: green"><%: ViewData["Message"] %></h3>

     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Change Password Form contains invaild information. Please check your field details") %>
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Would you like to change your password?</legend>
                        <div class="form-group">
                            <%--<div>Old Password</div>--%>
                            <div><% = Html.PasswordFor(m => m.OldPassword, new { Class = "form-control", PlaceHolder = "Old Password" })%>
                                <% = Html.ValidationMessageFor(m => m.OldPassword)%>
                            </div>
                        </div>

                        <div class="form-group">
                            <%--<div>New Password</div>--%>
                            <div><% = Html.PasswordFor(m => m.NewPassword, new { Class = "form-control", PlaceHolder = "New Password" })%>
                                <% = Html.ValidationMessageFor(m => m.NewPassword)%>
                            </div>
                        </div>

                        <div class="form-group">
                            <%--<div>Confirm Password</div>--%>
                            <div><% = Html.PasswordFor(m => m.ConfirmPassword, new { Class = "form-control", PlaceHolder = "Confirm Password" })%>
                                <% = Html.ValidationMessageFor(m => m.ConfirmPassword)%>
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
</asp:Content>
