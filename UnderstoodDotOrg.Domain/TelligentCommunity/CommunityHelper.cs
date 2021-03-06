﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Understood.Common;
using Sitecore.Links;
using System.Text.RegularExpressions;
using System.Threading;
using UnderstoodDotOrg.Domain.Understood.Activity;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Understood.Services;

namespace UnderstoodDotOrg.Domain.TelligentCommunity
{
    public class CommunityHelper
    {
        public static List<CommentSortOption> GetCommentSortOptions()
        {
            return new List<CommentSortOption>
            {
                new CommentSortOption 
                {
                    Value = String.Empty,
                    Description = DictionaryConstants.SortByLabel,
                    SortAscending = false
                },
                new CommentSortOption 
                {
                    Value = Constants.TelligentCommentSort.CreateDate,
                    Description = DictionaryConstants.MostRecentLabel,
                    SortAscending = false
                },
                new CommentSortOption
                {
                    Value = Constants.TelligentCommentSort.CreateDate,
                    Description = DictionaryConstants.OldestToNewestLabel,
                    SortAscending = true
                }
            };
        }

        public static List<CommentSortOption> GetMyAccountCommentsSortOptions()
        {
            return GetMyAccountFavoritesSortOptions();
        }

        public static List<CommentSortOption> GetMyAccountFavoritesSortOptions()
        {
            return new List<CommentSortOption>
            {
                new CommentSortOption 
                {
                    Value = UnderstoodDotOrg.Common.Constants.MyAccountSearchValues.MostRecent.ToString(),
                    Description = DictionaryConstants.MostRecentLabel,
                    SortAscending = false
                },
                new CommentSortOption
                {
                    Value = UnderstoodDotOrg.Common.Constants.MyAccountSearchValues.OldestToNewest.ToString(),
                    Description = DictionaryConstants.OldestToNewestLabel,
                    SortAscending = true
                },
                new CommentSortOption
                {
                    Value = UnderstoodDotOrg.Common.Constants.MyAccountSearchValues.NumberOfComments.ToString(),
                    Description = DictionaryConstants.NumberOfCommentsLabel,
                    SortAscending = true
                },
                new CommentSortOption
                {
                    Value = UnderstoodDotOrg.Common.Constants.MyAccountSearchValues.RecentComments.ToString(),
                    Description = DictionaryConstants.RecentCommentsLabel,
                    SortAscending = true
                }
            };
        }

        
        /// <summary>
        /// Formats the input string to show only the first 100 characters
        /// </summary>
        /// <param name="inputString">String to be formatted</param>
        /// <returns></returns>
        public static string FormatString100(string inputString)
        {
            if (inputString.Length >= 100)
            {
                string myString = inputString.Substring(0, 100);

                int index = myString.LastIndexOf(' ');
                //Have to check the value for index
                if (index > -1)
                    myString = myString.Substring(0, index);

                return myString;
            }
            else
            {
                return inputString;
            }
        }

        public static string FormatRemoveHtml(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        public static Comment ReadComment(string commentId)
        {
            var webClient = new WebClient();

            Comment comment = null;

            string adminKeyBase64 = CommunityHelper.TelligentAuth();
            if (!String.IsNullOrEmpty(commentId))
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                    var requestUrl = GetApiEndPoint(String.Format("comments/{0}.xml", commentId));

                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    var node = xmlDoc.SelectSingleNode("Response/Comment");
                    if (node != null)
                        comment = new Comment(node);
                }
                catch (Exception ex)
                {
                    comment = null;
                }
            }
            return comment;
        }

        public static XmlNode ReadUserComments(string userId)
        {
            var webClient = new WebClient();
            XmlNode node = null;

            string adminKeyBase64 = CommunityHelper.TelligentAuth();
            try
            {
                //TODO: retrieve current logged in user
                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                //webClient.Headers.Add("Rest-Impersonate-User", userId);

                var requestUrl = GetApiEndPoint(String.Format("comments.xml?UserId={0}", userId));

                var xml = webClient.DownloadString(requestUrl);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                node = xmlDoc.SelectSingleNode("Response");
            }
            catch (Exception ex)
            {
                node = null;
            }
            return node;

        }

