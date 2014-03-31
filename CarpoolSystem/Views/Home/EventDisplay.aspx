<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.EventDisplayModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EventDisplay
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Carpool Event Summary</h2>

    <h3 style="color: red"><%: ViewData["Message"]%></h3>

    <fieldset>
        <div class = "inner1">
                <h3>Carpool Details</h3>
                <div class="display-label"><strong>Title: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().Title %></div>
                <div class="display-label"><strong>Travel Type: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().Type %></div>
                <div class="display-label"><strong>Starting Address: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().StartingAddress %></div>
                <div class="display-label"><strong>Starting City: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().StartingCity %></div>
                <div class="display-label"><strong>Starting State: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().StartingState %></div>
                <div class="display-label"><strong>Ending Address: </strong></div>
                <div class="display-field"><%: Model.EventSearch.Last().DestAddress %></div>
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

            <div class = "inner1">
                <h3>Car Details</h3>
                <div class="display-label"><strong>Car Make: </strong></div>
                <div class="display-field"><%: Model.CarSearch.Last().CarMake %></div>
                <div class="display-label"><strong>Car Model: </strong></div>
                <div class="display-field"><%: Model.CarSearch.Last().CarModel%></div>
                <div class="display-label"><strong>Car Year: </strong></div>
                <div class="display-field"><%: Model.CarSearch.Last().CarYear%></div>
                <div class="display-label"><strong>Car Color: </strong></div>
                <div class="display-field"><%: Model.CarSearch.Last().CarColor%></div>
                <div class="display-label"><strong>Seats Left: </strong></div>
                <div class="display-field"><%: Model.CarSearch.Last().SeatsLeft%></div>
            </div>

            <div class = "inner1">

                <h3>Driver:</h3>
                <% foreach(var item in Model.DriverSearch) 
                 { %>
                    <div class="display-field"><%: Html.ActionLink(item.UserName, "MemberProfile", "Account", new { id = item.ProfileId }, null)%></div>
                 <% } %>
                 <br />
            </div>

            <div class = "inner1">

                <h3>Passenger List:</h3>
                <% foreach(var item in Model.PassengerSearch) 
                 { %>
                    <div class="display-field"><%: Html.ActionLink(item.UserName, "MemberProfile", "Account", new { id = item.ProfileId }, null)%></div>
                 <% } %>
                 <br />
                <a href="<%: Url.Action("JoinEvent", "Home", new { id = Model.EventSearch.Last().EventId}) %>">
                    <button class="btn btn-primary">Join Carpool?</button>
                </a>
            </div>

    </fieldset>
    <p>
        <a href="<%: Url.Action("Search", "Home") %>">
            <button class="btn btn-primary">Search for event</button>
        </a>
        <a href="<%: Url.Action("MainPage", "Home") %>">
            <button class="btn btn-primary">back to Main</button>
        </a>
    </p>

</asp:Content>

