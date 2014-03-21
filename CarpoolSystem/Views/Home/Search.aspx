<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.SearchModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Search</h2>

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
                 
                           <div>
                               <%= Html.RadioButtonFor(m => m.radioButton, true) %> 
                               Search an Event by starting state
                           </div>
                           <p></p>
                           
                            <div><% = Html.TextBoxFor(m => m.StartingState)%>
                                <% = Html.ValidationMessageFor(m => m.StartingState)%>
                            </div>

                            <h3>Or</h3>
                            <p></p>

                             <div>
                                 <%= Html.RadioButtonFor(m => m.radioButton, false)%> 
                                 Search the site for a user
                             </div>
                             <p></p>
                            <div><% = Html.TextBoxFor(m => m.UserName)%>
                                <% = Html.ValidationMessageFor(m => m.UserName)%>
                            </div>

                            
                            
                            

                    </fieldset>
                </div>
                <p>
                    <input type="submit" value="Search" />
                </p>

        <% } %> 


         <div id = "ResultsDiv" >
        <%: Html.Partial("_SearchEvent") %>
        </div>


        <script src="<%= Url.Content("~/Scripts/MicrosoftAjax.debug.js") %>" 
		    type="text/javascript"></script>  
        <script src="<%= Url.Content("~/Scripts/MicrosoftMvcAjax.debug.js") %>" 
		    type="text/javascript"></script>
        <script src="<%= Url.Content("~/Scripts/jquery.unobtrusive-ajax.min.js") %>" 
		    type="text/javascript"></script>

</asp:Content>
