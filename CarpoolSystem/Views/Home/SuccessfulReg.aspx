<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.EventModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SuccessfulReg
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Register successfully</h2>
    <h2>Thank you for registing</h2>

     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"register failed. Check your register details") %>
                <div>
                    <fieldset>
                        <legend>useful links</legend>
                            <%: Html.ActionLink("Home", "Index", "Home")%>
                            <%: Html.ActionLink("About", "About", "Home")%>
                            <%: Html.ActionLink("Event", "Event", "Home")%>
                            <%: Html.ActionLink("Search", "Search", "Home")%>
                    </fieldset>


                </div>

              

        <% } %>

</asp:Content>
