﻿<%@ Page Title="registration" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.ProfileModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Profile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Welcome to profile page</h2>

     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"command failed") %>
                <div>
                    <fieldset>
                        <legend>Registration Form</legend>

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
                            <div><% = Html.DisplayFor(m => m.Address)%>
                               
                            </div>

                            <div><% = Html.LabelFor(m => m.Phone) %></div>
                            <div><% = Html.TextBoxFor(m => m.Phone)%>
                                <% = Html.ValidationMessageFor(m => m.Phone)%>
                            </div>
                            
                            <div><% = Html.LabelFor(m => m.Password) %></div>
                            <div><% = Html.PasswordFor(m => m.Password) %>
                                <% = Html.ValidationMessageFor(m => m.Password) %>
                            </div>

                    </fieldset>


                </div>

                <p>
                    <input type="submit" value="register" />
                </p>

        <% } %>

</asp:Content>