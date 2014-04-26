<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CarpoolSystem.Models.EventDisplayModel>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Add a comment</legend>
            <%: Html.HiddenFor(model => model.EventSearch.Last().EventId)%>


            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.commentText) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.commentText)%>
                <%: Html.ValidationMessageFor(model => model.commentText)%>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>



        </fieldset>

    <% } %>


