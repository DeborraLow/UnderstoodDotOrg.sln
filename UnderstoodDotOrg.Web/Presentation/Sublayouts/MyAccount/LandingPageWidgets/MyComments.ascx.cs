﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using System.Text.RegularExpressions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent
{
    public partial class MyCommentsTest : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                pnlNoProfile.Visible = true;
                //TODO: add navigate URL for hypCompleteYourProfile
            }
            else
            {
                MyAccountItem context = (MyAccountItem)Sitecore.Context.Item;
                var item = Sitecore.Context.Database.GetItem(Constants.Pages.MyAccountComments);
                hypCommentsTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);
                hypCommentsTab.Text = context.SeeAllCommentsText;

                List<Comment> commentsList = CommunityHelper.ListUserComments(CurrentMember.ScreenName);

                litCount.Text = commentsList.Count.ToString();

                if ((commentsList != null) && (commentsList.Count != 0))
                {
                    pnlComments.Visible = true;
                    rptComments.DataSource = commentsList.Count == 1 ? commentsList.GetRange(0, 1) : commentsList.GetRange(0, 2);
                    rptComments.DataBind();
                }
                else
                {
                    pnlNoComments.Visible = true;
                }
            }
        }

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                var item = e.Item.DataItem as Comment;
                HyperLink hypCommentLink = (HyperLink)e.Item.FindControl("hypCommentLink");
                hypCommentLink.NavigateUrl = "/";
                hypCommentLink.Text = item.CommentTitle;

                Literal litCommentBody = (Literal)e.Item.FindControl("litCommentBody");
                litCommentBody.Text = Regex.Replace(Regex.Replace(item.Body, @"<[^>]+>|&nbsp;", "").Trim(), @"\s{2,}", " ").Truncate(30,true,false);
            }
        }

    }
}