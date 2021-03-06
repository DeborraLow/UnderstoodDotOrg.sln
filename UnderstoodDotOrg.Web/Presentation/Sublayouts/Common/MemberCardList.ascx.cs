﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common 
{
    public partial class MemberCardList : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            rptMemberCards.ItemDataBound += rptMemberCards_ItemDataBound;

            base.OnInit(e);
        }
        void rptMemberCards_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.EmptyItem)
            {
                if (e.Item.DataItem != null)
                {
                    Label emptyText = (Label)e.Item.FindControl("txtEmpty");
                    if (emptyText != null)
                    {
                        emptyText.Text = EmptyText??"There are no community members within your selections, try to remove a filter option for better results";


                    }
                }
            }
            else if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                if (e.Item.DataItem != null)
                {
                    Image avaturl = (Image)e.Item.FindControl("UserAvatar");
                    if (avaturl != null)
                    {
                        avaturl.ImageUrl = ((MemberCardModel)e.Item.DataItem).AvatarUrl;


                    }

                    Literal username = (Literal)e.Item.FindControl("UserName");
                    if (username != null)
                    {
                        username.Text = ((MemberCardModel)e.Item.DataItem).UserName;


                    }

                    HtmlAnchor profileLink = (HtmlAnchor)e.Item.FindControl("hrefProfileLink");
                    if(profileLink!=null)
                    {
                        profileLink.HRef = ((MemberCardModel)e.Item.DataItem).ProfileLink;
                    }

                    HtmlControl divImg = (HtmlControl)e.Item.FindControl("lblImg");
                    Literal userlbl = (Literal)e.Item.FindControl("UserLabel");
                    if (userlbl != null)
                    {
                        userlbl.Text = ((MemberCardModel)e.Item.DataItem).UserLabel;
                        divImg.Visible = true;

                    }

                    var member = TelligentService.GetPosesMember(username.Text);
                    if (member != null)
                    {
                        Literal userloc = (Literal)e.Item.FindControl("UserLocation");
                        if (userloc != null)
                        {
                            if (member.ZipCode != null)
                            {
                                userloc.Text = UnderstoodDotOrg.Services.CommunityServices.GeoTargeting.GetStateByZip(member.ZipCode);
                                //userloc.Text = ((MemberCardModel)e.Item.DataItem).UserLocation;
                            }
                        }
                    }
                    ConnectButton btnConnect = (ConnectButton)e.Item.FindControl("connectBtn");
                    if (btnConnect != null)
                    {

                        if (((MemberCardModel)e.Item.DataItem).Contactable)
                        {
                            btnConnect.Visible = true;
                            btnConnect.LoadState(((MemberCardModel)e.Item.DataItem).UserName);
                        }
                        else
                            btnConnect.Visible = false;

                    }

                    Repeater childModel_repeater = (Repeater)e.Item.FindControl("rptChildCard");
                    if (childModel_repeater != null)
                    {
                        childModel_repeater.DataSource = ((MemberCardModel)e.Item.DataItem).Children;
                        childModel_repeater.DataBind();
                    }

                    Repeater badgeModel_repeater = (Repeater)e.Item.FindControl("rptrBadges");
                    if (badgeModel_repeater != null)
                    {
                        badgeModel_repeater.DataSource = ((MemberCardModel)e.Item.DataItem).Badges;
                        badgeModel_repeater.DataBind();
                    }

                }

            }


        }
        protected void rptChildCard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Repeater childIssues_repeater = (Repeater)e.Item.FindControl("rptChildIssues");
            if (childIssues_repeater != null)
            {
                childIssues_repeater.DataSource = ((ChildCardModel)e.Item.DataItem).IssueList;
                childIssues_repeater.DataBind();
            }
        }

        public List<MemberCardModel> DataSource
        {
            set
            {
                rptMemberCards.DataSource = value;
            }
            get
            {
                return rptMemberCards.DataSource as List<MemberCardModel>;
            }
        }

        public string EmptyText { get; set; }
        public override void DataBind()
        {
            rptMemberCards.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSource = new List<MemberCardModel>();
        }

       
    }
}