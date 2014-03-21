<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.SearchModel>" %>

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
                 
                           <div><% = Html.LabelFor(m => m.StartingState) %></div>
                            <div><% = Html.TextBoxFor(m => m.StartingState)%>
                                <% = Html.ValidationMessageFor(m => m.StartingState)%>
                            </div>

                             <div><% = Html.LabelFor(m => m.UserName)%></div>
                            <div><% = Html.TextBoxFor(m => m.UserName)%>
                                <% = Html.ValidationMessageFor(m => m.UserName)%>
                            </div>

                    </fieldset>
                </div>
                <p>
                    <input type="submit" value="Search" />
                </p>

        <% } %>
         <div >
        <% Html.RenderPartial("_SearchEvent"); %>
        </div>

        

</asp:Content>
