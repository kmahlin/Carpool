<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Profile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Profile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Your Profile</h2>


    <img src = "<%: Model.ImagePath%>"
        alt = "File not found!"
        height ="100px"  width="100px" />

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

        <h3>Upload your image here</h3>
        <%using (Html.BeginForm("ImageUpload", "Account", FormMethod.Post, new { enctype = "multipart/form-data" }))
        {  %>
            <input type="file" name="file" />
            <input type="submit" value="OK" />
        <%} %>
        
    </fieldset>
 
    <p>
        <%: Html.ActionLink("Change Password?", "ChangePassword", "Account")%> |
        <%: Html.ActionLink("Edit Profile", "EditProfile", new { id=Model.ProfileId }) %> 
    </p>

</asp:Content>

