<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Profile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditProfile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditProfile</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend></legend>
            <div class="form-horizontal">

                <div class="form-group">
                    <div>Email</div>
                    <div><% = Html.TextBoxFor(m => m.Emails, new { Class = "form-control" })%>
                        <% = Html.ValidationMessageFor(m => m.Emails)%>
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
                    <div>Phone</div>
                    <div><% = Html.TextBoxFor(m => m.Phone, new { Class = "form-control" })%>
                        <% = Html.ValidationMessageFor(m => m.Phone)%>
                    </div>
                </div>

            </div>
            
            
            <div class="form-group">
                <div class=" col-lg-offset-2">
                <button type="submit" class="btn btn-primary">Submit</button>
                </div>
            </div>
        </fieldset>

    <% } %>

<%--    <div>
        <%: Html.ActionLink("Back to profile", "Profile") %>
    </div>--%>

</asp:Content>

