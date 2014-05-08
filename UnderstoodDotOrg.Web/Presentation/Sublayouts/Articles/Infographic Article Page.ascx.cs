﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.Glossarypage;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Infographic_Article_Page : System.Web.UI.UserControl
    {
        InfographicArticlePageItem ObjInfographArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjInfographArticle = new InfographicArticlePageItem(Sitecore.Context.Item);
            if(ObjInfographArticle!=null)
            {
                //Get Reviewer Details
                if (ObjInfographArticle.DefaultArticlePage.Reviewedby.Item != null && ObjInfographArticle.DefaultArticlePage.ReviewedDate.DateTime != null)//Reviwer Name
                    SBReviewedBy.Visible = true;
                else
                    SBReviewedBy.Visible = false;

            }

        }
    }
}