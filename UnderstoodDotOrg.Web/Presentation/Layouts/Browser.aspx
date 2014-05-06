﻿<%@ Page Language="c#" CodePage="65001" AutoEventWireup="true" CodeBehind="Browser.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Layouts.Browser"%>

<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<%@ OutputCache Location="None" VaryByParam="none" %>
<!DOCTYPE html>
<!--[if lte IE 8]><html class="no-js nonresponsive"><![endif]-->
<!--[if gte IE 9]><!-->
<html class="no-js">
<!--<![endif]-->

<!-- BEGIN PARTIAL: head -->
<head>
    <meta charset="utf-8">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="icon" type="image/x-icon" href="favicon.ico">

    <link href="/Presentation/includes/css/vendor/bootstrap.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/vendor/normalize.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/vendor/boilerplate.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/vendor/royalslider.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/vendor/jplayer.blue.monday.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/vendor/ui-lightness/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/base.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/grid.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/layout.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/globals.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/modules.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/about.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/advocacy.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/account.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/article.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/community.css" rel="stylesheet" />
    <link href="/Presentation/includes/css/uniform-understood.css" rel="stylesheet" />

    <script type="text/javascript" src="/Presentation/includes/js/vendor/modernizr.custom.js"></script>
</head>

<!-- END PARTIAL: head -->
<body>
    <form id="form1" runat="server">
         <asp:Literal runat="server" ID="ltWelcomeTour" ></asp:Literal>
       
      
        <%--<sc:sublayout id="scHeader" runat="server" path="~/Presentation/SubLayouts/Containers/Header.ascx" />--%>
        <!-- BEGIN PARTIAL: language-selector -->
        <div id="language-selector-bar">

            <span class="button-close ir">Close</span>

            <dl>
                <dt>Language?</dt>
                <dd><a href="REPLACE.html" class="button">English</a></dd>
                <dd><a href="REPLACE.html" class="button">Espa&ntilde;ol</a></dd>
            </dl>

        </div>
        <!-- END PARTIAL: language-selector -->

        <div id="wrapper">
             
            <sc:Placeholder ID="Placeholder1" Key="Header" runat="server" />
            <sc:Placeholder ID="Placeholder2" Key="Main" runat="server" />
            <sc:Placeholder ID="Placeholder3" Key="Footer" runat="server" />
        </div>
        <!-- #wrapper -->


        <!-- BEGIN PARTIAL: footerjs -->
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
        <!--[if lte IE 8]>
            <script src="Presentation/includes/js/vendor/selectivizr.js"></script><![endif]-->

        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.uniform.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.validate.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.royalslider.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.hoverIntent.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.equalheights.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.easytabs.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.jplayer.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery-ui-1.10.4.custom.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.ui.touch-punch.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/bootstrap.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.ezmark.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.mobile.custom.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.placeholder.min.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/vendor/jquery.ellipsis.min.js"></script>
        <script type="text/javascript" src="http://misc.readspeaker.com/user/richard/customers/7171/_MIN/ReadSpeaker.js?pids=embhl,custom"></script>
        <script type="text/javascript" src="/Presentation/includes/js/site.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/modules.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/community.js"></script>
        <script type="text/javascript" src="/Presentation/includes/js/global.js"></script>
        <!-- END PARTIAL: footerjs -->

    </form>
   
</body>

</html>
