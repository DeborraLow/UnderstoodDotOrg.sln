﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Assessment Quiz.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Assessment_Quiz" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: pagetopic -->


<!-- END PARTIAL: pagetopic -->
<div class="container article knowledge-quiz-page">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: knowledge-quiz-a13a -->
            <div class="knowledge-quiz">
                <div class="question-counter">
                    <asp:Label CssClass="assessment-quiz-pager" ID="lblPageCounter" runat="server"></asp:Label>
                    <p class="assessment-quiz-intro" id="divIntro" runat="server">
                        <sc:FieldRenderer ID="frQuizIntro" runat="server" FieldName="Body Content" />
                    </p>
                    <h3 class="assessment-result-intro"><sc:FieldRenderer ID="frResultHeadline" runat="server" FieldName="Quiz Result Headline" Visible="false"></sc:FieldRenderer></h3>
                    <%--Question 1 of 10--%>
                </div>
                <p class="assessment-result-description">
                    <sc:FieldRenderer ID="frEndExplanation" runat="server" FieldName="Detail" Visible="false"></sc:FieldRenderer>
                </p>
                <asp:Repeater ID="rptPageQuestions" runat="server" OnItemDataBound="rptPageQuestions_ItemDataBound">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <h3><%--True or False? Kids with dyslexia can never learn what other kids learn.--%>
                            <sc:FieldRenderer ID="frQuestionTitle" runat="server" FieldName="Question" />
                        </h3>
                        <asp:Panel ID="pnlQuestion" runat="server" CssClass="answer-choices">
                            <asp:Panel ID="pnlTrueFalse" runat="server" Visible="false">
                                <button type="button" id="btnTrue" runat="server" class="button gray answer-choice-true rs_skip">True</button>
                                <button type="button" id="btnFalse" runat="server" class="button gray answer-choice-false rs_skip">False</button>
                                <asp:RadioButtonList ValidationGroup="vlgPageQuestions" ID="rblHiddenButtonList" runat="server" RepeatLayout="Flow">
                                    <asp:ListItem Text="True" Value="True"></asp:ListItem>
                                    <asp:ListItem Text="False" Value="False"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                    ControlToValidate="rblHiddenButtonList"
                                    ValidationGroup="vlgPageQuestions"
                                    runat="server">
                                </asp:RequiredFieldValidator>

                            </asp:Panel>
                            <asp:Panel ID="pnlRadioQuestion" CssClass="test" runat="server" Visible="false">
                                <%-- OR --%>
                                <%-- Options for list style Question --%>
                                <asp:RadioButtonList ValidationGroup="vlgPageQuestions" ID="rblAnswer" runat="server" RepeatLayout="UnorderedList">
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="rflRadioAnswer"
                                    ControlToValidate="rblAnswer"
                                    ValidationGroup="vlgPageQuestions"
                                    runat="server">
                                </asp:RequiredFieldValidator>
                            </asp:Panel>
                            <asp:Panel ID="pnlDropDown" runat="server" Visible="false">
                                <asp:DropDownList ValidationGroup="vlgPageQuestions" ID="ddlQuestion" runat="server" />
                                <asp:RequiredFieldValidator ID="rflDropDownAnswer"
                                    ControlToValidate="ddlQuestion"
                                    ValidationGroup="vlgPageQuestions"
                                    runat="server">
                                </asp:RequiredFieldValidator>
                                <br />
                                <br />
                            </asp:Panel>
                        </asp:Panel>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HiddenField ID="hfKeyValuePairs" runat="server" />
                <script>
                    var Answers = {};
                    var hiddenField = $("[id*='hfKeyValuePairs']");

                    $("ul[id*='rptPageQuestions_rblAnswer']").click(function () {
                        Answers[$(this).data("id")] = $(this).find("li .checked input").val();
                        hiddenField.val(JSON.stringify(Answers));
                    })

                    $("select[id*='rptPageQuestions_ddlQuestion']").change(function () {
                        Answers[$(this).data("id")] = $(this).val();
                        hiddenField.val(JSON.stringify(Answers));
                    })

                    $("[id*='btnFalse']").click(function () {
                        $(this).parent().find("input[value='False']").prop("checked", true)
                        Answers[$(this).data("id")] = $(this).html();
                        hiddenField.val(JSON.stringify(Answers));
                    })

                    $("[id*='btnTrue']").click(function () {
                        $(this).parent().find("input[value='True']").prop("checked", true)
                        Answers[$(this).data("id")] = $(this).html();
                        hiddenField.val(JSON.stringify(Answers));
                    })

                    function checkValidation() {
                        if (Page_ClientValidate("vlgPageQuestions")) {
                            $(".assessment-quiz-next").off("click");
                        }
                    }
                </script>
                <br />
                <br />
                <br />
                <br />
                <div class="next-question">
                    <button type="button" runat="server" id="btnPrevPage" onserverclick="btnPrevPage_Click" class="button no gray" visible="false"><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_BackText %></button>
                    <button type="button" runat="server" id="btnNextPage" onserverclick="btnNextPage_Click" onclick="checkValidation();" class="button reload-page assessment-quiz-next" ><%= UnderstoodDotOrg.Common.DictionaryConstants.NextButtonText %></button>
                    <button type="button" runat="server" id="btnShowResults" onserverclick="btnResult_Click" onclick="checkValidation();" class="button assessment-quiz-next" visible="false" ><%= UnderstoodDotOrg.Common.DictionaryConstants.Quizzes_ShowResults %></button>
                </div>
                <div class="next-question">
                    <button type="button" runat="server" id="btnTakeQuizAgain" onserverclick="btnTakeQuizAgain_Click" class="button" visible="false" ><%= UnderstoodDotOrg.Common.DictionaryConstants.Quizzes_TakeQuizAgain %></button>
                </div>
            </div>
        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1">
            
            <sc:Sublayout ID="Sublayout1" Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulCountOnlySideColumn.ascx" runat="server"></sc:Sublayout>

            <!-- BEGIN PARTIAL: find-helpful -->
            <sc:Sublayout ID="Sublayout2" Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" runat="server"></sc:Sublayout>
            <!-- END PARTIAL: find-helpful -->
            <!-- BEGIN PARTIAL: keep-reading -->
            <sc:Sublayout ID="Sublayout3" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" runat="server"></sc:Sublayout>
            <!-- END PARTIAL: keep-reading -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<!-- BEGIN PARTIAL: tools -->
<!-- Tools -->
<sc:Sublayout ID="sbMoreQuizzes" Path="~/Presentation/Sublayouts/Articles/QuizTryMoreQuizzes.ascx" runat="server" Visible="false"></sc:Sublayout>

<sc:Sublayout ID="Sublayout5" Path="~/Presentation/Sublayouts/Section/SectionTools.ascx" runat="server"></sc:Sublayout>
<!-- .container -->