        public static int GetTotalComments(string blogId, string blogPostId)
        {
            int count = 0;
            int id = 0;
            int postId = 0;

            if (String.IsNullOrEmpty(blogId) || String.IsNullOrEmpty(blogPostId)
                || !Int32.TryParse(blogId, out id) || !Int32.TryParse(blogPostId, out postId))
            {
                return count;
            }

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                    // TODO: Add error handling for invalid ids
                    var requestUrl = GetApiEndPoint(String.Format("blogs/{0}/posts/{1}/comments.xml?PageSize=1&SortBy=CreatedUtcDate&SortOrder=Descending",
                        blogId, blogPostId));
                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNode node = xmlDoc.SelectSingleNode("Response/Comments");

                    if (node != null)
                    {
                        count = Convert.ToInt32(node.Attributes["TotalCount"].Value);
                    }
                }
                catch { }
            }

            return count;
        }

        public static DateTime? GetRecentCommentDate(string blogId, string blogPostId)
        {
            int id = 0;
            int postId = 0;

            if (String.IsNullOrEmpty(blogId) || String.IsNullOrEmpty(blogPostId)
                || !Int32.TryParse(blogId, out id) || !Int32.TryParse(blogPostId, out postId))
            {
                return null;
            }

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                    // TODO: Add error handling for invalid ids
                    var requestUrl = GetApiEndPoint(String.Format("blogs/{0}/posts/{1}/comments.xml?PageSize=1&SortBy=CreatedUtcDate&SortOrder=Descending",
                        blogId, blogPostId));
                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNodeList nodes = xmlDoc.SelectNodes("Response/Comments/Comment");

                    foreach (XmlNode xn in nodes)
                    {
                        string commentDate = xn["PublishedDate"].InnerText;
                        DateTime parsedDate = DateTime.Parse(commentDate);

                        return parsedDate;
                    }

                }
                catch { }
            }

            return null;
        }

        public static BlogPost ReadBlogBody(int blogId, int blogPostId)
        {
            int id = 0;
            int postId = 0;
            BlogPost blogPost = new BlogPost();

            if (String.IsNullOrEmpty(blogId.ToString()) || String.IsNullOrEmpty(blogPostId.ToString())
                || !Int32.TryParse(blogId.ToString(), out id) || !Int32.TryParse(blogPostId.ToString(), out postId))
            {
                return blogPost;
            }

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                    var requestUrl = GetApiEndPoint(String.Format("blogs/{0}/posts/{1}.xml", blogId, blogPostId));

                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNode node = xmlDoc.SelectSingleNode("Response/BlogPost");

                    XmlNode auth = xmlDoc.SelectSingleNode("Response/BlogPost/Author");


                    blogPost = new BlogPost
                    {
                        Body = node["Body"].InnerText,
                        Title = node["Title"].InnerText,
                        ContentId = node["ContentId"].InnerText,
                        ContentTypeId = node["ContentTypeId"].InnerText,
                        ContentUrl = node["Url"].InnerText,
                        BlogName = CommunityHelper.BlogNameById(node["BlogId"].InnerText),
                        PublishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(node["PublishedDate"].InnerText),
                        Author = auth["DisplayName"].InnerText
                    };

                }
                catch { } // TODO: Add logging
            }
            return blogPost;
        }

        public static string PostComment(string blogId, string blogPostId, string body, string currentUser)
        {
            string contentId = string.Empty;
            using (var webClient = new WebClient())
            {
                if (!currentUser.Equals("admin"))
                {
                    try
                    {
                        webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                        currentUser = currentUser.Trim().ToLower();
                        webClient.Headers.Add("Rest-Impersonate-User", currentUser);

                        var postUrl = GetApiEndPoint(String.Format("blogs/{0}/posts/{1}/comments.xml", blogId, blogPostId));

                        var data = new NameValueCollection()
                        {
                            { "Body", body },
                            { "BlogId", blogId.ToString() }
                        };

                        byte[] result = webClient.UploadValues(postUrl, data);
                        // TODO: handle errors
                        string response = webClient.Encoding.GetString(result);

                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(response);

                        XmlNode node = xmlDoc.SelectSingleNode("Response/Comment");
                        contentId = node["CommentId"].InnerText;
                        return contentId;
                    }
                    catch { } //TODO: Add logging
                }
            }
            return contentId;
        }

        //public static string CreateQuestion(string title, string body, string currentUser)
        //{
        //    using (var webClient = new WebClient())
        //    {
        //        try
        //        {
        //            webClient.Headers.Add("Rest-User-Token", TelligentAuth());
        //            currentUser = currentUser.Trim().ToLower();
        //            webClient.Headers.Add("Rest-Impersonate-User", currentUser.ToLower());

        //            // TODO: change to constant
        //            var requestUrl = GetApiEndPoint(String.Format("wikis/{0}/pages.xml", "2"));

        //            var values = new NameValueCollection();
        //            values["Title"] = title;
        //            values["Body"] = body;

        //            var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

        //            Console.WriteLine(xml);

        //            XmlDocument xmlDoc = new XmlDocument();
        //            xmlDoc.LoadXml(xml);

        //            XmlNode node = xmlDoc.SelectSingleNode("Response/WikiPage");
        //            string contentId = node["ContentId"].InnerText;
        //            string wikiPageId = node["Id"].InnerText;
        //            string queryString = "?wikiId=2&wikiPageId=" + wikiPageId + "&contentId=" + contentId;
        //            return queryString;
        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }
        //}

        public static string GetApiEndPoint(string path)
        {
            // Normalize path
            if (path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            return String.Format("{0}/api.ashx/v2/{1}",
                            Settings.GetSetting(Constants.Settings.TelligentConfig).TrimEnd('/'),
                            path);
        }

        public static int GetTotalLikes(string contentId)
        {
            int count = 0;
            Guid guid = Guid.Empty;

            if (Guid.TryParse(contentId, out guid))
            {
                using (var webClient = new WebClient())
                {
                    try
                    {
                        // TODO: add validation for invalid content id

                        webClient.Headers.Add("Rest-User-Token", CommunityHelper.TelligentAuth());
                        var requestUrl = GetApiEndPoint(string.Format("likes.xml?ContentId={0}&PageSize=1",
                            guid.ToString()));

                        var xml = webClient.DownloadString(requestUrl);

                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml);
                        XmlNode node = xmlDoc.SelectSingleNode("Response/Likes");

                        if (node != null)
                        {
                            count = Convert.ToInt32(node.Attributes["TotalCount"].Value);
                        }

                    }
                    catch { }
                }
            }

            return count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">Unique username to be used in the Telligent Community</param>
        /// <param name="email">Unique email to be used in the Telligent Community</param>
        public static bool CreateUser(string username, string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("Required value is missing: Email");
                }
                if (string.IsNullOrEmpty(username))
                {
                    throw new Exception("Required value is missing: username");
                }

                using (var webClient = new WebClient())
                {

                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                    var requestUrl = GetApiEndPoint("users.xml");

                    var values = new NameValueCollection()
                    {
                        { "Username", username },
                        { "Password", Guid.NewGuid().ToString() },
                        { "PrivateEmail", email }
                    };

                    var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));
                    return true;
                }
            }
            catch (Exception e)
            {
                Exception createException = new Exception("An error occurred when creating the Community User. Please see Inner Exception for details.", e);
                createException.Source = "CommunityHelper.cs CreateUser(string username, string email)";
                throw createException;
            }
        }

        //public static List<Question> GetQuestionsList(string wikiId, int count)
        //{
        //    int id = 0;
        //    List<Question> questionList = new List<Question>();

        //    if (String.IsNullOrEmpty(wikiId) || !Int32.TryParse(wikiId, out id))
        //    {
        //        return questionList;
        //    }

        //    using (var webClient = new WebClient())
        //    {

        //        webClient.Headers.Add("Rest-User-Token", TelligentAuth());
        //        var requestUrl = GetApiEndPoint(String.Format("wikis/{0}/pages.xml?PageSize={1}", wikiId, count));

        //        var xml = webClient.DownloadString(requestUrl);

        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.LoadXml(xml);

        //        XmlNodeList nodes = xmlDoc.SelectNodes("Response/WikiPages/WikiPage");
        //        foreach (XmlNode xn in nodes)
        //        {
        //            XmlNode user = xn.SelectSingleNode("User");
        //            XmlNode app = xn.SelectSingleNode("Content/Application");

        //            var queryString = "?wikiId=" + wikiId + "&wikiPageId=" + xn["Id"].InnerText + "&contentId=" + xn["ContentId"].InnerText;

        //            Question question = new Question()
        //            {
        //                Title = xn["Title"].InnerText,
        //                PublishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(xn["CreatedDate"].InnerText),
        //                Body = xn["Body"].InnerText,
        //                WikiPageId = xn["Id"].InnerText,
        //                ContentId = xn["ContentId"].InnerText,
        //                Author = user["Username"].InnerText,
        //                Group = app["HtmlName"].InnerText,
        //                CommentCount = xn["CommentCount"].InnerText,
        //                QueryString = queryString,
        //                // TODO: replace this with constant or guid lookup
        //                Url = "/en/community-and-events/q-and-a/q-and-a-details" + queryString,
        //            };
        //            questionList.Add(question);
        //        }
        //    }
        //    return questionList;
        //}


        //public static List<Answer> GetAnswers(string wikiId, string wikiPageId, string contentId)
        //{
        //    string likes = GetTotalLikes(contentId).ToString();
        //    List<Answer> answerList = new List<Answer>();
        //    using (var webClient = new WebClient())
        //    {
        //        webClient.Headers.Add("Rest-User-Token", TelligentAuth());
        //        var requestUrl = GetApiEndPoint(string.Format("wikis/{0}/pages/{1}/comments.xml", wikiId, wikiPageId));

        //        var xml = webClient.DownloadString(requestUrl);

        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.LoadXml(xml);

        //        XmlNodeList nodes = xmlDoc.SelectNodes("Response/Comments/Comment");
        //        int count = 0;
        //        foreach (XmlNode xn in nodes)
        //        {
        //            XmlNode user = xn.SelectSingleNode("Author");
        //            Answer answer = new Answer()
        //            {
        //                PublishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(xn["PublishedDate"].InnerText),
        //                Body = xn["Body"].InnerText,
        //                Author = user["Username"].InnerText,
        //                AuthorAvatar = user["AvatarUrl"].InnerText,
        //                Count = nodes.Count.ToString(),
        //                Likes = likes,
        //            };
        //            answerList.Add(answer);
        //            count++;
        //        }
        //    }
        //    return answerList;
        //}

        public static string BlogNameById(string blogId)
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                var requestUrl = GetApiEndPoint(string.Format("blogs/{0}.xml", blogId));

                var xml = webClient.DownloadString(requestUrl);

                Console.WriteLine(xml);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                var nodes = xmlDoc.SelectNodes("/Response/Blog");
                string blogName = nodes[0]["Name"].InnerText;
                return blogName;
            }
        }

        //public static List<MemberCardModel> GetModerators()
        //{
        //    using (var webClient = new WebClient())
        //    {
        //        string adminKeyBase64 = CommunityHelper.TelligentAuth();

        //        webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

        //        var roleid = Sitecore.Configuration.Settings.GetSetting("TelligentModeratorRoleID") ?? "3";
        //        var serverHost = Sitecore.Configuration.Settings.GetSetting("TelligentConfig") ?? "localhost/telligent.com";
        //        var requestUrl = serverHost + "/api.ashx/v2/roles/" + roleid + "/users.xml";

        //        var xml = webClient.DownloadString(requestUrl);
        //        var xmlDoc = new XmlDocument();
        //        xmlDoc.LoadXml(xml);
        //        var nodes = xmlDoc.SelectNodes("/Response/Users/User");
        //        //// PagedList<Comment> commentList = PublicApi.Comments.Get(new CommentGetOptions() { UserId = 2100 });
        //        //// lblCount.Text = nodes.Count.ToString();
        //        List<MemberCardModel> memberCardSrc = new List<MemberCardModel>();
        //        foreach (XmlNode item in nodes)
        //        {
        //            MemberCardModel cm = new MemberCardModel();
        //            cm.AvatarUrl = item.SelectSingleNode("AvatarUrl").InnerText;

        //            // TODO: This is to change once we figure out retrieving users by roleid
        //            cm.UserLabel = "Moderator";

        //            cm.UserLocation = item.SelectSingleNode("Location").InnerText;
        //            cm.UserName = item.SelectSingleNode("Username").InnerText;

        //            memberCardSrc.Add(cm);
        //            cm = null;
        //        }
        //        return memberCardSrc;
        //    }
        //}

        /// <summary>
        /// Gets a list of blog posts that a specified blog contains.
        /// </summary>
        /// <param name="blogId">As string, if multiple, separate with a comma. Ex:("1,2,4")</param>
        /// <param name="count">As string, this is the number of records to be returned.</param>
        /// <returns></returns>
        public static List<BlogPost> ListBlogPosts(string blogId, string count)
        {
            using (var webClient = new WebClient())
            {

                webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                var requestUrl = GetApiEndPoint(string.Format("blogs/posts.xml?BlogIds={0}&PageSize={1}", blogId, count));

                var xml = webClient.DownloadString(requestUrl);

                List<BlogPost> blogPosts = new List<BlogPost>();

                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                XmlNodeList nodes = xmlDoc.SelectNodes("Response/BlogPosts/BlogPost");
                foreach (XmlNode node in nodes)
                {
                    XmlNode author = node.SelectSingleNode("Author");
                    var blogName = CommunityHelper.BlogNameById(node["BlogId"].InnerText);
                    string title = string.Empty;
                    string sitecoreId = string.Empty;
                    string url = string.Empty;
                    if (node["Title"].InnerText.Contains("{"))
                    {
                        string[] s = node["Title"].InnerText.Split('{');
                        title = s[0];
                        url = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{" + s[1]));
                    }
                    else
                    {
                        url = Regex.Replace(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{37FB73FC-F1B3-4C04-B15D-CAFAA7B7C87F}")) +
                        "/" + blogName + "/" + node["Title"].InnerText, ".aspx", "");
                    }
                    BlogPost blogPost = new BlogPost()
                    {
                        Title = node["Title"].InnerText,
                        ContentId = node["ContentId"].InnerText,
                        Body = FormatString100(node["Body"].InnerText),
                        PublishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(node["PublishedDate"].InnerText),
                        BlogName = blogName,
                        Author = author["DisplayName"].InnerText,
                        // TODO: Fix this logic a lot
                        Url = url,
                        ParentUrl = Regex.Replace(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{37FB73FC-F1B3-4C04-B15D-CAFAA7B7C87F}")) +
                        "/blogposts?BlogId=" + node["BlogId"].InnerText, ".aspx", ""),
                        CommentCount = node["CommentCount"].InnerText,
                    };
                    blogPosts.Add(blogPost);
                }
                return blogPosts;
            }
        }

        public static List<Blog> ListBlogs()
        {
            List<Blog> blogs = new List<Blog>();
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Rest-User-Token", CommunityHelper.TelligentAuth());
                    var requestUrl = GetApiEndPoint("blogs.xml");

                    var xml = webClient.DownloadString(requestUrl);

                    blogs = new List<Blog>();

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    XmlNodeList nodes = xmlDoc.SelectNodes("Response/Blogs/Blog");
                    int count = 0;
                    foreach (XmlNode node in nodes)
                    {
                        string title = node["Name"].InnerText;
                        string description = FormatString100(node["Description"].InnerText);
                        string blogId = node["Id"].InnerText;
                        Blog blogPost = new Blog()
                        {
                            Title = title,
                            Description = description,
                            BlogId = blogId,
                            Url = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("/sitecore/content/Home/Community and Events/Blogs/" + title))
                        };
                        if (!title.Equals("Articles") && !title.Equals("Assistive Tools") && !title.Equals("Behavior Tools"))
                        {
                            blogs.Add(blogPost);
                        }
                        count++;
                    }
                }
            }
            catch { } //TODO: Add Logging
            return blogs;
        }

        public static XmlNode ReadGroup(string groupID)
        {
            XmlNode node = null;

            if (!String.IsNullOrEmpty(groupID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = CommunityHelper.TelligentAuth();
                try
                {
                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    var xmlDoc = new XmlDocument();
                    var requestUrl = GetApiEndPoint(String.Format("groups/{0}.xml", groupID));
                    var xml = webClient.DownloadString(requestUrl);

                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectSingleNode("Response/Group");
                }
                catch (Exception ex)
                {
                    node = null;
                }
            }
            return node;

        }
        public static XmlNode ReadForum(string forumID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(forumID))
            {
                using (WebClient webClient = new WebClient())
                {
                    string adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                    var requestUrl = GetApiEndPoint(String.Format("forums/{0}.xml", forumID));
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectSingleNode("Response/Forum");
                }
            }
            return node;
        }
        public static XmlNode ReadForums(string groupID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(groupID))
            {
                using (WebClient webClient = new WebClient())
                {
                    string adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                    var requestUrl = GetApiEndPoint(String.Format("groups/{0}/forums.xml", groupID));
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectSingleNode("Response/Forums");
                }
            }
            return node;
        }
        public static XmlNode ReadThreads(string forumID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(forumID))
            {
                using (WebClient webClient = new WebClient())
                {
                    string adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                    var requestUrl = GetApiEndPoint(String.Format("forums/{0}/threads.xml", forumID));
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectSingleNode("Response/Threads");
                }
            }
            return node;
        }
        public static XmlNode ReadThread(string forumID, string threadID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(forumID) && !String.IsNullOrEmpty(threadID))
            {
                using (WebClient webClient = new WebClient())
                {
                    string adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    try
                    {
                        var requestUrl = GetApiEndPoint(String.Format("forums/{0}/threads/{1}.xml", forumID, threadID));
                        var xml = webClient.DownloadString(requestUrl);
                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml);
                        node = xmlDoc.SelectSingleNode("Response/Thread");
                    }
                    catch (Exception ex)
                    {
                        node = null;
                    }
                }
            }
            return node;
        }
        public static XmlNode ReadReply(string replyID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(replyID))
            {
                using (WebClient webClient = new WebClient())
                {
                    string adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                    var requestUrl = GetApiEndPoint(String.Format("forums/threads/replies/{0}.xml", replyID));
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectSingleNode("Response/Reply");
                }
            }
            return node;
        }
        public static void PostReply(string forumID, string threadID, string body)
        {
            using (WebClient webClient = new WebClient())
            {
                string adminKeyBase64 = CommunityHelper.TelligentAuth();
                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                try
                {
                    var requestUrl = GetApiEndPoint(String.Format("forums/{0}/threads/{1}/replies.xml", forumID, threadID));
                    var values = new NameValueCollection();
                    values["Body"] = body;

                    var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error PostReply:\n" + ex.Message);

                }
            }
        }
        public static List<ReplyModel> ReadReplies(string forumID, string threadID)
        {
            List<ReplyModel> replies = new List<ReplyModel>();
            if (!String.IsNullOrEmpty(forumID) && !String.IsNullOrEmpty(threadID))
            {
                using (WebClient webClient = new WebClient())
                {
                    string adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    try
                    {
                        var requestUrl = GetApiEndPoint(String.Format("forums/{0}/threads/{1}/replies.xml", forumID, threadID));
                        var xml = webClient.DownloadString(requestUrl);
                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml);
                        XmlNode node = xmlDoc.SelectSingleNode("Response/Replies");

                        if (node != null)
                        {
                            foreach (XmlNode reply in node)
                            {
                                ReplyModel rpm = new ReplyModel(reply);

                                replies.Add(rpm);
                                rpm = null;
                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        Sitecore.Diagnostics.Error.LogError("Error in ReadReplies CommunityHelper.\nError" + ex.Message);
                        replies = null;
                    }
                }
            }
            return replies;
        }
        //public static List<ThreadModel> ReadThreadList(string forumID)
        //{
        //    List<ThreadModel> th = new List<ThreadModel>();
        //    try
        //    {
        //        var node = ReadThreads(forumID);
        //        foreach (XmlNode childNode in node)
        //        {
        //            ThreadModel t = new ThreadModel(childNode);
        //            th.Add(t);
        //            // Thread.Sleep(3000);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Bth = null;
        //        Sitecore.Diagnostics.Error.LogError(ex.Message);
        //    }
        //    return th;
        //}
        public static string ReadUserId(string username)
        {
            string Userid = null;
            if (!String.IsNullOrEmpty(username))
            {
                username = username.Trim();
                using (WebClient webClient = new WebClient())
                {
                    string adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                    try
                    {
                        var requestUrl = GetApiEndPoint(String.Format("users/{0}.xml", username.ToLower()));
                        var xml = webClient.DownloadString(requestUrl);
                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml);
                        XmlNode node = xmlDoc.SelectSingleNode("Response/User");
                        if (node != null)
                        {
                            //Read user id
                            Userid = node.SelectSingleNode("Id").InnerText;
                            //return Userid;
                        }
                    }
                    catch (Exception ex)
                    {
                        Userid = null;
                    }

                }
            }
            return Userid;
        }
       //public static List<ForumModel> ReadForumsList(string groupID)
       // {
       //     List<ForumModel> fm = new List<ForumModel>();
       //     try
       //     {
       //         var node = ReadForums(groupID);
       //         foreach (XmlNode childNode in node)
       //         {
       //             ForumModel f = new ForumModel(childNode);
       //             fm.Add(f);
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         fm = null;
       //     }
       //     return fm;
       // }
        public static bool IsUserInGroup(string userScreenName, string groupID)
        {
            bool val = false;

            if (!String.IsNullOrEmpty(userScreenName) && !String.IsNullOrEmpty(groupID))
            {
                userScreenName = userScreenName.Trim();
                groupID = groupID.Trim();
                using (WebClient webClient = new WebClient())
                {
                    string adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    try
                    {
                        var requestUrl = GetApiEndPoint(String.Format("groups/{0}/members/users/{1}.xml", groupID, userScreenName));
                        var xml = webClient.DownloadString(requestUrl);
                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml);
                        XmlNode node = xmlDoc.SelectSingleNode("Response/User/Group");

                        if (node != null)
                            val = true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return val;

        }
        public static bool JoinGroup(string groupID, string userScreenName)
        {
            bool success = false;
            userScreenName = userScreenName.Trim();
            groupID = groupID.Trim();
            if (!String.IsNullOrEmpty(userScreenName) && !String.IsNullOrEmpty(groupID.Trim()))
            {
                string userid = ReadUserId(userScreenName);
                if (userid != null)
                {
                    try
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            string adminKeyBase64 = CommunityHelper.TelligentAuth();
                            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                            var requestUrl = GetApiEndPoint(string.Format("groups/{0}/members/users.xml ", groupID));

                            var values = new NameValueCollection();
                            values["UserId"] = userid;

                            var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));
                            var xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(xml);
                            XmlNode node = xmlDoc.SelectSingleNode("Response/Errors");
                            if (node != null || !node.HasChildNodes)
                            {
                                success = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return success;
        }
        public static string TelligentAuth()
        {
            //Telligent Forum info
            string adminKeyBase64 = String.Empty;
            string keyTest = Settings.GetSetting(Constants.Settings.TelligentAdminApiKey);
            var apiKey = String.IsNullOrEmpty(keyTest) ? "d956up05xiu5l8fn7wpgmwj4ohgslp" : keyTest;

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));
            return adminKeyBase64;
        }

        public static List<Notification> GetNotifications(string username)
        {

            List<Notification> notificationList = new List<Notification>();

            if (String.IsNullOrEmpty(username))
            {
                return notificationList;
            }

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                    var requestUrl = GetApiEndPoint("notifications.xml");
                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNodeList nodes = xmlDoc.SelectNodes("Response/Notifications/RestNotification");

                    foreach (XmlNode xn in nodes)
                    {
                        XmlNode userData = xmlDoc.SelectSingleNode("Response/Notifications/RestNotification/User");
                        if (!username.Equals(userData["Username"].InnerText))
                        {
                            XmlNode authorData = xmlDoc.SelectSingleNode("Response/Notifications/RestNotification/User/Author");
                            XmlNode statusData = xmlDoc.SelectSingleNode("Response/Notifications/RestNotification/User/Author/CurrentStatus");

                            Notification notification = new Notification()
                            {
                                Username = username,
                                Author = authorData["Username"].InnerText,
                                ContentId = xn["ContentId"].InnerText,
                                CreatedDate = xn["CreatedDate"].InnerText,
                                UpdatedDate = xn["LastUpdatedDate"].InnerText,
                                NotificationId = xn["NotificationId"].InnerText
                            };
                            notificationList.Add(notification);
                        }
                    }
                }
                catch { } //TODO: Add Logging
            }
            return notificationList;
        }

        public static int GetTotalComments(Sitecore.Data.Items.Item item)
        {
            int totalComments = 0;
            if (item.Fields["BlogId"] != null && item.Fields["BlogPostId"] != null)
            {
                totalComments = CommunityHelper.GetTotalComments(
                                item.Fields["BlogId"].Value,
                                item.Fields["BlogPostId"].Value);
            }

            return totalComments;
        }

        public static DateTime? GetRecentCommentDate(Sitecore.Data.Items.Item item)
        {
            DateTime? recentCommentDate = null;

            if (item.Fields["BlogId"] != null && item.Fields["BlogPostId"] != null)
            {
                recentCommentDate = CommunityHelper.GetRecentCommentDate(
                                item.Fields["BlogId"].Value,
                                item.Fields["BlogPostId"].Value);
            }

            return recentCommentDate;
        }

        public static List<FavoritesModel> GetFavorites(Guid username)
        {
            List<FavoritesModel> favoritesList = new List<FavoritesModel>();

            ActivityLog log = new ActivityLog(username, Constants.UserActivity_Values.Favorited);

            foreach (ActivityItem ai in log.Activities)
            {
                Sitecore.Data.Items.Item item = Sitecore.Context.Database.GetItem(ai.ContentId);
                if (item != null)
                {
                    ContentPageItem contentPage = item;
                    favoritesList.Add(new FavoritesModel
                    {
                        Title = contentPage.PageTitle,
                        Url = item.GetUrl(),
                        ContentId = ai.ContentId,
                        ReplyCount = GetTotalComments(item).ToString(),
                        RecentCommentDate = GetRecentCommentDate(item),
                        Type = GetContentType(item),
                        Date = ai.DateModified
                    });
                }
            }

            return favoritesList;
        }

        private static string GetContentType(Sitecore.Data.Items.Item item)
        {
            if (item.InheritsTemplate(DefaultArticlePageItem.TemplateId))
            {
                return ((DefaultArticlePageItem)item).GetArticleType();
            }
            else if (item.InheritsTemplate(BaseEventDetailPageItem.TemplateId))
            {
                return ((BaseEventDetailPageItem)item).GetEventType();
            }

            return String.Empty;
        }

        public static List<Comment> ListUserComments(string username)
        {
            List<Comment> commentsList = new List<Comment>();

            using (var webClient = new WebClient())
            {
                string adminKeyBase64 = CommunityHelper.TelligentAuth();
                try
                {
                    var userId = ReadUserId(username);
                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    var requestUrl = GetApiEndPoint(String.Format("comments.xml?PageSize=100&SortBy=CreatedUtcDate&SortOrder=Descending&UserId={0}", userId));
                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNodeList nodes = xmlDoc.SelectNodes("Response/Comments/Comment");

                    int nodecount = 0;
                    foreach (XmlNode xn in nodes)
                    {
                        Comment comment = new Comment(xn);
                        commentsList.Add(comment);

                        nodecount++;
                    }
                }
                catch { } // TODO: add logging
            }
            return commentsList;
        }

        //public static List<GroupModel> GetUserGroups(string username)
        //{
        //    List<GroupModel> groupsList = new List<GroupModel>();

        //    using (var webClient = new WebClient())
        //    {
        //        if (!String.IsNullOrEmpty(username))
        //        {
        //            username = username.Trim();
        //            username = username.ToLower();
        //            string adminKeyBase64 = CommunityHelper.TelligentAuth();
        //            try
        //            {
        //                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
        //                //webClient.Headers.Add("Rest-Impersonate-User", userId);
        //                var requestUrl = GetApiEndPoint(String.Format("groups.xml?Username={0}", username));
        //                var xml = webClient.DownloadString(requestUrl);

        //                var xmlDoc = new XmlDocument();
        //                xmlDoc.LoadXml(xml);

        //                XmlNodeList nodes = xmlDoc.SelectNodes("Response/Groups/Group");
        //                foreach (XmlNode xn in nodes)
        //                {
        //                    GroupModel group = new GroupModel
        //                    {
        //                        Title = xn["Name"].InnerText,
        //                        Url = "/Community and Events/Groups/" + xn["Name"].InnerText,
        //                        Id = xn["Id"].InnerText
        //                    };
        //                    groupsList.Add(group);
        //                }
        //            }
        //            catch (Exception ex) { groupsList = null; Sitecore.Diagnostics.Error.LogError("GetuserGroups Error:\n" + ex.Message); } // TODO: add logging
        //        }
        //    }
        //    return groupsList;
        //}

        public static List<Comment> ReadComments()
        {
            List<Comment> commentList = new List<Comment>();

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                    var requestUrl = GetApiEndPoint("comments.xml?PageSize=100");
                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNodeList nodes = xmlDoc.SelectNodes("Response/Comments/Comment");

                    foreach (XmlNode xn in nodes)
                    {
                        Comment comment = new Comment(xn);
                        commentList.Add(comment);
                    }
                }
                catch { } // TODO: add logging
            }
            return commentList;
        }

        public static List<Comment> ReadComments(string blogIds)
        {
            List<Comment> commentList = new List<Comment>();

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                    var requestUrl = GetApiEndPoint("comments.xml?PageSize=100&SortOrder=Descending");
                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNodeList nodes = xmlDoc.SelectNodes("Response/Comments/Comment");

                    foreach (XmlNode xn in nodes)
                    {
                        XmlNode author = xn.SelectSingleNode("User");
                        XmlNode app = xn.SelectSingleNode("Content/Application");
                        XmlNode content = xn.SelectSingleNode("Content");

                        var commentId = xn["CommentId"].InnerText;
                        var isApproved = xn["IsApproved"].InnerText;
                        var replyCount = xn["ReplyCount"].InnerText;
                        var commentContentTypeId = xn["CommentContentTypeId"].InnerText;
                        var body = xn["Body"].InnerText;
                        var publishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(xn["CreatedDate"].InnerText);
                        var authorId = author["Id"].InnerText;
                        var authorAvatarUrl = author["AvatarUrl"].InnerText;
                        var authorDisplayName = author["DisplayName"].InnerText;
                        var authorProfileUrl = author["ProfileUrl"].InnerText;
                        var authorUsername = author["Username"].InnerText;
                        var parentTitle = content["HtmlName"].InnerText;
                        if (app["HtmlName"].InnerText != "Articles" && app["HtmlName"].InnerText != "General"
                            && app["HtmlName"].InnerText != "Assistive Tools")
                        {
                            Comment comment = new Comment()
                            {
                                CommentId = commentId,
                                IsApproved = isApproved,
                                ReplyCount = replyCount,
                                CommentContentTypeId = commentContentTypeId,
                                Body = body,
                                PublishedDate = publishedDate,
                                AuthorId = authorId,
                                AuthorAvatarUrl = authorAvatarUrl,
                                AuthorDisplayName = authorDisplayName,
                                AuthorProfileUrl = authorProfileUrl,
                                AuthorUsername = authorUsername,
                                ParentTitle = parentTitle,
                                Url = "~/Community and Events/Blogs/" + app["HtmlName"].InnerText + "/" + parentTitle,
                            };
                            commentList.Add(comment);
                        }
                    }
                }
                catch { } // TODO: add logging
            }
            return commentList;
        }

        public static LikeModel GetLike(string username, string contentId, string contentTypeId)
        {
            var like = new LikeModel();

            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(contentId) || !string.IsNullOrEmpty(contentTypeId))
            {
                using (var webClient = new WebClient())
                {
                    try
                    {
                        webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                        var requestUrl = GetApiEndPoint("likes.xml?PageSize=100&ContentId=" + contentId + "&ContentTypeId=" + contentTypeId);
                        var xml = webClient.DownloadString(requestUrl);

                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml);

                        XmlNodeList nodes = xmlDoc.SelectNodes("Response/Likes/Like");

                        foreach (XmlNode xn in nodes)
                        {
                            XmlNode authorInfo = xn.SelectSingleNode("User");
                            if (authorInfo["Username"].InnerText.Equals(username))
                            {
                                like = new LikeModel()
                                {
                                    ContentUrl = xn["Url"].InnerText
                                };
                            }
                        }
                        return like;
                    }
                    catch { } //TODO: Add Logging
                }
            }
            return like;
        }

        public static bool SaveItem(string username, string contentId, string contentTypeId)
        {
            username.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(contentId) || string.IsNullOrEmpty(contentTypeId))
            {
                return false;
            }
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                    webClient.Headers.Add("Rest-Impersonate-User", username);

                    var requestUrl = GetApiEndPoint("bookmark.xml");

                    var values = new NameValueCollection();
                    values.Add("ContentId", contentId);
                    values.Add("ContentTypeId", contentTypeId);

                    var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool CreateFriendship(string requesterUsername, string requesteeUsername)
        {
            string requesteeUserId = string.Empty;

            if (requesterUsername.IsNullOrEmpty() || requesteeUsername.IsNullOrEmpty())
            {
                return false;
            }
            try
            {
                requesteeUserId = CommunityHelper.ReadUserId(requesteeUsername);
            }
            catch
            {
                return false;
            }
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                    var requestUrl = GetApiEndPoint(String.Format("users/{1}/friends.xml", "http://telligent.dev01.rax.webstagesite.com/telligent/", requesterUsername.Trim()));

                    var values = new NameValueCollection();
                    values["RequesteeId"] = requesteeUserId.Trim();
                    values["RequestMessage"] = "Lemme be yo friend";

                    var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

                    Console.WriteLine(xml);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        
        public static string ReadUserEmail(string username)
        {
            string email = null;
            if (!String.IsNullOrEmpty(username))
            {
                username = username.Trim();
                using (WebClient webClient = new WebClient())
                {
                    string adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                    try
                    {
                        var requestUrl = GetApiEndPoint(String.Format("users/{0}.xml", username.ToLower()));
                        var xml = webClient.DownloadString(requestUrl);
                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml);
                        XmlNode node = xmlDoc.SelectSingleNode("Response/User");
                        if (node != null)
                        {
                            //Read user id
                            email = node.SelectSingleNode("PrivateEmail").InnerText;
                            //return Userid;
                        }
                    }
                    catch (Exception ex)
                    {
                        email = null;
                    }

                }
            }
            return email;
        }

        //public static void PostAnswer(string wikiId, string wikiPageId, string body, string currentUser)
        //{
        //    using (var webClient = new WebClient())
        //    {
        //        if (!currentUser.Equals("admin"))
        //        {
        //            try
        //            {
        //                webClient.Headers.Add("Rest-User-Token", TelligentAuth());
        //                currentUser = currentUser.Trim().ToLower();
        //                webClient.Headers.Add("Rest-Impersonate-User", currentUser);

        //                var postUrl = GetApiEndPoint(String.Format("wikis/{0}/pages/{1}/comments.xml", wikiId, wikiPageId));

        //                var data = new NameValueCollection()
        //                {
        //                    { "Body", body },
        //                    { "PublishedDate", DateTime.Now.ToString() },
        //                    { "IsApproved", "true" },
        //                    { "BlogId", wikiId }
        //                };

        //                byte[] result = webClient.UploadValues(postUrl, data);
        //                // TODO: handle errors
        //                string response = webClient.Encoding.GetString(result);
        //            }
        //            catch { } //TODO: Add logging
        //        }
        //    }
        //}
    }
}