﻿using Sitecore.Data.Items;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic {
    public partial class ArticleListing : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            TopicLandingPageItem topicPage = Sitecore.Context.Item;
            if (topicPage != null && topicPage.SliderCuratedFeaturedcontent != null) {
                var sliderCuratedFeatured = topicPage.SliderCuratedFeaturedcontent.ListItems;
                if (sliderCuratedFeatured != null && sliderCuratedFeatured.Any()) {
                    var result = sliderCuratedFeatured.Split(2);
                    rptArticleListing.DataSource = sliderCuratedFeatured;
                    rptArticleListing.DataBind();
                    //fill hidden fields
                    hfGUID.Value = Sitecore.Context.Item.ID.ToString();
                    hfResultsPerClick.Value = "6";
                }
                else {
                    this.Visible = false;
                }
            }
            else {
                this.Visible = false;
            }
        }

        protected void rptArticleListing_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                Item subTopicItem = e.Item.DataItem as Item;
                if (subTopicItem != null) {
                    //Response.Write(e.Item.ItemIndex.ToString());
                    Literal ltRowListingStart = e.FindControlAs<Literal>("ltRowListingStart");
                    Literal ltRowListingEnd = e.FindControlAs<Literal>("ltRowListingEnd");
                    HyperLink hlNavLink = e.FindControlAs<HyperLink>("hlNavLink");
                    HyperLink hlLinkText = e.FindControlAs<HyperLink>("hlLinkText");
                    Image defaultImage = e.FindControlAs<Image>("defaultImage");
                    Sitecore.Web.UI.WebControls.Image scThumbnailImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scThumbnailImage");
                    if (e.Item.ItemIndex % 2 != 1) {
                        if (ltRowListingStart != null) {
                            ltRowListingStart.Text = "<div class=\"row listing-row\">";
                        }
                    }
                    else {
                        if (ltRowListingEnd != null) {
                            ltRowListingEnd.Text = "</div>";
                        }
                    }

                    ContentPageItem content = new ContentPageItem(subTopicItem);
                    if (hlLinkText != null) {
                        hlLinkText.Text = content.PageTitle.Rendered;
                        hlLinkText.NavigateUrl = subTopicItem.GetUrl();
                    }

                    if (hlNavLink != null) {
                        hlNavLink.NavigateUrl = subTopicItem.GetUrl();
                    }

                    if (subTopicItem.InheritsFromType(DefaultArticlePageItem.TemplateId)) {
                        DefaultArticlePageItem contentPageItem = new DefaultArticlePageItem(subTopicItem);
                        if (scThumbnailImage != null && contentPageItem != null && contentPageItem.ContentThumbnail.MediaItem != null) {
                            scThumbnailImage.Item = contentPageItem;
                            if (defaultImage != null) {
                                defaultImage.Visible = false;
                            }
                        }
                        else {
                            if (defaultImage != null) {
                                defaultImage.Visible = true;
                            }
                        }
                    }
                }
            }
        }
    }
}