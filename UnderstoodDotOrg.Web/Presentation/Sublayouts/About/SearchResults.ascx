﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResults.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.SearchResults" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container l-search-box-container skiplink-toolbar">
  <div class="row">
    <div class="col col-22 offset-1">
      <!-- BEGIN PARTIAL: about/search-box-module -->
        <div class="search-box-module">
          <fieldset>
            <legend><%= UnderstoodDotOrg.Common.DictionaryConstants.SearchLabel %></legend>
              <span class="field">
                <label for="search-term" class="visuallyhidden"><%= UnderstoodDotOrg.Common.DictionaryConstants.SearchLabel %></label>
                <asp:TextBox ID="txtSearch" runat="server" />
                <asp:Button ID="btnSearch" runat="server" />
              </span>
          </fieldset>
        </div>
        <!-- END PARTIAL: about/search-box-module -->
    </div>
  </div>
</div>

<asp:PlaceHolder ID="phResults" runat="server">
    <div class="container l-results-and-filter">
  <div class="row">
    <div class="col col-24 rs_read_this">
      <!-- UN-1741 - # of Results & Filter -->
      <!-- BEGIN PARTIAL: about/results-and-filter -->
        <div class="results">
          <h1><asp:Literal ID="litResultCount" runat="server" /> Results for <span>&ldquo;<asp:Literal ID="litSearchTerm" runat="server" />&rdquo;</span></h1>
        </div>
        <label>
          <asp:DropDownList ID="ddlSearchFilter" runat="server" />
        </label>
        <div class="clearfix"></div>
<!-- END PARTIAL: about/results-and-filter -->
    </div>
  </div>
</div>

<script id="search-result-entry" type="text/template">
    <div class="row search-result-container rs_read_this">
        <div class="col col-6 search-image">
        <img class="" alt="" src="{{Thumbnail}}" />
        </div>

        <div class="col col-11 offset-1 search-content">
        <h4><a href="{{Url}}">{{Title}}</a></h4>
        <p>{{Blurb}}</p>
        </div>

        <div class="col col-5 search-category">
        <span>{{Type}}</span>
        </div>
    </div>
</script>

    <asp:Repeater ID="rptResults" runat="server">
        <HeaderTemplate>
            <div class="container about-search-results-container">
                <div class="row">
                <div class="col col-24">

                    <div class="about-search-results skiplink-content" aria-role="main">

        </HeaderTemplate>
        <ItemTemplate>
            <div class="row search-result-container rs_read_this">
                <div class="col col-6 search-image">
                <img class="foo" alt="FPO content image" src="http://placehold.it/230x129&amp;text=230x129" />
                </div>

                <div class="col col-11 offset-1 search-content">
                <h4><asp:HyperLink ID="hlArticlePage" runat="server" /></h4>
                <p>"…Lorem ipsum dolor sit amet, dyslexia adipiscing elit, sed diam nonummynibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat…."</p>
                </div>

                <div class="col col-5 search-category">
                <span><asp:Literal ID="litArticleType" runat="server" /></span>
                </div><!-- end .col.col-5 -->
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div> <!-- .about-search-results -->
                    <div class="about-search-results-more">
                    <!-- Show More -->
                    <!-- BEGIN PARTIAL: community/show_more -->
                    <!--Show More-->
                    <div class="container show-more rs_skip">
                        <div class="row">
                        <div class="col col-24">
                            <a class="show-more-search-results-link" href="#" data-path="<%= AjaxUrl %>" data-type="<%= AjaxType %>" data-container="about-search-results" data-term="<%= AjaxTerm %>" data-item="search-result-entry">Show More<i class="icon-arrow-down-blue"></i></a>
                        </div>
                        </div>
                    </div><!-- .show-more -->
                    <!-- END PARTIAL: community/show_more -->
                    <!-- .show-more -->
                    </div><!-- .about-search-results-more -->

                </div><!-- .col -->
                </div><!-- .row -->
            </div> <!-- .container -->
        </FooterTemplate>
    </asp:Repeater>

</asp:PlaceHolder>

<asp:Placeholder id="phNoResults" runat="server" Visible="false">
    <div class="container l-about-zero-results">
            <div class="row">
            <div class="col col-24 zero-results-inner">
                <div class="col col-22 offset-1 rs_read_this zero-results-inner-rs-wrapper">
                <!-- UN-3289 - Zero Results -->
                <!-- BEGIN PARTIAL: about/about-zero-results.erb -->
                <div class="about-zero-results">
                    <h1>0 Results for <span>&ldquo;<asp:Literal ID="litSearchTermNoResults" runat="server" />&rdquo;</span></h1>
                    <p>We couldn't find any results that match your search words. Try these:</p>
                    <ul>
                    <li>Check your spelling</li>
                    <li>Use different search words in the search bar above</li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <!-- END PARTIAL: about/about-zero-results.erb -->
                </div>
            </div>
            </div>
        </div>
</asp:Placeholder>
      

