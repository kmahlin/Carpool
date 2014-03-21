<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.EventDisplayModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EventDisplay
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Here is your event creation summary</h2>

    <fieldset>
        <div class ="inner1">
                <div class="display-label"><strong>Title: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().Title %></div>
                <div class="display-label"><strong>Starting Address: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().StartingAddress %></div>
                <div class="display-label"><strong>Starting City: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().StartingCity %></div>
                <div class="display-label"><strong>Starting State: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().StartingState %></div>
                <div class="display-label"><strong>Ending Address: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().EndingAddress %></div>
                <div class="display-label"><strong>Destination City: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().DestCity %></div>
                <div class="display-label"><strong>Destination State: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().DestState %></div>
                <div class="display-label"><strong>Starting Time: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().StartingTime %></div>
                <div class="display-label"><strong>Ending Time: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().EndingTime %></div>
                <div class="display-label"><strong>Event Info: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().EventInfo %></div>
                <div class="display-label"><strong>Days: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().Days %></div>
            </div>

            <div class ="inner1">
                <div class="display-label"><strong>Car Make: </strong></div>
                <div class="display-field"><%: Model.CarSearch.Last().CarMake %></div>
                <div class="display-label"><strong>Car Model: </strong></div>
                <div class="display-field"><%: Model.CarSearch.Last().CarModel%></div>
                <div class="display-label"><strong>Car Year: </strong></div>
                <div class="display-field"><%: Model.CarSearch.Last().CarYear%></div>
                <div class="display-label"><strong>Car Color: </strong></div>
                <div class="display-field"><%: Model.CarSearch.Last().CarColor%></div>
                <div class="display-label"><strong>Total Seats: </strong></div>
                <div class="display-field"><%: Model.CarSearch.Last().TotalSeats%></div>
            </div>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

