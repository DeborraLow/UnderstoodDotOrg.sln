﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.ReviewTabs
{
    public partial class WhatYouNeedToKnowTab : BaseSublayout<AssistiveToolsReviewPageItem>
    {
        protected string[] SpelledNumbers = new[] { "zero", "one", "two", "three", "four", "five" };

        protected void Page_Load(object sender, EventArgs e)
        {
            var screenshots = Model.Screenshots.ListItems
                .Where(i => i != null && i.Paths.IsMediaItem)
                .Select(i => (MediaItem)i);

            rptrScreenshots.DataSource = screenshots
                .Select(mi => new
                {
                    Alt = mi.Alt,
                    Url = mi.GetImageUrl()
                }).ToList();
            rptrScreenshots.DataBind();

            var subjects = Model.Subjects.ListItems
                .Where(i => i != null)
                .Select(i => (MetadataItem)i).ToList();

            rptrSubjects.DataSource = subjects;
            rptrSubjects.DataBind();
        }
    }
}