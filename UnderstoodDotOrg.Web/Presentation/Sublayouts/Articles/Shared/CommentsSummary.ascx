﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentsSummary.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.CommentsSummary" %>
<asp:Panel ID="pnlCommentTeaser" Visible="false" runat="server">
<section class="comments-summary"> 
    <header>
        <h3><asp:Literal ID="litNumComments" runat="server" /></h3>
    </header>
    <div class="quote-container">
        <blockquote data-read-more="<%= UnderstoodDotOrg.Common.DictionaryConstants.ReadMoreLabel %>">
            <asp:Literal ID="litCommentblurb" runat="server" />
            <i class="arrow-quote-bottom"></i>
        </blockquote>
        <span>
            <strong><asp:Literal Text="" ID="litAuthorName" runat="server" /></strong><span id="bulletSpan" runat="server" style="margin-left: 0px;"> &bull;</span> <asp:Literal Text="" ID="litTimeStamp" runat="server" />
        </span>
    </div>

    <ul>
        <li><a ID="hlAllComments" href="#comment-list" runat="server"></a></li>
        <li><a ID="hlAddMyComment" runat="server"></a></li>
    </ul>
</section>

</asp:Panel>