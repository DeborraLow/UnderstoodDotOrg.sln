﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Comments : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int blogId;
            int blogPostId;
            try
            {
                var blogCig = new BlogsPostPageItem(Sitecore.Context.Item);
                blogId = Convert.ToInt32(blogCig.BlogId.Raw);
                blogPostId = Convert.ToInt32(blogCig.BlogPostId.Raw);
            }
            catch
            {
                blogId = 1;
                blogPostId = 1;
            }
            List<Comment> dataSource = CommunityHelper.ReadComments(blogId, blogPostId);
            CommentRepeater.DataSource = dataSource;
            CommentRepeater.DataBind();
            CommentCountDisplay.Text = "Comments (" + dataSource.Count + ")";

            if (!IsPostBack) { CommentEntryTextField.Text = "Add your comment..."; }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            int blogId = Convert.ToInt32(Sitecore.Context.Item["BlogId"]);
            int blogPostId = Convert.ToInt32(Sitecore.Context.Item["BlogPostId"]);
            string body = CommentEntryTextField.Text;
            CommunityHelper.PostComment(blogId, blogPostId, body);
            List<Comment> dataSource = CommunityHelper.ReadComments(blogId, blogPostId);

            CommentRepeater.DataSource = dataSource;
            CommentRepeater.DataBind();
        }

        protected void FlagButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string id = btn.CommandArgument;

            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            webClient.Headers.Add("Rest-Method", "PUT");
            var requestUrl = String.Format("{0}api.ashx/v2/comments/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), id);

            var values = new NameValueCollection();
            values.Add("CommentId", id);
            values.Add("IsApproved", "false");

            var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

            Console.WriteLine(xml);
        }

        protected void ReplyButton_Click(object sender, EventArgs e)
        {
            CommentEntryTextField.Focus();
        }

        protected void LikeButton_Click(object sender, EventArgs e)
        {
            int blogId = Convert.ToInt32(Sitecore.Context.Item["BlogId"]);
            int blogPostId = Convert.ToInt32(Sitecore.Context.Item["BlogPostId"]);
            LinkButton btn = (LinkButton)(sender);
            string ids = btn.CommandArgument;
            string[] s = ids.Split('&');

            string contentId = s[0];
            string contentTypeId = s[1];

            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = String.Format("{0}api.ashx/v2/likes.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));

            var values = new NameValueCollection();
            values.Add("ContentId", contentId);
            values.Add("ContentTypeId", contentTypeId);

            var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

            Console.WriteLine(xml);

            List<Comment> dataSource = CommunityHelper.ReadComments(blogId, blogPostId);

            CommentRepeater.DataSource = dataSource;
            CommentRepeater.DataBind();
        }       
    }
}