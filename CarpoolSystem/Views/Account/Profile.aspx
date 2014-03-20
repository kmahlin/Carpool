<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Profile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Profile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Profile</h2>

    <fieldset>
        <div class="display-label"><strong>Email</strong></div>
        <div class="display-field"><%: Model.Emails %></div>
        
        <div class="display-label"><strong>Create Date</strong></div>
        <div class="display-field"><%: String.Format("{0:g}", Model.CreateDate) %></div>
        
        <div class="display-label"><strong>FirstName</strong></div>
        <div class="display-field"><%: Model.FirstName %></div>
        
        <div class="display-label"><strong>LastName</strong></div>
        <div class="display-field"><%: Model.LastName %></div>
       
        <div class="display-label"><strong>Phone</strong></div>
        <div class="display-field"><%: Model.Phone %></div>

        
    </fieldset>
 
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ProfileId }) %> |
        <%: Html.ActionLink("Event", "Event") %>
    </p>

</asp:Content>

