<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.EventDisplayModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EventDisplay
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Here is your event creation summary</h2>

    <fieldset>
        <div class ="inner1" style = "font-weight: bold;color: Black">
            <div class="display-label">Title: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().Title %></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Starting Address: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().StartingAddress %></div>
        </div>
    
        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Starting City: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().StartingCity %></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Starting State: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().StartingState %></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Ending Address: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().EndingAddress %></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Destination City: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().DestCity %></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Destination State: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().DestState %></div>
        </div>
      
        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Starting Time: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().StartingTime %></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Ending Time: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().EndingTime %></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Event Info: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().EventInfo %></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Days: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.EventSearch.Last().Days %></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Car Make: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.CarSearch.Last().CarMake %></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Car Model: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.CarSearch.Last().CarModel%></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Car Year: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.CarSearch.Last().CarYear%></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Car Color: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.CarSearch.Last().CarColor%></div>
        </div>

        <div class ="inner1" style = "clear: left;font-weight: bold;color: Black">
            <div class="display-label">Total Seats: </div>
        </div>
        <div class ="inner1">
            <div class="display-field"><%: Model.CarSearch.Last().TotalSeats%></div>
        </div>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

