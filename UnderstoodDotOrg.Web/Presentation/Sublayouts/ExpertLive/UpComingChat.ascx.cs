﻿using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve
{
    public partial class UpComingChat : System.Web.UI.UserControl
    {
        ChatEventPageItem ContextItem = Sitecore.Context.Item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer != null && !Request.UrlReferrer.ToString().IsNullOrEmpty()) {
                hlBackToLink.NavigateUrl = Request.UrlReferrer.ToString();
                string backto = Request.UrlReferrer.ToString().Substring(Request.UrlReferrer.ToString().LastIndexOf("/") + 1);
                if (backto == string.Empty) {
                    backto = Request.UrlReferrer.ToString().Substring(0, Request.UrlReferrer.ToString().Length - 1);
                    backto = backto.Substring(backto.LastIndexOf("/") + 1);
                }

                hlBackToLink.Text = String.Format("{0} {1}", DictionaryConstants.BacktoLabel, backto);
            }

            ChatEventPageItem contextItem = Sitecore.Context.Item;
            BaseEventDetailPageItem baseEventDetailpage = new BaseEventDetailPageItem(contextItem);
            ExpertDetailPageItem expert = baseEventDetailpage.Expert.Item;

            if (ContextItem != null) {
                if (IsArchiveItem(ContextItem)) {
                    this.Visible = false;
                }
                else {
                    this.Visible = true;
                }
            }

            if (contextItem != null) {
                if (frPageTitle != null) {

                    frPageTitle.Item = contextItem;
                }
                if (expert != null) {
                    if (hlLink != null) {
                        hlLink.NavigateUrl = expert.InnerItem.GetUrl();
                    }
                   
                    FieldRenderer scThumbImg = FindControl("scThumbImg") as FieldRenderer;
                    if (expert != null && expert.ExpertImage.MediaItem != null && scThumbImg != null) {
                        scThumbImg.Item = expert.InnerItem;
                    }
                    else {
                        imgExpertDefault.Visible = true;
                    }

                    if (litGuest != null) {
                        litGuest.Text = expert.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
                    }
                }

                if (ltEventDate != null && !baseEventDetailpage.EventDate.Raw.IsNullOrEmpty()) {
                    TimeZoneItem timezone = baseEventDetailpage.EventTimezone.Item;
                    string timeZoneText = string.Empty;

                    if (timezone != null) {
                        timeZoneText = timezone.Timezone.Rendered;
                    }

                    ltEventDate.Text = String.Format("{0} at {1} {2}", baseEventDetailpage.EventDate.DateTime.ToString("ddd MMM dd"), baseEventDetailpage.EventDate.DateTime.ToString("hh:mm tt").ToLower(), timeZoneText);
                }

                if (frHeading != null) {
                    frHeading.Item = contextItem;
                }

                if (frSubHeading != null) {
                    frSubHeading.Item = contextItem;
                }

                if (frBodyContent != null) {
                    frBodyContent.Item = contextItem;
                }

                if (scLinkCalendar != null) {
                    scLinkCalendar.Item = contextItem;
                }

                if (scLinkRSVP != null) {
                    scLinkRSVP.Item = contextItem;
                }

            }

            if (ContextItem != null) {
                if (IsArchiveItem(ContextItem)) {
                    this.Visible = false;
                }
            }
        }
                
        private bool IsArchiveItem(Item item) {
            bool isArchiveItem = false;
            BaseEventDetailPageItem baseEventPageItem = new BaseEventDetailPageItem(item);
            if (baseEventPageItem != null) {
                if (baseEventPageItem.EventDate.DateTime < DateTime.Today) {
                    isArchiveItem = true;
                }
            }

            return isArchiveItem;
        }
    }
}