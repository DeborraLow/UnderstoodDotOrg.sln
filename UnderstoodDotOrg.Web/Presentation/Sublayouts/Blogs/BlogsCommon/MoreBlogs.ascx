﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoreBlogs.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon.MoreBlogs" %>
<div class="community-blogs-more">
        <div class="row">
            <div class="col col-24 container">
                <h2>More Blogs</h2>
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows more-blogs next-prev-menu arrows">

                    <div class="rsArrow rsArrowLeft">
                        <button class="rsArrowIcn"></button>
                    </div>
                    <div class="rsArrow rsArrowRight">
                        <button class="rsArrowIcn"></button>
                    </div>
                </div>
                <!-- end .arrows -->
                <!-- END PARTIAL: community/carousel_arrows -->
                <div class="row blogs-more">
                    <!-- BEGIN PARTIAL: community/more_blogs_card -->
                    <asp:Repeater ID="BlogRepeater" runat="server">
                        <ItemTemplate>
                            <div class="col col-24 blog-card">
                                <div class="blog-card-wrapper">
                                    <div class="author-image">
                                        <a href="REPLACE">
                                            <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                        </a>
                                    </div>
                                    <!-- end .group-card-image -->
                                    <div class="blog-card-info group">
                                        <div class="blog-card-title">
                                            <a href="REPLACE"><%# Eval("_title") %></a>
                                        </div>
                                        <!-- end .blog-card-title -->
                                        <div class="blog-card-post-excerpt">
                                            <%# Eval("_description") %>
                                        </div>
                                        <a href="REPLACE" class="link-see-more">Read totam qui</a>
                                    </div>
                                    <!-- end .blog-card-info -->
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>