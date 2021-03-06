﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class EmailAndAlertsPreferences : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //fill the page with values from current member

                //bg: The form elements in the ascx for alert notification settings have been commented out
                // so as to remove confusion - the alerts are not being used, we can not test them, we have already validated that we 
                // can save the settings in the db


                ux_advocacy_alerts.Checked = CurrentMember.AdvocacyAlerts;
                ux_content_reminders.Checked = CurrentMember.ContentReminders;
                ux_event_reminders.Checked = CurrentMember.EventReminders;
                ux_notifications_digest.Checked = CurrentMember.NotificationsDigest;
                ux_observation_log_reminders.Checked = CurrentMember.ObservationLogReminders;
                ux_private_message_alerts.Checked = CurrentMember.PrivateMessageAlerts;
                ux_support_plan_reminders.Checked = CurrentMember.SupportPlanReminders;
                ux_weekly_personalized_newsletter.Checked = CurrentMember.allowNewsletter;
                
                ux_digest_email_weekly.Checked = CurrentMember.Subscribed_WeeklyDigest;
                ux_digest_email_daily.Checked = CurrentMember.Subscribed_DailyDigest;
            }
        }

        protected void uxSave_Click(object sender, EventArgs e)
        {
            uxMessage.Text = "";
            CurrentMember.AdvocacyAlerts = ux_advocacy_alerts.Checked;
            CurrentMember.ContentReminders = ux_content_reminders.Checked;
            CurrentMember.EventReminders =  ux_event_reminders.Checked;
            CurrentMember.NotificationsDigest = ux_notifications_digest.Checked;
            CurrentMember.ObservationLogReminders = ux_observation_log_reminders.Checked;
            CurrentMember.PrivateMessageAlerts = ux_private_message_alerts.Checked;
            CurrentMember.SupportPlanReminders = ux_support_plan_reminders.Checked;
            CurrentMember.allowNewsletter = ux_weekly_personalized_newsletter.Checked;

            CurrentMember.Subscribed_DailyDigest = ux_digest_email_daily.Checked;
            CurrentMember.Subscribed_WeeklyDigest = ux_digest_email_weekly.Checked; 

            
            MembershipManager mgr = new MembershipManager();
            try
            {
                mgr.UpdateMemberAlertPrefernces(CurrentMember);
                
            }
            catch(Exception ex)
            {
                uxMessage.Text = ex.Message ;
            }
            uxMessage.Text += DictionaryConstants.MyAccount_PreferencesSavedLabel;
        }
    }
}