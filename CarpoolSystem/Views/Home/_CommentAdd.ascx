<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CarpoolSystem.Models.EventDisplayModel>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

            <form class="form-horizontal">
            <fieldset>
                <legend>Want to leave a comment?</legend>

                <%: Html.HiddenFor(model => model.EventSearch.Last().EventId)%>

                <div class="form-group">
                    <label for="inputEmail" class="col-lg-10 control-label"> TItle </label>

                    <div class="col-lg-10">
                        <%: Html.TextBoxFor(model => model.Title) %>
                    </div>
                </div>
                
                <div class="form-group">
                    <label for="textArea" class="col-lg-3 control-label">
                        Comment</label>
                    <div class="col-lg-10">
                        <%: Html.TextAreaFor(model => model.commentText, new { Class="form-control"  })%>
                        <span class="help-block">Add a comment and let everyone know about your experience with this carpool!</span>
                    </div>
                </div>
                
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-0">
                        <button type="submit" class="btn btn-primary">
                            Submit</button>
                    </div>
                </div>
            </fieldset>
            </form>

    <% } %>


