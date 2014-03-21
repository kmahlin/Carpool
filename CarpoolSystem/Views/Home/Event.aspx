
<%@ Page Title="Event" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CarpoolSystem.Models.EventModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Event
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Carpool Event</h2>

     <% using (Html.BeginForm() ){ %>

            <%: Html.ValidationSummary(true,"Event create failed. Check your login details") %>
                <div id = "warpper">
                    <fieldset>
                        <legend>Event Create Form</legend>
                            <div class ="title"><% = Html.LabelFor(m => m.Title) %></div>
                            <div class ="title"><% = Html.TextBoxFor(m => m.Title)%>
                                <% = Html.ValidationMessageFor(m => m.Title)%>
                            </div>
                 
                           
                            <div class ="inner1" >
                            <h3>Starting Location</h3>
                                <div><% = Html.LabelFor(m => m.StartingAddress)%></div>
                                <div><% = Html.TextBoxFor(m => m.StartingAddress)%>
                                    <% = Html.ValidationMessageFor(m => m.StartingAddress)%>
                                </div>

                                <div><% = Html.LabelFor(m => m.StartingCity)%></div>
                                <div><% = Html.TextBoxFor(m => m.StartingCity)%>
                                <% = Html.ValidationMessageFor(m => m.StartingCity)%>
                                </div>

                                <div><% = Html.LabelFor(m => m.StartingState)%></div>
                                <div><% = Html.TextBoxFor(m => m.StartingState)%>
                                <% = Html.ValidationMessageFor(m => m.StartingState)%>
                                </div>

                                

                            </div>

                            
                            
                            <div class ="inner1">
                            <h3>Destination Location</h3>
                                <div><% = Html.LabelFor(m => m.DestAddress)%></div>
                                <div><% = Html.TextBoxFor(m => m.DestAddress)%>
                                    <% = Html.ValidationMessageFor(m => m.DestAddress)%>
                                </div>
                            
                                <div><% = Html.LabelFor(m => m.DestCity)%></div>
                                <div><% = Html.TextBoxFor(m => m.DestCity)%>
                                    <% = Html.ValidationMessageFor(m => m.DestCity)%>
                                </div>

                                <div><% = Html.LabelFor(m => m.DestState)%></div>
                                <div><% = Html.TextBoxFor(m => m.DestState)%>
                                    <% = Html.ValidationMessageFor(m => m.DestState)%>
                                </div>

                                
                            </div>


                            <div class ="inner1" style = "clear: left">
                            <h3>Departure and Returning times</h3>
                                <div style = "font-weight: bold ; padding: 0em 0em .8em 0em">
                                I want to leave the Starting location by...
                                </div>
                                <div><% = Html.TextBoxFor(m => m.StartingTime)%>
                                <% = Html.ValidationMessageFor(m => m.StartingTime)%>
                                </div>
                                <div style = "font-weight: bold ; padding: .8em 0em .8em 0em">
                                I want to leave the destination location by...
                                </div>
                                <div><% = Html.TextBoxFor(m => m.EndingTime)%>
                                <% = Html.ValidationMessageFor(m => m.EndingTime)%>
                                </div>
                            </div>



                            <div class = "inner2">
                                <h3>Days of the week</h3>
                                <div><% = Html.LabelFor(m => m.Days) %></div>
                                <div><% = Html.TextBoxFor(m => m.Days)%>
                                    <% = Html.ValidationMessageFor(m => m.Days)%>
                                </div>
                                
                                <h3>Additonal Information</h3>
                                 <div><% = Html.LabelFor(m => m.EventInfo) %></div>
                                <div><% = Html.TextAreaFor(m => m.EventInfo)%>
                                    <% = Html.ValidationMessageFor(m => m.EventInfo)%>
                                </div>
                            </div>

                            
                           <div class = "inner2">
                           <h3>Car Information</h3>
                                <div><% = Html.LabelFor(m => m.CarMake) %></div>
                                <div><% = Html.TextBoxFor(m => m.CarMake)%>
                                    <% = Html.ValidationMessageFor(m => m.CarMake)%>
                                </div>

                                 <div><% = Html.LabelFor(m => m.CarModel)%></div>
                                <div><% = Html.TextBoxFor(m => m.CarModel)%>
                                    <% = Html.ValidationMessageFor(m => m.CarModel)%>
                                </div>

                                <div><% = Html.LabelFor(m => m.CarYear)%></div>
                                <div><% = Html.TextBoxFor(m => m.CarYear)%>
                                    <% = Html.ValidationMessageFor(m => m.CarYear)%>
                                </div>

                                <div><% = Html.LabelFor(m => m.CarColor)%></div>
                                <div><% = Html.TextBoxFor(m => m.CarColor)%>
                                    <% = Html.ValidationMessageFor(m => m.CarColor)%>
                                </div>

                                <div><% = Html.LabelFor(m => m.TotalSeats)%></div>
                                <div><% = Html.TextBoxFor(m => m.TotalSeats)%>
                                    <% = Html.ValidationMessageFor(m => m.TotalSeats)%>
                                </div>
                          </div>
                    </fieldset>
                </div>

                <p>
                    <input type="submit" value="Create" />
                </p>

        <% } %>

</asp:Content>
