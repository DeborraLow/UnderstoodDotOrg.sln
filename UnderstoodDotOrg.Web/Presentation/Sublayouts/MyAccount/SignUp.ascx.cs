﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class SignUp : BaseRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.CurrentMember != null && this.CurrentUser != null)
            {
                Response.Redirect(MyAccountFolderItem.GetMyProfilePage());
            }

            uxEmailAddress.Attributes["placeholder"] = DictionaryConstants.EnterEmailAddressWatermark;
            uxFirstName.Attributes["placeholder"] = DictionaryConstants.FirstNameWatermark;
            uxPassword.Attributes["placeholder"] = DictionaryConstants.EnterPasswordWatermark;
            uxPasswordConfirm.Attributes["placeholder"] = DictionaryConstants.ReEnterNewPasswordWatermark;
            uxZipCode.Attributes["placeholder"] = DictionaryConstants.ZipCodeWatermark;

            uxSubmit.Text = DictionaryConstants.SubmitButtonText;
            this.Page.Form.DefaultButton = this.uxSubmit.UniqueID;

            uxSignIn.Text = DictionaryConstants.SignInButtonText;
            uxSignIn.NavigateUrl = MyAccountFolderItem.GetSignInPage();

            if (!string.IsNullOrEmpty(AccessToken))
            {
                var client = new Facebook.FacebookClient(AccessToken);
                dynamic me = client.Get("me", new { fields = "name,email" });

                uxEmailAddress.Text = me.email;
                uxFirstName.Text = me.name;

                var pass = Guid.NewGuid().ToString().Substring(0, 12);

                uxPassword.Attributes["value"] = pass;
                uxPasswordConfirm.Attributes["value"] = pass;

                uxPassword.Enabled = false;
                uxPasswordConfirm.Enabled = false;
            }
        }

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            // server-side validation
            string name = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            
            string zip = uxZipCode.Text;
            bool newsletter = uxNewsletterSignup.Checked;
            bool isFacebookUser = !string.IsNullOrEmpty(AccessToken);

            if (!string.IsNullOrEmpty(uxFirstName.Text))
            {
                name = uxFirstName.Text;
            }

            if (!string.IsNullOrEmpty(uxEmailAddress.Text))
            {
                email = uxEmailAddress.Text;
            }

            if (isFacebookUser)
            {
                password = Constants.FacebookMember_Password;
            }
            else if (!string.IsNullOrEmpty(uxPassword.Text) && !string.IsNullOrEmpty(uxPasswordConfirm.Text) && uxPassword.Text == uxPasswordConfirm.Text)
            {
                password = uxPassword.Text;
            }

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {                
                // damnit barry, this is how you get ants. 
                // the site keeps breaking when we test, and its breaking ugly.
                // if someone clicks to create a new user, we have to blow up the existing user or we're going to have a problem.
                this.FlushRegisteringUser();

                //everything's cool
                if (this.registeringUser == null)
                {
                    this.registeringUser = new Domain.Membership.Member();
                }

                this.registeringUser.FirstName = name;
                
                //bg: adding in zip code
                this.registeringUser.ZipCode = zip.Trim();

                //adding marker for FB users
                this.registeringUser.isFacebookUser = isFacebookUser;

                var membershipManager = new MembershipManager();

                try
                {
                    // helps to call the right addMember method...
                    this.registeringUser = membershipManager.AddMember(this.registeringUser, email, password);
                }
                catch (Exception ex)
                {
                    uxErrorMessage.Text = ex.Message;
                    return;
                }

                this.CurrentMember = this.registeringUser;
                this.CurrentUser = membershipManager.GetUser(this.CurrentMember.MemberId);
                var termsAndConditionsPage = MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetTermsandConditionsPage();

                Response.Redirect(termsAndConditionsPage.GetUrl());
            }
            else
            {
                //something failed...
                uxErrorMessage.Text = "Please provide your name, email address, and a password to create your account";
            }
        }
    }
}