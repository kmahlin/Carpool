<%@ Control Language="C#"  Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<CarpoolSystem.Event>>" %>

<% var results = (IEnumerable<CarpoolSystem.Event>)ViewData["EventResults"];
    
    if (results != null)
    {
        if (results.Count() > 0)
        { %>
            <table class="table table-striped table-hover ">
                <thead>
                    <tr class="info"  >
                        <th>Title</th>
                        <th>Travel Type</th>
                        <th>Starting time</th>
                        <th>Ending time</th>
                        <%--<th>Starting address</th>--%>
                        <th>Starting state</th>
                        <th>Starting city</th>
                        <%--<th>Destination address</th>--%>
                        <th>Dest. city</th>
                        <th>Dest. state</th>
                        <th>Days</th>
                        <%--<th>Event info</th>--%>
                    </tr>
                </thead>

            <% foreach (CarpoolSystem.Event item in results)
                    { %>
                <tbody>
                    <tr>
                        <td><%: Html.ActionLink(item.Title, "EventDisplay", new { id = item.EventId })%></td>
                        <td><%: item.Type %></td>
                        <td><%: item.StartingTime %></td>
                        <td><%: item.EndingTime %></td>
                        <%--<td><%: item.StartingAddress %></td>--%>
                        <td><%: item.StartingState %></td>
                        <td><%: item.StartingCity %></td>
                        <%--<td><%: item.DestAddress %> </td>--%>
                        <td><%: item.DestCity %></td>
                        <td><%: item.DestState %></td>
                        <td><%: item.Days %></td>
                        <%--<td><%: item.EventInfo %></td>--%>
                    </tr>
                </tbody>
            <% } %>
           
            </table>
        <% }
        else
        { %>
            <p>Sorry, no events were found.</p>
     <% } %> 
    <% } %> 
   


