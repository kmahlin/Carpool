<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.PasswordRetrievalModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PasswordRetrieval
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Password Retrieval</h2>
     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Password Retrieval failed. Check invalid username or email") %>
                <div> 
                    <fieldset>
                        <legend>Password Retrieval Form</legend>
                 
                         <div><% = Html.LabelFor(m => m.UserName) %></div>
                         <div><% = Html.TextBoxFor(m => m.UserName)%>
                              <% = Html.ValidationMessageFor(m => m.UserName)%>
                         </div>

                         <div><% = Html.LabelFor(m => m.Email)%></div>
                         <div><% = Html.TextBoxFor(m => m.Email)%>
                              <% = Html.ValidationMessageFor(m => m.Email)%>
                         </div>

                         <div><% = Html.LabelFor(m => m.ConfirmEmail)%></div>
                         <div><% = Html.TextBoxFor(m => m.ConfirmEmail)%>
                              <% = Html.ValidationMessageFor(m => m.ConfirmEmail)%>
                         </div>
                            
                    </fieldset>
                </div>
                <p>
                   <input type="submit" value="Submit" />
                </p>
        <% } %>

</asp:Content>
