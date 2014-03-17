﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.EventModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Search</h2>

     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Search failed. Check your search details") %>
                <div>
                    <fieldset>
                        <legend>Event Search Form</legend>
                 
                           <div><% = Html.LabelFor(m => m.Title) %></div>
                            <div><% = Html.TextBoxFor(m => m.Title)%>
                                <% = Html.ValidationMessageFor(m => m.Title)%>
                            </div>

                             <div><% = Html.LabelFor(m => m.StartingAddress)%></div>
                            <div><% = Html.TextBoxFor(m => m.StartingAddress)%>
                                <% = Html.ValidationMessageFor(m => m.StartingAddress)%>
                            </div>

                             <div><% = Html.LabelFor(m => m.DestAddress)%></div>
                            <div><% = Html.TextBoxFor(m => m.DestAddress)%>
                                <% = Html.ValidationMessageFor(m => m.DestAddress)%>
                            </div>

                             <div><% = Html.LabelFor(m => m.StartTime) %></div>
                            <div><% = Html.TextBoxFor(m => m.StartTime)%>
                                <% = Html.ValidationMessageFor(m => m.StartTime)%>
                            </div>

                             <div><% = Html.LabelFor(m => m.EndTime) %></div>
                            <div><% = Html.TextBoxFor(m => m.EndTime)%>
                                <% = Html.ValidationMessageFor(m => m.EndTime)%>
                            </div>

                             <div><% = Html.LabelFor(m => m.EventInfo) %></div>
                            <div><% = Html.TextBoxFor(m => m.EventInfo)%>
                                <% = Html.ValidationMessageFor(m => m.EventInfo)%>
                            </div>


                            
                    </fieldset>


                </div>

                <p>
                    <input type="submit" value="Search" />
                </p>

        <% } %>

</asp:Content>
