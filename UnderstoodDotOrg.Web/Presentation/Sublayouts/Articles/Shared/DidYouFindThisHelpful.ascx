﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DidYouFindThisHelpful.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.DidYouFindThisHelpful" %>

<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-19 offset-2">
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful content" id="count-helpful-content rs_read_this">

                <h4><asp:Literal ID="ltlDidYouFindThisHelpful" runat="server"></asp:Literal></h4>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" class="update-panel">
                        <ContentTemplate>
                            <ul>
                                <li>
                                    <button id="btnYes" runat="server" class="helpful-yes" onserverclick="btnYes_ServerClick" ></button>
                                </li>
                                <li>
                                    <button id="btnNo" runat="server" class="helpful-no" onserverclick="btnNo_ServerClick"></button>
                                </li>
                            </ul>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                <div class="clearfix"></div>
            </div>

            <!-- END PARTIAL: find-helpful -->
            <div class="find-this-helpful-small">
                <!-- Module within only appears in under 650px window width-->
                <!-- BEGIN PARTIAL: find-helpful -->
                <div class="find-this-helpful sidebar no-margin" id="count-helpful-sidebar rs_read_this">
                    <h4><asp:Literal ID="ltlDidYouFindThisHelpfulSmall" runat="server"></asp:Literal></h4>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="update-panel">
                        <ContentTemplate>
                            <ul>
                                <li>
                                    <button id="btnSmallYes" runat="server" class="helpful-yes" onserverclick="btnYes_ServerClick"></button>
                                </li>
                                <li>
                                    <button id="btnSmallNo" runat="server" class="helpful-no" onserverclick="btnNo_ServerClick"></button>
                                </li>
                            </ul>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="clearfix"></div>

                </div>

                <!-- END PARTIAL: find-helpful -->
            </div>
            <div class="find-this-helpful-large" style="display: none;">
                <!-- Module within only appears in over 650px window width-->
            </div>
        </div>
    </div>
</div>
<!-- .container -->
