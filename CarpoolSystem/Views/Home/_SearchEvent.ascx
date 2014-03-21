<%@ Control Language="C#"  Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<CarpoolSystem.Event>>" %>

<% if (Model != null){ %>
        <table>
            <tr>
                <th></th>
                <th>
                    EventId
                </th>
                <th>
                    Title
                </th>
                <th>
                    StartingTime
                </th>
                <th>
                    EndingTime
                </th>
                <th>
                    EventInfo
                </th>
                <th>
                    StartingAddress
                </th>
                <th>
                    EndingAddress
                </th>
                <th>
                    DestCity
                </th>
                <th>
                    DestState
                </th>
                <th>
                    StartingState
                </th>
                <th>
                    StartingCity
                </th>
                <th>
                    Days
                </th>
            </tr>


       <%    foreach (var item in Model ) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.EventId }) %> |
            </td>
            <td>
                <%: item.EventId %>
            </td>
            <td>
                <%: item.Title %>
            </td>
            <td>
                <%: item.StartingTime %>
            </td>
            <td>
                <%: item.EndingTime %>
            </td>
            <td>
                <%: item.EventInfo %>
            </td>
            <td>
                <%: item.StartingAddress %>
            </td>
            <td>
                <%: item.EndingAddress %>
            </td>
            <td>
                <%: item.DestCity %>
            </td>
            <td>
                <%: item.DestState %>
            </td>
            <td>
                <%: item.StartingState %>
            </td>
            <td>
                <%: item.StartingCity %>
            </td>
            <td>
                <%: item.Days %>
            </td>
        </tr>
    
        <% } %>
           
    </table>
    <% } %>


