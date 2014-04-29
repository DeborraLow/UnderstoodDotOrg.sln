﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.TelligentCommunity
{
    public class Comment
    {
        public string _id { get; set; }
        public string _url { get; set; }
        public string _body { get; set; }
        public string _parentId { get; set; }
        public string _publishedDate { get; set; }
        public string _likes { get; set; }
        public string _commentId { get; set; }
        public string _contentId { get; set; }
        public string _commentContentTypeId { get; set; }
        public string _authorId { get; set; }
        public string _authorAvatarUrl { get; set; }
        public string _authorDisplayName { get; set; }
        public string _authorProfileUrl { get; set; }
        public string _replyCount { get; set; }
        public string _isApproved { get; set; }
        public string _authorUsername { get; set; }

        public Comment(string id, string url, string body, string parentId, string contentId, string isApproved, string replyCount,
            string commentId, string commentContentTypeId, string authorId, string authorAvatarUrl, string authorUsername, string publishedDate,
                string authorDisplayName, string authorProfileUrl, string likes)
        {
            _id = id;
            _url = url;
            _body = body;
            _parentId = parentId;
            _contentId = contentId;
            _isApproved = isApproved;
            _replyCount = replyCount;
            _commentId = commentId;
            _commentContentTypeId = commentContentTypeId;
            _publishedDate = publishedDate;
            _authorId = authorId;
            _authorAvatarUrl = authorAvatarUrl;
            _authorDisplayName = authorDisplayName;
            _authorProfileUrl = authorProfileUrl;
            _authorUsername = authorUsername;
            _likes = likes;
        }
    }

    public class BlogPost
    {
        public string _body { get; set; }
        public string _title { get; set; }
        public string _publishedDate { get; set; }
        public string _author { get; set; }

        public BlogPost(string body, string title, string publishedDate, string author)
        {
            _body = body;
            _title = title;
            _publishedDate = publishedDate;
            _author = author;
        }
    }
}
