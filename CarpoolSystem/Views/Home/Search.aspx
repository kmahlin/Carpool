<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.SearchModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Search event by state</h2>

     <% using (Ajax.BeginForm("SearchResults", // <<Action Name
                new AjaxOptions
                {
                    UpdateTargetId = "ResultsDiv", // << element to update
                    InsertionMode = InsertionMode.Replace, //replace content
                    HttpMethod = "POST",
                }))
        { %>

            <%: Html.ValidationSummary(true, "Search failed. Check your search details")%>
                <div>
                    <fieldset>
                        <legend></legend>
                            <div><% = Html.TextBoxFor(m => m.StartingState, new { placeholder = "Starting State" })%>
                                <% = Html.ValidationMessageFor(m => m.StartingState)%>
                            </div>

                            <div><% = Html.TextBoxFor(m => m.DestState, new { placeholder = "Ending State" })%>
                                <% = Html.ValidationMessageFor(m => m.DestState)%>
                            </div>

                    </fieldset>
                </div>
                <p>
                    <input type="submit" value="Search" />
                </p>

        <% } %> 
        <%--<div id="googleMap" style="height:150px;"></div>--%>

         <div id = "ResultsDiv" >
        <%: Html.Partial("_SearchEvent") %>
        </div>


        <script src="<%= Url.Content("~/Scripts/MicrosoftAjax.debug.js") %>" 
		    type="text/javascript"></script>  
        <script src="<%= Url.Content("~/Scripts/MicrosoftMvcAjax.debug.js") %>" 
		    type="text/javascript"></script>
        <script src="<%= Url.Content("~/Scripts/jquery.unobtrusive-ajax.min.js") %>" 
		    type="text/javascript"></script>
        <script src="../../Scripts/googleMap.js" 
            type="text/javascript"></script>


</asp:Content>
