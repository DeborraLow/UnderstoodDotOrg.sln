﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Understood.Newsletter;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.Newsletter;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup
{
    public partial class Newsletter_SignUp : BaseSublayout<SignUpPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
            BindEvents();
        }

        private void BindContent()
        {
            txtEmail.Attributes["placeholder"] = DictionaryConstants.EnterEmailAddressWatermark;
            rfvEMail.Text = Model.RequiredEmailError.Raw;
            btnSignup.Text = DictionaryConstants.SubscribeButtonText;
        }

        private void BindEvents()
        {
            btnSignup.Click += btnSignup_Click;
        }

        void btnSignup_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // TODO: validate email
                string email = txtEmail.Text.Trim();

                Submission submission = new Submission
                {
                    Email = email
                };

                Session[Constants.SessionNewsletterKey] = submission;

                var item = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(Constants.Pages.NewsletterChildInfo.ToString()));
                Response.Redirect(item.GetUrl());
            }
        }
    }
}