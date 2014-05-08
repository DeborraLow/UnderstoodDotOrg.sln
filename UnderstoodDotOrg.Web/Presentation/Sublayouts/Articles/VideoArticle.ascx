﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoArticle.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.VideoArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article-intro">
  <div class="row">
    <!-- helpful count -->
    <div class="col col-10 article-intro-count multiple">
      <!-- BEGIN PARTIAL: helpful-count -->
<div class="count-helpful">
  <a href="REPLACE"><span>34</span>Found this helpful</a>
</div>
<!-- END PARTIAL: helpful-count -->
      <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
    </div>

    <!-- intro-text -->
    <div class="col col-13 offset-1">
      <!-- BEGIN PARTIAL: article-intro-text -->
<div class="article-intro-text">
  <p><%-- This would be the intro text to the slideshow. It should run about 35 words. Lorem ipsum dolor sit amet, consectetur adipiscing elit vestibulum convallis risus id felis.--%>
     <sc:FieldRenderer ID="FieldRenderer1" fr="frIntroText"  runat="server" FieldName="Intro Text"/>
  </p>
</div>
<!-- END PARTIAL: article-intro-text -->
    </div>

  </div><!-- .row -->
</div><!-- .container -->

<div class="container article">
  <div class="row">
    <!-- article -->
    <div class="col col-22 offset-1">
      <!-- BEGIN PARTIAL: article-video-container -->
<div class="article-video-container">
	<img class="foo" alt="FPO content image" src="http://placehold.it/870x489&amp;text=870x489" />
</div>
<!-- END PARTIAL: article-video-container -->
      <!-- BEGIN PARTIAL: transcript-control -->
<div class="transcript-container Video">
  <div class="transcript-wrap">
      <sc:FieldRenderer ID="frTranscript" runat="server" FieldName="Transcript"/>
   <%-- <div>
      <h2>Video Transcript</h2>

      <h3>Dr.Richard Nightengale:</h3>
      <p>Saepe consectetur dignissimos ipsa. eum vel enim aliquam maxime iure neque asperiores saepe aliquid debitis. sed qui beatae aut doloribus. ad quas magnam sed et illum error vero facilis est qui expedita reiciendis. aspernatur deserunt quo a in qui. aut id reprehenderit et totam vitae voluptas</p>

      <h3>Parent:</h3>
      <p>Officia et labore omnis ea eos deserunt in. numquam sed alias earum autem corrupti culpa facere sit sequi laboriosam officia. harum voluptas dolorum fuga laborum quam in ut est quibusdam explicabo</p>

      <h3>Dr.Richard Nightengale:</h3>
      <p>Veniam iure libero id sint dolores animi debitis laborum veniam cumque et. et amet rerum est veritatis. vitae ex reiciendis ullam voluptatem adipisci corporis nam eveniet tenetur aut itaque rem asperiores impedit. vel quis in id occaecati laborum sed qui nostrum omnis. voluptates repellat vero ut eos quidem velit a. neque soluta aliquid totam officia quidem illum et placeat at ipsum voluptas. deleniti voluptas ad inventore molestiae</p>

      <h3>Parent:</h3>
      <p>Nisi odit nostrum culpa consequatur pariatur alias vero consequatur tenetur explicabo sequi. dolores suscipit id quis quam inventore. hic et illo deleniti ab et quasi quas voluptatum ut placeat et. laborum natus illo ut non asperiores autem magnam. illum possimus velit aut accusantium ratione incidunt reprehenderit reprehenderit</p>

      <h3>Dr.Richard Nightengale:</h3>
      <p>Nam optio maiores dolores sit et ut sit veniam rem sunt. ea consequatur soluta natus tempora aut ut omnis culpa cupiditate et quasi omnis sed. qui voluptatem eius nemo eligendi similique illum reprehenderit. debitis culpa consequatur laborum et maiores. voluptates numquam voluptates blanditiis laborum ut. qui velit molestiae ipsam. quos totam culpa porro quisquam tempora unde eveniet saepe sint sit</p>

      <h3>Parent:</h3>
      <p>Nihil rem illo nulla eligendi asperiores magni libero numquam ipsum a voluptatem. ullam quo mollitia unde blanditiis est qui eius nostrum enim provident rerum rerum. quia neque error occaecati et. a tenetur nisi ipsum perferendis fugit cupiditate necessitatibus. laborum quos ex qui ipsam blanditiis nemo ut voluptatem harum earum sed qui est</p>
    </div> --%>
  </div>
  <div class="read-more"></div>
</div>
<!-- END PARTIAL: transcript-control -->
    </div>
  </div>
</div><!-- .container -->

<div class="container">
  <div class="row">
    <div class="col col-15">
    
    <!-- BEGIN PARTIAL: reviewed-by -->
            <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" Visible="false" />
            <%--<p class="reviewed-by">
                <span class="reviewed-by-title">Reviewed&nbsp;by</span> <span class="reviewed-by-author">
                   <%--<a href="REPLACE">Dr. Samantha Frank</a>
                   <asp:HyperLink ID="hlReviewdby" runat="server">
                       <sc:FieldRenderer ID="frReviewedby" runat="server" FieldName="Revierwer Name" />
                    </asp:HyperLink>
                </span><span class="dot"></span><span class="reviewed-by-date">
                    <%--12&nbsp;Dec&nbsp;&apos;13
                    <sc:Date ID="dtReviewdDate" Field="Reviewed Date" runat="server" Format="dd MMM yy" />
                </span>
            </p>--%>
            <!-- END PARTIAL: reviewed-by -->
    <!-- BEGIN PARTIAL: find-helpful -->
<div class="find-this-helpful content">
   
  <h4>Did you find this helpful?</h4>
  <ul>
    <li>
      <button class="helpful-yes">Yes</button>
    </li>
    <li>
      <button class="helpful-no">No</button>
    </li>
  </ul>
  <div class="clearfix"></div>
   
</div>
<!-- END PARTIAL: find-helpful -->
    </div>
  </div><!-- .row -->
</div><!-- .container -->

 
<%--<div class="container more-carousel">
  <div class="row">
    <div class="col col-24 offset-1">
      <h2>More Like this:</h2>
      <!-- BEGIN PARTIAL: more-carousel -->
<div id="more-carousel-slides-container">
  <ul>
    <li>
      <a href="REPLACE">
        <p>Understand Your Child's Problem: Start a Log</p>
        <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
      </a>
    </li>
    <li>
      <a href="REPLACE">
        <p>Does my Child Have Dyslexia? Take the Quiz</p>
        <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
      </a>
    </li>
    <li>
      <a href="REPLACE">
        <p>Get Better Recommendations: Create a Profile</p>
        <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
      </a>
    </li>
    <li>
      <a href="REPLACE">
        <p>Understand Your Child's Problem: Start a Log</p>
        <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
      </a>
    </li>
    <li>
      <a href="REPLACE">
        <p>Does my Child Have Dyslexia? Take the Quiz</p>
        <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
      </a>
    </li>
    <li>
      <a href="REPLACE">
        <p>Get Better Recommendations: Create a Profile</p>
        <img alt="230x129 Placeholder" src="http://placehold.it/230x129" />
      </a>
    </li>
  </ul>
</div><!-- #more-carousel-slides-container-->

<!-- END PARTIAL: more-carousel -->
    </div>
  </div>
</div> --%>


