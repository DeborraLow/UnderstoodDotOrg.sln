﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AudioArticle.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.AudioArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<sc:Sublayout ID="Sublayout1" Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCounts.ascx" runat="server"></sc:Sublayout>

<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-24 skiplink-content" aria-role="main" aria-role="main">
            <!-- BEGIN PARTIAL: audio-pull-quote -->
            <div class="audio-quote">
                <div class="audio-quote-img">
                    <sc:Image ID="imgThumbnail" runat="server" Field="Featured Image" Parameters="mw=290&mh=163" />
                </div>
                <div class="audio-quote-text">
                    <p class="audio-quote-content">
                        <sc:FieldRenderer ID="frAudioQuote" runat="server" FieldName="Quote" />
                    </p>
                </div>
            </div>
            <!-- END PARTIAL: audio-pull-quote -->
            <!-- BEGIN PARTIAL: audio-player -->
            <asp:PlaceHolder ID="phPlayer" runat="server">
            <div id="cp_widget_e25b28d3-8ee7-4271-a252-8a5f0b517223"></div>
            <script type="text/javascript">
            var cpo = []; cpo["_object"] = "cp_widget_e25b28d3-8ee7-4271-a252-8a5f0b517223"; cpo["_fid"] = "<%= Model.CincopaID.Raw %>";
            var _cpmp = _cpmp || []; _cpmp.push(cpo);
            (function () {
                var cp = document.createElement("script"); cp.type = "text/javascript";
                cp.async = true; cp.src = "//www.cincopa.com/media-platform/runtime/libasync.js";
                var c = document.getElementsByTagName("script")[0];
                c.parentNode.insertBefore(cp, c);
            })(); </script>
                </asp:PlaceHolder>
            <!-- END PARTIAL: audio-player -->
        </div>
    </div>
</div>
<!-- .container -->

<div class="container">
  <div class="row">
    <div class="col col-18 offset-3">
      <!-- BEGIN PARTIAL: transcript-control -->
        <div class="transcript-container Audio">
          <div class="read-more mobile-close">
            <a href="#"><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_CloseTranscriptButtonText %><i class="icon-arrow-up-blue"></i></a>
          </div>
          <div class="transcript-wrap clearfix rs_read_this">
            <div>
                <sc:FieldRenderer runat="server" ID="frAudioTranscript" FieldName="Transcript" />
            </div>
           </div>
         <div class="read-more read-more-bottom"></div>
       </div>
       <!-- END PARTIAL: transcript-control -->
    </div>
  </div>
</div>

<div class="container">
    <div class="row">
        <div class="col col-15">
            <div class="rs_about_author rs_read_this">
                <!-- BEGIN PARTIAL: reviewed-by -->
                <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" />
                <!-- END PARTIAL: reviewed-by -->

                <!-- BEGIN PARTIAL: find-helpful -->
                <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpful.ascx" runat="server"></sc:Sublayout>
                <!-- END PARTIAL: find-helpful -->
            </div>
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

