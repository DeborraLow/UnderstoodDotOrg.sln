﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvocacyPageTopicHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy.AdvocacyPageTopicHeader" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>

<!-- BEGIN PARTIAL: pagetopic -->
<!-- Page Title -->
<div class="container page-topic advocacy-pagetopic take-action-rs-wrapper">
    <div class="row">
        <div class="col col-14 offset-1">
            <div class="rs_read_this">
                <h1><%= Model.ContentPage.PageTitle.Rendered %></h1>
                <div class="page-subtitle"><%= Model.ContentPage.PageSummary.Rendered %></div>
            </div>
        </div>
        <div class="col col-9 partner-image-column">
            <span class="powered-by">Powered by</span>
            <a href="<%= Model.PoweredbyLink.Url %>" class="partner-image">
                <%= Model.PoweredbyLogo.Rendered %>
            </a>
            <a href="<%= Model.PoweredbyLink.Url %>" class="partner-text">
                <%= Model.PoweredbyLink.Field.Text %>
            </a>
            <div class="share-save-pagetopic"></div>
        </div>
        <% if (Model.IsOfType(UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.AdvocacyArticlePageItem.TemplateId)) { %>
        <div class="col col-9">
            <!-- BEGIN PARTIAL: share-save -->
            <sc:Sublayout ID="sbCommentsSummary" runat="server" Path="~/Presentation/Sublayouts/Common/ShareAndSaveTool.ascx" />
            <!-- .container -->
            <!-- END PARTIAL: pagetopic -->
            <!-- END PARTIAL: share-save -->
        </div>
        <% } %>
    </div>
</div>
<!-- .container -->
