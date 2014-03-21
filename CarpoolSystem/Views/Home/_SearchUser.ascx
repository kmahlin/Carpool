<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<CarpoolSystem.User>>" %>

<% var results = (IEnumerable<CarpoolSystem.User>)ViewData["UserResults"];

if (results != null)
{
    if (results.Count() > 0)
    { %>
        <table>
            <tr>
                <th>UserName</th>
            </tr>

        <% foreach (CarpoolSystem.User item in results)
           { %>
    
            <tr>
                <td><%: item.UserName %></td>
            </tr>
    
        <% } %>

        </table>

    <% }
     else
     { %>
        <p>Sorry, no users were found by that name</p>
     <% } %> 
<% } %> 