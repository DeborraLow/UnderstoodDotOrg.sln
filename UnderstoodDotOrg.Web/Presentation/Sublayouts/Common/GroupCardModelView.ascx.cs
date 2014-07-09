﻿using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Services.CommunityServices;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class GroupCardModelView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item currItem = Sitecore.Context.Item;
            if(currItem !=null){
                UnderstoodDotOrg.Domain.Understood.Common.GroupCardModel gm = Groups.GroupCardModelFactory(new GroupItem(currItem));
                InitializeView(gm);
            }
        }

        protected void InitializeView(UnderstoodDotOrg.Domain.Understood.Common.GroupCardModel gm)
        {
            if (gm != null)
            {
                imgModeratorImage.ImageUrl = gm.ModeratorAvatarUrl;
                litDesc.Text = gm.Description;
                litModeratorScreenName.Text = gm.ModeratorName;
                litModeratorTitle.Text = gm.ModeratorTitle;
                litTitle.Text = gm.Title;
                litNumMembers.Text = gm.NumOfMembers.ToString();
                litNumThreads.Text = gm.NumOfDiscussions.ToString();

            }
        }
    }
}