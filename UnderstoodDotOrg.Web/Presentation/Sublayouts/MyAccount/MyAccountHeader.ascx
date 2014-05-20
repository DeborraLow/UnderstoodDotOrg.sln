﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyAccountHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.MyAccountHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="container">
    <div class="row back-to-previous-nav">
        <!-- article -->
        <div class="col col-22 offset-1">
            <a href="REPLACE" class="back-to-previous"><i class="icon-arrow-left-blue"></i>Back to Homepage</a>
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
<!-- BEGIN PARTIAL: my-account-nav -->

<div class="container my-account-nav">
    <div class="row account-top-wrapper">
        <div class="col col-23 offset-1">
            <div class="account-photo skiplink-dashboard">
                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
            </div>
            <div class="account-info">
                <h1 class="account-username">
                    <asp:Literal ID="litUserName" runat="server"></asp:Literal>
                </h1>
                <p class="account-location">Colorado</p>
            </div>
            <div class="account-links">
                <asp:HyperLink ID="hypMyProfile" CssClass="profile-link button" runat="server">My Profile</asp:HyperLink>
                <span class="button-wrapper">
                    <a class="notifications-link button" href="REPLACE">Notifications<span class="notification-count">3</span></a>
                </span>
            </div>
        </div>
    </div>
    <div class="account-nav-wrapper">
        <div class="row">
            <nav class="account-nav">
                <a class="groups-link" href="REPLACE">
                    <div class="icon-wrapper">
                        <i class="icon-account-groups"></i>
                        <span>Groups</span>
                    </div>
                </a>
                <a class="events-link" href="REPLACE">
                    <div class="icon-wrapper">
                        <i class="icon-account-events"></i>
                        <span>Events</span>
                    </div>
                </a>
                <a class="comments-link" href="REPLACE">
                    <div class="icon-wrapper">
                        <i class="icon-account-comments"></i>
                        <span>Comments</span>
                    </div>
                </a>
                <a class="saved-link" href="REPLACE">
                    <div class="icon-wrapper">
                        <i class="icon-account-saved"></i>
                        <span>Saved</span>
                    </div>
                </a>
                <a class="connections-link" href="REPLACE">
                    <div class="icon-wrapper">
                        <i class="icon-account-connections"></i>
                        <span>Connections</span>
                    </div>
                </a>
            </nav>
        </div>
    </div>
</div>
<!-- END PARTIAL: my-account-nav -->
