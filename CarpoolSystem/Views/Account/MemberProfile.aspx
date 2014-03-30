<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Profile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MemberProfile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Viewing <%: ViewData["User"]%>'s Profile</h2>
    
    <fieldset>
        <legend>  </legend>
        
        <div class="display-label"><strong>Email</strong></div>
        <div class="display-field"><%: Model.Emails %></div>
        
        <div class="display-label"><strong>Create Date</strong></div>
        <div class="display-field"><%: String.Format("{0:g}", Model.CreateDate) %></div>
        
        <div class="display-label"><strong>First Name</strong></div>
        <div class="display-field"><%: Model.FirstName %></div>
        
        <div class="display-label"><strong>Last Name</strong></div>
        <div class="display-field"><%: Model.LastName %></div>
        
        <div class="display-label"><strong>Phone</strong></div>
        <div class="display-field"><%: Model.Phone %></div>
        
    </fieldset>
    <p>

    </p>

</asp:Content>

