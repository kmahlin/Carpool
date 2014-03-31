
<%@ Page Title="Event" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.EventModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Event
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Start a new carpool</h2>

     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Event creation failed. Check your details") %>
                <div class="form-horizontal">
                    <fieldset>
                        <legend></legend>

                            <div class="form-group">
                                <h4>Title</h4>
                                <div><% = Html.TextBoxFor(m => m.Title, new { Class = "form-control", PlaceHolder = "Give the Event a name" })%>
                                    <% = Html.ValidationMessageFor(m => m.Title)%>
                                </div>
                            </div>

                            <div class="form-group">
                                 <h4>Travel Type</h4>
                                <div>
                                  <h6> <%= Html.RadioButtonFor(m => m.TypeRadio, true, new { @checked = "checked" })%> 
                                   Commuter/Recurring (i.e. School commuter, daily commute, etc.)</h6>
                               </div>
                               <div>
                                   <h6><%= Html.RadioButtonFor(m => m.TypeRadio, false) %> 
                                   One Time Event (i.e. sporting event, concert, etc.)</h6>
                               </div>
                            </div>
                           
                            <div class ="inner1" >

                                <div class="form-group">
                                <h4>Starting Location</h4>
                                    <div><% = Html.TextBoxFor(m => m.StartingAddress, new { Class = "form-control", PlaceHolder = "Starting Street" })%>
                                        <% = Html.ValidationMessageFor(m => m.StartingAddress)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div><% = Html.TextBoxFor(m => m.StartingCity, new { Class = "form-control", PlaceHolder = "Starting City" })%>
                                            <% = Html.ValidationMessageFor(m => m.StartingCity)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div><% = Html.TextBoxFor(m => m.StartingState, new { Class = "form-control", PlaceHolder = "Starting State" })%>
                                            <% = Html.ValidationMessageFor(m => m.StartingState)%>
                                    </div>
                                </div>
                                
                            </div>

                            <div class ="inner1" >

                                <div class="form-group">
                                <h4>Destination Location</h4>
                                    <div><% = Html.TextBoxFor(m => m.DestAddress, new { Class = "form-control", PlaceHolder = "Destination Street" })%>
                                        <% = Html.ValidationMessageFor(m => m.DestAddress)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div><% = Html.TextBoxFor(m => m.DestCity, new { Class = "form-control", PlaceHolder = "Destination City" })%>
                                            <% = Html.ValidationMessageFor(m => m.DestCity)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div><% = Html.TextBoxFor(m => m.DestState, new { Class = "form-control", PlaceHolder = "Destination State" })%>
                                            <% = Html.ValidationMessageFor(m => m.DestState)%>
                                    </div>
                                </div>
                                
                            </div>


                            <div class ="inner1" style = "clear: left">
                                <div class="form-group">
                                    <h4>Departure and Returning times</h4>
                                    <div><% = Html.TextBoxFor(m => m.StartingTime, new { Class = "form-control", PlaceHolder = "Leave starting location by..." })%>
                                    <% = Html.ValidationMessageFor(m => m.StartingTime)%>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div><% = Html.TextBoxFor(m => m.EndingTime, new { Class = "form-control", PlaceHolder = "Leave dest. location by..." })%>
                                    <% = Html.ValidationMessageFor(m => m.EndingTime)%>
                                    </div>
                                </div>
                            </div>



                             <div class = "inner2">
                                <div class="form-group">
                                    <h4>Start and End date of Event</h4>
                                    <div><% = Html.TextBoxFor(m => m.EventStartDate, new { Class = "form-control", PlaceHolder = "Starting Date of Event" })%>
                                        <% = Html.ValidationMessageFor(m => m.EventStartDate)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div><% = Html.TextBoxFor(m => m.EventEndDate, new { Class = "form-control", PlaceHolder = "Ending Date of Event" })%>
                                        <% = Html.ValidationMessageFor(m => m.EventEndDate)%>
                                    </div>
                                </div>
                            </div>



                            <div class = "inner2">
                                <div class="form-group">
                                    <h4>Days of the week</h4>
                                    <div><% = Html.TextBoxFor(m => m.Days, new { Class = "form-control", PlaceHolder = "i.e. MTWTF" })%>
                                        <% = Html.ValidationMessageFor(m => m.Days)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <h4>Additonal Information</h4>
                                    <div><% = Html.TextAreaFor(m => m.EventInfo, new { Class = "form-control", PlaceHolder = "additional carpool information" })%>
                                        <% = Html.ValidationMessageFor(m => m.EventInfo)%>
                                    </div>
                                </div>
                            </div>

                            
                           <div class = "inner2">
                                <div class="form-group">
                                    <h4>Car Information</h4>
                                    <div><% = Html.TextBoxFor(m => m.CarMake, new { Class = "form-control", PlaceHolder = "Car's Make (i.e. Toyota)" })%>
                                        <% = Html.ValidationMessageFor(m => m.CarMake)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div><% = Html.TextBoxFor(m => m.CarModel, new { Class = "form-control", PlaceHolder = "Car's Model (i.e. Camry)" })%>
                                        <% = Html.ValidationMessageFor(m => m.CarModel)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div><% = Html.TextBoxFor(m => m.CarYear, new { Class = "form-control", PlaceHolder = "Year of car (i.e. 2005)" })%>
                                        <% = Html.ValidationMessageFor(m => m.CarYear)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div><% = Html.TextBoxFor(m => m.CarColor, new { Class = "form-control", PlaceHolder = "Car's color" })%>
                                        <% = Html.ValidationMessageFor(m => m.CarColor)%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div><% = Html.TextBoxFor(m => m.TotalSeats, new { Class = "form-control", PlaceHolder = " # of Seats available" })%>
                                        <% = Html.ValidationMessageFor(m => m.TotalSeats)%>
                                    </div>
                                </div
                          </div>
                    </fieldset>
                </div>

                <div class="form-group">
                  <div class=" col-lg-offset-2">
                    <button type="submit" class="btn btn-primary">Submit</button>
                  </div>
                </div>

        <% } %>

</asp:Content>
