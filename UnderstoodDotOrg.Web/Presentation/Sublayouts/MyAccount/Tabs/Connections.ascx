﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Connections.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs.Connections" %>
<%@ Register TagPrefix="uc1" TagName="MemberProfileCard" Src="~/Presentation/Sublayouts/Common/Cards/MemberProfileCard.ascx" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container my-account-subheader connections-subheader">
    <div class="row">
        <!-- subheader -->
        <div class="col col-22 offset-1">
            <!-- BEGIN PARTIAL: my-connections-subheader -->
            <h2 class="rs_read_this"><%= UnderstoodDotOrg.Common.DictionaryConstants.MyConnectionsLabel %></h2>
            <%--<a href="REPLACE" class="separated-link"><sc:FieldRenderer ID="frAvtivityFeed" FieldName="Activity Feed Text" runat="server" /></a>--%>
            <fieldset>
                <span class="select-container sort">
                    <select name="filter" id="filter" class="my-account-dropdown">
                        <option value=""><sc:FieldRenderer ID="frShowAll" FieldName="DD Show All Text" runat="server" /></option>
                        <option><sc:FieldRenderer ID="frDDFriendsOnly" FieldName="DD Friends Only Text" runat="server" /></option>
                        <option><sc:FieldRenderer ID="frDDExpertsBloggersandModerators" runat="server" FieldName="DD Experts Bloggers and Moderators Text" /></option>
                    </select>
                </span>
            </fieldset>
            <!-- END PARTIAL: my-connections-subheader -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<div class="container my-connections">
    <div class="row">
        <!-- article -->
        <div class="col col-23 offset-1 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: my-connections -->
            <div class="my-connections-grid">
                <div class="row">
                    <section class="connections group" id="user_equal_heights">
                        <div class="row my-connections-list member-cards">
                            <!-- BEGIN PARTIAL: community/member_card -->
                            <asp:Repeater ID="rptFriends" runat="server"
                                ItemType="UnderstoodDotOrg.Services.Models.Telligent.User">
                                <ItemTemplate>
                                    <uc1:MemberProfileCard ID="ucMemberProfileCard" runat="server" ProfileUser="<%# Item %>" ColumnCss="col-6" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </section>
                </div>
                <div class="showmore-footer">
                    <!-- Show More -->
                    <!-- BEGIN PARTIAL: community/show_more -->
                    <!--Show More-->
                    <div class="container show-more rs_skip">
                        <div class="row">
                            <div class="col col-24">
                                <a class="show-more-link show_more" href="#" data-path="my-account/my-connections" data-container="my-connections-list" data-item="my-event-item" data-count="2"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeMoreLabel %><i class="icon-arrow-down-blue"></i></a>
                            </div>
                        </div>
                    </div>
                    <!-- .show-more -->
                    <!-- END PARTIAL: community/show_more -->
                    <!-- .show-more -->
                </div>
            </div>

            <!-- END PARTIAL: my-connections -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
