﻿using Sitecore.Configuration;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class FromOurBlogs : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string blogId = Settings.GetSetting(Constants.Settings.TelligentBlogIds);
            var dataSource = CommunityHelper.ListBlogPosts(blogId, "3");
            foreach (var item in dataSource)
            {
                string[] s = item.Title.Split('{');
                BlogsPostPageItem blogPost = Sitecore.Context.Database.GetItem("/Sitecore/Content/Home/Community and Events/Blogs/" + item.BlogName + "/" + s[0]);
                if (blogPost != null)
                {
                    var author = Sitecore.Context.Database.GetItem(blogPost.Author.Raw);
                    item.Author = author.Name;
                    item.Title = s[0];
                    item.ContentTypeId = blogPost.ContentTypeId;
                    item.Body = CommunityHelper.FormatString100(CommunityHelper.FormatRemoveHtml(blogPost.Body.Raw));
                    item.AuthorUrl = LinkManager.GetItemUrl(author);
                    if (this.CurrentMember != null)
                    {
                        if (!this.CurrentMember.ScreenName.IsNullOrEmpty())
                        {
                            if (CommunityHelper.IsBookmarked(this.CurrentMember.ScreenName, item.ContentId))
                            {
                                item.IsFollowing = true;
                            }
                        }
                    }
                    else
                    {
                        item.IsFollowing = false;
                    }
                }
            }
            BlogPostsRepeater.DataSource = dataSource;
            BlogPostsRepeater.DataBind();
        }

        protected void BlogPostRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var post = (BlogPost)e.Item.DataItem;
            FollowButton follBtn = (FollowButton)e.Item.FindControl("follBtn");
            follBtn.LoadState(post.ContentId, post.ContentTypeId, UnderstoodDotOrg.Common.Constants.TelligentContentType.BlogPost);
        }

        protected void btnFollow_Click(object sender, EventArgs e)
        {
            Button btn = (Button)(sender);
            string[] id = btn.CommandArgument.Split('&');
            string contentId = id[0];
            string contentTypeId = id[1];
            if (this.CurrentMember != null)
            {
                if (!this.CurrentMember.ScreenName.IsNullOrEmpty())
                {
                    CommunityHelper.SaveItem(this.CurrentMember.ScreenName, contentId, contentTypeId);
                }
            }
        }
    }
}