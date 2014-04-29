<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.PasswordRetrievalModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PasswordRetrieval
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Password Retrieval</h2>
     <% using (Html.BeginForm() ){ %>
     <h3 style="color: green"><%: ViewData["Message"]%></h3>

            <%: Html.ValidationSummary(true,"Password Retrieval failed. Check invalid username or email") %>
                <div class="form-horizontal"> 
                    <fieldset>
                        <legend></legend>
                 
                         <div class="form-group">
                            <%--<div>User name</div>--%>
                            <div><% = Html.TextBoxFor(m => m.UserName, new { Class = "form-control", PlaceHolder = "User name" })%>
                                <% = Html.ValidationMessageFor(m => m.UserName)%>
                            </div>
                        </div>

                         <div class="form-group">
                            <%--<div>Email</div>--%>
                            <div><% = Html.TextBoxFor(m => m.Email, new { Class = "form-control", PlaceHolder = "Email" })%>
                                <% = Html.ValidationMessageFor(m => m.Email)%>
                            </div>
                        </div>

                        <div class="form-group">
                            <%--<div>Confirm Email</div>--%>
                            <div><% = Html.TextBoxFor(m => m.ConfirmEmail, new { Class = "form-control", PlaceHolder = "Confirm Email" })%>
                                <% = Html.ValidationMessageFor(m => m.ConfirmEmail)%>
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
