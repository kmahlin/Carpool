﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.ChangePasswordModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ChangePassword
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ChangePassword</h2>
     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Login failed. Check your search details") %>
                <div> 
                    <fieldset>
                        <legend>Log In Form</legend>
                 
                         <div><% = Html.LabelFor(m => m.OldPassword) %></div>
                         <div><% = Html.TextBoxFor(m => m.OldPassword)%>
                              <% = Html.ValidationMessageFor(m => m.OldPassword)%>
                         </div>

                         <div><% = Html.LabelFor(m => m.NewPassword)%></div>
                         <div><% = Html.TextBoxFor(m => m.NewPassword)%>
                              <% = Html.ValidationMessageFor(m => m.NewPassword)%>
                         </div>

                         <div><% = Html.LabelFor(m => m.ConfirmPassword)%></div>
                         <div><% = Html.TextBoxFor(m => m.ConfirmPassword)%>
                              <% = Html.ValidationMessageFor(m => m.ConfirmPassword)%>
                         </div>
                            
                    </fieldset>
                </div>
                <p>
                   <input type="submit" value="Log in" />
                </p>
        <% } %>
</asp:Content>
