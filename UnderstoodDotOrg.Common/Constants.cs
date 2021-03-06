﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common
{
    public static class Constants
    {
        public const int PERSONALIZATION_ARTICLES_PER_USER = 40;
        public const int PERSONALIZATION_ARTICLES_PER_BUCKET = 8;
        public const int SEARCH_RESULTS_ENTRIES_PER_PAGE = 5;
        public const int BEHAVIOR_SEARCH_RESULTS_ENTRIES_PER_PAGE = 9;
        public const int TOPIC_LISTING_ARTICLES_PER_PAGE = 6;
        public const int SECTION_LANDING_ARTICLES_PER_ROW = 3;
        public const int SUBTOPIC_LISTING_ARTICLES_PER_PAGE = 9;
        public const int EVENT_ARCHIVE_ENTRIES_PER_PAGE = 6;
        public const int EXPERT_LISTING_ENTRIES_PER_PAGE = 9;
        public const int ASSISTIVE_TECH_ENTRIES_PER_PAGE = 3;
        public const int FEATURED_TOPIC_GALLERY_ENTRIES = 4;
        public const int SUBTOPIC_WIDGETS_ENTRIES = 3;
        public const int MORE_LIKE_THIS_ENTRIES = 6;
        public const int ARTICLE_COMMENTS_PER_PAGE = 5;
        public const int HOMEPAGE_FEATURED_ARTICLES = 6;
        public const int BEHAVIOR_TOOLS_FEATURED_ARTICLES = 9;
        public const int PUBLIC_PROFILE_COMMENTS_PER_PAGE = 5;
        public const int WHATS_HAPPENING_MY_FRIENDS_ENTRIES = 8;
        public const int MY_CONNECTIONS_FRIENDS_PER_PAGE = 16;
        public const int MY_ACCOUNT_CONNECTIONS_WIDGET_ENTRIES = 3;

        #region Query Strings

        public static readonly string SCLANG_QUERY_STRING = "sc_lang";
        public static readonly string CHALLENGE_QUERY_STRING = "challenge";
        public static readonly string GRADE_QUERY_STRING = "grade";
        public static readonly string HANDLER_CHILD_QUERY_STRING = "childid";
        public static readonly string HANDLER_MEMBER_QUERY_STRING = "memberid";
        public static readonly string HANDLER_TIMELY_DATE_QUERY_STRING = "date";
        public static readonly string SEARCH_TERM_QUERY_STRING = "q";
        public static readonly string SEARCH_TYPE_FILTER_QUERY_STRING = "t";
        public static readonly string EVENT_GRADE_FILTER_QUERY_STRING = "grade";
        public static readonly string EVENT_ISSUE_FILTER_QUERY_STRING = "issue";
        public static readonly string EVENT_TOPIC_FILTER_QUERY_STRING = "topic";
        public static readonly string EVENT_FEATURED_FILTER_QUERY_STRING = "featured";
        public static readonly string EVENT_RECOMMENDED_FILTER_QUERY_STRING = "recommended";
        public static readonly string FACEBOOK_LOGIN_STATUS = "fb_status";
        public static readonly string ACCOUNT_EMAIL = "account";
        public static readonly string VIEW_MODE = "viewmode";
        public static readonly string VIEW_MODE_VISITOR = "visitor";
        public static readonly string VIEW_MODE_MEMBER = "member";
        public static readonly string VIEW_MODE_FRIEND = "friend";
        public static readonly string DONATION_AMOUNT = "amount";
        #endregion

        #region Salesforce
        public static readonly string SALESFORCE_USERNAME = "SalesforceUsername";
        public static readonly string SALESFORCE_PASSWORD = "SalesforcePassword";
        public static readonly string SALESFORCE_TOKEN = "SalesforceToken";
        public static readonly string SALESFORCE_SERVICE_URL = "SalesforceServiceURL";
        #endregion

        #region Exact Target
        public static readonly string EXACT_TARGET_USERNAME = "ExactTargetUsername";
        public static readonly string EXACT_TARGET_PASSWORD = "ExactTargetPassword";
        public static readonly string EXACT_TARGET_TOKEN = "ExactTargetToken";
        public static readonly string EXACT_TARGET_SERVICE_URL = "ExactTargetServiceURL";
        #endregion


        #region Newsletter Subscriptions


        public static string CURRENT_INDEX_NAME
        {
            get
            {
                return string.Format("sitecore_{0}_index", Sitecore.Context.Database.Name.ToLower());
            }
        }

        public static string MembershipProviderName
        {
            get
            {
                return "UnderstoodMembership";
            }
        }

		public static class EmailIDs
		{
			//English IDs
			public static int EM1WelcomeToUnderstoodENID = 352;
			public static int EM2ParentToolkitENID = 512;
			public static int EM3ExploreTheCommunityENID = 516;
			public static int EM4LearnActENID = 517;
			public static int EM6HolidayDonationsENID = 519;
			public static int EM7NewsletterConfirmationENID = 520;
			public static int EM8SubscriptionConfirmedENID = 521;
			public static int EM9GroupWelcomeENID = 522;
			public static int EM10WebinarConfirmationENID = 335;
			public static int EM11DonationAcknowledgementENID = 513;
			public static int EM12ThankYouForContactingUsENID = 514;
			public static int EM13ActivityFromTodayENID = 533;
			public static int EM14ActivityFromThisWeekENID = 534;
			public static int EM15HappyHolidaysENID = 518;
			public static int EM16ContentReminderENID = 523;
			public static int EM17ObservationLogReminderENID = 524;
			public static int EM18UpdateProfileReminderENID = 525;
			public static int EM19WebinarReminderENID = 526;
			public static int EM21PrivateMessageENID = 527;
			public static int EM22ForgotPasswordENID = 844;
			public static int EM23PasswordResetConfirmationENID = 529;
			public static int EM24ContentSharedWithAFriendENID = 956;
			public static int EM25WebinarSharedWithAFriendENID = 531;
			public static int EM28AppsTechnologySharedWithAFriendENID = 538;
            public static int BehaviorToolSuggestion = 1543;

            public static int E1GeneralNewsLetter = 2303;
            

			//Spanish IDs
			public static int EM1WelcomeToUnderstoodSPID = 1725;
			public static int EM2ParentToolkitSPID = 1714;
			public static int EM3ExploreTheCommunitySPID = 1721;
			public static int EM4LearnActSPID = 1706;
			public static int EM6HolidayDonationsSPID = 1707;
			public static int EM7NewsletterConfirmationSPID = 1722;
			public static int EM8SubscriptionConfirmedSPID = 1723;
			public static int EM9GroupWelcomeSPID = 1724;
			public static int EM10WebinarConfirmationSPID = 1692;
			public static int EM11DonationAcknowledgementSPID = 1695;
			public static int EM12ThankYouForContactingUSSPID = 1696;
			public static int EM13ActivityFromTodaySPID = 1708;
			public static int EM14ActivityFromThisWeekSPID = 1709;
			public static int EM15HappyHolidaysSPID = 1697;
			public static int EM16ContentReminderSPID = 1698;
			public static int EM17ObservationLogReminderSPID = 1710;
			public static int EM18UpdateProfileReminderSPID = 1711;
			public static int EM19WebinarReminderSPID = 1712;
			public static int EM21PrivateMessageSPID = 1715;
			public static int EM22ForgotPasswordSPID = 1716;
			public static int EM23PasswordResetConfirmationSPID = 1717;
			public static int EM24ContentSharedWithAFriendSPID = 1718;
			public static int EM25WebinarSharedWithAFriendSPID = 1719;
			public static int EM28AppsTechnologySharedWithAFriendSPID = 1720;
		}

        public const string ConnectionStringMembership = "membership";

        #endregion

        #region Session Keys
        public static string currentUserKey { get { return "_understood_org_current_user"; } }
        public static string currentMemberKey { get { return "_understood_org_current_member"; } }
        public static string SessionBehaviorSearchKey { get { return "_understood_org_behavior_search"; } }
        public static string SessionNewsletterKey { get { return "_understood_org_newsletter"; } }

        public static string sessionUnauthenticatedMemberKey { get { return "_understood_org_unauthenticated_member"; } }

        public static string currentUserFacebookAccessToken { get { return "_understood_org_current_user_facebook_access_token"; } }

        public static string SessionPreviousUrl { get { return "_understood_url"; } }
        #endregion

        #region Language
        public static Guid Language_English_US { get { return Guid.Parse("AF584191-45C9-4201-8740-5409F4CF8BDD"); } }
        public static Guid Language_Spanish { get { return Guid.Parse("32819E5E-8A88-4005-9B68-CE93807A9D0F"); } }
        
        #endregion


        #region Unauthenticated Member Values
        public static string UnauthenticatedMember_ScreeName { get { return "c5uSwuWruy2Q5NADejus"; } }
        public static string UnauthenticatedMember_Password{ get { return "4Sf9suVucReD373HDS"; } }
        public static string UnauthenticatedMember_FirstName { get { return "Unauthenticated"; } }
        public static string UnauthenticatedMember_LastName { get { return "NotSpecified"; } }
        
        public static string UnauthenticatedMember_Flag { get { return "IsUnauthenticatedMember=true"; } }

        public static string FacebookMember_Password { get { return "4Sf9suVucReD373HDS!asdxz443#"; } }
#endregion

        #region Search
        public static class Search
        {
            public const string ArticleSearchIndex = "sitecore_web_index";
            public const float ArticleSearchPageTitleBoost = 3;
            public const string ContentSearchPath = "/sitecore/content/home/";
        }
        #endregion

        #region Container Guid

        public static Guid AssistiveToolsGlobalContainer
        {
            get
            {
                return new Guid("{493EB983-FDE9-46E4-85C8-EE45EABFE91B}");
            }
        }

        public static Guid GradeContainer
        {
            get
            {
                return new Guid("{1106FF43-4C23-412E-A37D-E19C6A34CF8F}");
            }
        }

        public static Guid ChallengesContainer
        {
            get
            {
                return new Guid("{DAB8D18D-844D-489C-91CC-757F8783781E}");
            }
        }

        public static Guid IssueContainer { get { return new Guid("{4B5B4ACE-6470-4E3D-A1F9-88F34CBC1A86}"); } }
        public static Guid DiagnosisContainer { get { return new Guid("{A3955F76-4D6F-4CC0-8D3F-EECC01479EC7}"); } }
        public static Guid IEPStatusContainer { get { return new Guid("{D273E040-578D-4B1B-B0B1-E1256CB249EA}"); } }
        public static Guid Section504StatusContainer { get { return new Guid("{BDAAB8F1-8FEA-4E3D-AE6A-C436ACAEB366}"); } }

        public static Guid SearchFilterTypesContainer
        {
            get { return new Guid("{9976F89D-1FE4-49FA-A143-F6493A76D669}"); } 
        }

        public static Guid BehaviorToolLandingArticlesContainer
        {
            get { return new Guid("{87387425-6863-4C9C-818F-4CDCC0A66B5E}"); }
        }

        // Temporary
        public static Guid QATestDataContainer
        {
            get { return new Guid("{AB712123-F130-455C-B445-79BB937BB33E}"); }
        }

        // Parent Interests
        public static Guid SchoolIssueContainer 
        { 
            get { return new Guid("{596757D6-B2DB-4819-AA25-95DC9BB2FD0E}"); } 
        }
        public static Guid HomeLifeContainer 
        { 
            get { return new Guid("{18D5FA6B-32EC-476B-9194-3B18F7572D10}"); } 
        }
        public static Guid GrowingUpContainer 
        { 
            get { return new Guid("{E9194DCB-1A67-4CFF-A8A4-B799639AFADC}"); } 
        }
        public static Guid SocialEmotionalContainer 
        { 
            get { return new Guid("{E8DF800B-1002-4EF6-AB46-825E70D968F5}"); } 
        }
        public static Guid TechAppsContainer 
        { 
            get { return new Guid("{4836BBBB-3C01-4BBB-BC78-0DF1D36E32B6}"); } 
        }
        public static Guid WaysToHelpContainer 
        { 
            get { return new Guid("{E4276D4E-71D7-4E5F-B9A2-B7DF3CA2990C}"); } 
        }
        public static Guid ParentInterestsContainer
        {
            get { return new Guid("{FEC014BB-77ED-4244-A33D-27644736D9F2}"); }
        }
        public static Guid ExpertsLiveFilterContainer
        {
            get { return new Guid("{D65B262D-954C-4D3A-8D89-5E52FBA16363}"); }
        }
        public static Guid ArticleTypesContainer
        {
            get { return new Guid("{1AC85469-381C-457F-8728-CFB1FE05169A}"); }
        }

        #endregion

        #region Page Guids

        public static class Pages
        {
            public static Guid AllBlogs
            {
                get
                {
                    return new Guid("{37FB73FC-F1B3-4C04-B15D-CAFAA7B7C87F}");
                }
            }

            public static Guid AllQuestions { get { return new Guid("{F349C92A-9781-4342-A05A-5A793630D7DB}"); } }


            public static Guid ParentsGroups
            {
                get
                {
                    return new Guid("{40726696-1FD7-41CC-A662-A618C7BEEE0A}");
                }
            }
            //public static Guid ParentsGroupAll
            //    {
            //    get
            //        {
            //        return new Guid("{DEE83FC5-DB99-4FC8-875A-429F87BB3848}");
            //        }
            //    }
            public static Guid ParentsGroupRecommended
            {
                get
                {
                    return new Guid("{08B7AE83-F21D-474A-BA49-470AE71B2C12}");
                }
            }
            public static Guid ParentsLikeMeFeatured
            {
                get
                {
                    return new Guid("{23D6A9BA-6C62-4AF8-A2E0-AD18843EB105}");
                }
            }
            public static Guid ParentsLikeMeAll
            {
                get
                {
                    return new Guid("{E88BE8FC-4272-4136-918E-47DFA4FF4EF5}");
                }
            }
            public static Guid ParentsLikeMeRecommended
            {
                get
                {
                    return new Guid("{87E601F6-EA02-4D89-A91A-C3DAE789120E}");
                }
            }

            public static Guid BehaviorToolsResults
            {
                get
                {
                    return new Guid("{D4E382E1-34D1-47DB-8430-9EE4A1545B25}");
                }
            }

            public static Guid MyProfile
            {
                get
                {
                    return new Guid("{D8217E23-B6B3-4F51-A1F7-5E9673F18381}");
                }
            }

            public static Guid MyAccount
            {
                get
                {
                    return new Guid("{F4FEFD4B-0E01-48C3-9FDA-16B8576A68EC}");
                }
            }

            public static Guid PrivateMessageTool
            {
                get
                {
                    return new Guid("{8314ED31-ABA9-4304-AEFB-A2C9D6CBB42B}");
                }
            }

            public static Guid MyAccountFavorites
            {
                get
                {
                    return new Guid("{2A5936E4-1C1A-4F4C-8DDE-EB768BD43E81}");
                }
            }

            public static Guid MyAccountConnections
            {
                get
                {
                    return new Guid("{840AEEF4-5294-4A0D-8D1C-6839E39FE3FE}");
                }
            }

            public static Guid MyAccountEvents
            {
                get
                {
                    return new Guid("{355E4A54-A133-4FD4-B796-8C515F194751}");
                }
            }

            public static Guid MyAccountGroups
            {
                get
                {
                    return new Guid("{1041DF93-81A2-46FD-910F-8927F22DA4F1}");
                }
            }

            public static Guid MyAccountComments
            {
                get
                {
                    return new Guid("{E092EB37-B488-4A42-97CC-7EA875CCF877}");
                }
            }

            public static Guid SignIn
            {
                get
                {
                    return new Guid("{31F94423-5969-4506-B782-C3B8E5A2F7B9}");
                }
            }

            public static Guid SignUp
            {
                get
                {
                    return new Guid("{B313DB7F-1EB4-45AF-B448-C1091239A91B}");
                }
            }

            public static Guid Registration1
            {
                get
                {
                    return new Guid("{2A9B3FBC-208F-4DA0-8BC5-9024CA8D6F4E}");
                }
            }

            public static Guid Registration2
            {
                get
                {
                    return new Guid("{417F1D9E-E74E-4CE2-879F-CA7D38D0E43F}");
                }
            }

            public static Guid Registration3
            {
                get
                {
                    return new Guid("{95B73EB6-323A-46F8-BA21-C4F57712BE86}");
                }
            }

            public static Guid Registration4
            {
                get
                {
                    return new Guid("{907EAD93-A2AB-48ED-886C-2DF985375803}");
                }
            }

            public static Guid Registration5
            {
                get
                {
                    return new Guid("{FE5442E8-CC81-4D9C-926B-2745DF398829}");
                }
            }

            public static Guid SearchResults
            {
                get
                {
                    return new Guid("{A6EFCE43-84B2-4D04-BCF3-A2850801D72D}");
                }
            }

            public static Guid Recommendation
            {
                get
                {
                    return new Guid("{FAC9E8A7-9BD0-452E-8DB0-9C58AE3378DF}");
                }
            }

            public static Guid NewsletterSignup
            {
                get
                {
                    return new Guid("{AF084775-566F-4340-88FD-411F28AEC8C1}");
                }
            }

            public static Guid NewsletterChildInfo
            {
                get
                {
                    return new Guid("{77F9B7B9-C273-4BAD-B74A-D6C209740E67}");
                }
            }

            public static Guid NewsletterParentInterests
            {
                get
                {
                    return new Guid("{A10D484B-4DF1-47FB-BAA3-CD49C0E6CF77}");
                }
            }

            public static Guid NewsletterConfirmation
            {
                get
                {
                    return new Guid("{F356744C-54F1-4CC5-B8F9-FA8B297AC60C}");
                }
            }

            public static Guid Partners
            {
                get
                {
                    return new Guid("{9D5C0F20-379E-4CC2-B9F0-EFFC93520D56}");
                }
            }

            public static Guid ExpertLive
            {
                get
                {
                    return new Guid("{A2B11A1B-80C7-4154-8A3E-1632332C7F48}");
                }
            }

            public static Guid ExpertLanding
            {
                get { return new Guid("{BAD8FF7E-EDC1-4FC4-A48D-7BA85407C662}"); }
            }

            public static Guid WhatsHappening
            {
                get { return new Guid("{DEFA8570-6402-4FC8-A32E-D769F1F6EE0B}"); }
            }
            public static Guid CommunityRegistrationPage
            {
                get { return new Guid("{EE8EF105-6F7D-4389-B20D-4ECAD8703F70}"); }
            }
            public static Guid ViewPublicProfilePage
            {
                get { return new Guid("{C052673C-2BFC-47A9-AC13-F178E63D8086}"); }
            }
            public static Guid RegisterCommunityProfile
            {
                get { return new Guid("{EE8EF105-6F7D-4389-B20D-4ECAD8703F70}"); }
            }
            public static Guid RegisterChildInfo
            {
                get { return new Guid("{CED5327F-B3BA-4D11-B514-CA5943BAFAAC}"); }
            }
            public static Guid ResetPassword
            {
                get { return new Guid("{328F5121-EFF8-441B-AFB6-A3DF41F7BFA4}"); }
            }
            public static Guid TermsAndConditions
            {
                get { return new Guid("{307399BC-63C4-42FD-A9D3-3E7289DF4AD6}"); }
            }
            public static Guid ForgotPassword
            {
                get { return new Guid("{06AC924E-D5D1-4CED-AF7A-EB2F631AE4C4}"); }
            }
            public static Guid InternationalUser
            {
                get { return new Guid("{491396AC-E14D-4EEA-A6BD-181166BB9893}"); }
            }
            public static Guid ExpertsLiveCalendar
            {
                get { return new Guid("{B1706EE7-E119-4991-925F-0C04EFC12CA2}"); }
            }
            public static Guid AssistiveToolResults
            {
                get { return new Guid("{5DF609DC-A761-41A3-95E3-89FAC12216A6}"); }
            }
            public static Guid QandADetails
            {
                get { return new Guid("{7356A32F-1795-4EAE-BE24-EBBD79B3093C}"); }
            }
        }

        #endregion

        public static Dictionary<Guid, string> Issues
        {
            get
            {
                return new Dictionary<Guid, string> 
                { 
                    {Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"), "Attention or Staying Focused"},
                    {Guid.Parse("{777EA342-4313-45CC-BDB5-AE141FCFA016}"), "Executive Function"},
                    {Guid.Parse("{28BB0311-D062-48F0-BEDF-C2D74EB6737E}"), "Hyperactivity or Impulsivity"},
                    {Guid.Parse("{3390C210-0B22-48FD-A411-881F956EDC0C}"), "Listening"},
                    {Guid.Parse("{1D338D37-CF4E-4C1C-9499-EBA6C0A2BBA0}"), "Math"},
                    {Guid.Parse("{CB5320E9-5F0D-4204-B76C-DE630A8BBE51}"), "Motor Skill"},
                    {Guid.Parse("{2611BEA0-33E6-4732-9BD5-B56857C5EA26}"), "Reading"},
                    {Guid.Parse("{CE405288-18FA-4665-A94C-AE6A558795DF}"), "Social Skills"},
                    {Guid.Parse("{3B4DC3FC-517D-47B5-B151-198AB7B3C6D4}"), "Spoken Language"},
                    {Guid.Parse("{B904242D-E290-4A2E-86D9-372DC42AB692}"), "Writing"},
                };
            }
        }

        public static Dictionary<Guid, string> Diagnosis
        {
            get
            {
                return new Dictionary<Guid, string> 
                { 
                    {Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"), "ADHD"},
                    {Guid.Parse("{B6D3DF62-CBEC-4311-8544-38B6E890762A}"), "Auditory Processing Issue"},
                    {Guid.Parse("{CC002EC5-4328-4719-9A8D-9350E482A8FB}"), "Dyscalculia"},
                    {Guid.Parse("{DF62BA5C-234B-4A4F-813D-FE6F765E2A4A}"), "Dysgraphia"},
                    {Guid.Parse("{07544BF9-EFD2-4613-8E9D-304347993BA8}"), "Dyslexia"},
                    {Guid.Parse("{8E9E9A5A-D630-472F-9264-16039F28A12E}"), "Dyspraxia"},
                    {Guid.Parse("{D5C01CEF-3A6F-455A-ABDD-282C26086AC5}"), "Executive Functioning"},
                    {Guid.Parse("{B998E9E7-D05C-4279-B5D7-448F93089228}"), "Expressive Language Disorder"},
                    {Guid.Parse("{E55DEB0F-00D5-4F59-B86C-05655333FC72}"), "Nonverbal Learning"},
                    {Guid.Parse("{A66286A0-CD70-4FDD-9D13-9CF1C90EFC4A}"), "Receptive Language Disorder"},
                    {Guid.Parse("{256CBB20-A2DD-468E-82C6-EA7B7B82BCBA}"), "Sensory Processing"},
                    {Guid.Parse("{6A4BE256-C9D3-4F3A-9FC0-C2AD9F6304CE}"), "Social Pragmatic Language Disorder"},
                    {Guid.Parse("{493C315E-DDA0-47D6-9B8E-78125858F43A}"), "Visual Processing"},
                };
            }
        }

        public static Dictionary<Guid, string> GradesByGuid
        {
            get
            {
                return new Dictionary<Guid, string>
                {
                    
                    {Guid.Parse("{45ce350d-46d2-4346-9ccc-92c48c557dc1}"), "Kindergarten"},
                    {Guid.Parse("{E26222FB-07CD-413B-9127-9050B6D2D037}"), "1"},
                    {Guid.Parse("{0CDA88F1-5F69-485C-AE6B-50E8D5C265EB}"), "2"},
                    {Guid.Parse("{67AA2A29-E6FF-49B2-9F9E-D29F07C19C23}"), "3"},
                    {Guid.Parse("{32702CD8-0625-498F-9D8F-17691E81BC69}"), "4"},
                    {Guid.Parse("{79AB134B-CC1F-4BB6-94F8-12FE9E181F9E}"), "5"},
                    {Guid.Parse("{E82EB59B-2A3C-4910-96C9-E276C92B712E}"), "6"},
                    {Guid.Parse("{79B1ACCE-CD06-4F0C-84B2-15A6C01020B9}"), "7"},
                    {Guid.Parse("{DFF0FA84-B68E-4259-A107-274B5694247D}"), "8"},
                    {Guid.Parse("{5EEF6AE2-1CBE-4532-883F-C6C0859581A1}"), "9"},
                    {Guid.Parse("{E0B459C0-548A-4E6C-854A-E8F475416F12}"), "10"},
                    {Guid.Parse("{9FFF9854-5951-4A7F-94A5-4F8507800916}"), "11"},
                    {Guid.Parse("{0762C21C-2B35-439C-A45F-A4FCEF5C87B7}"), "12"},
                    {Guid.Parse("{A1354149-C308-4AEA-A74E-E31EA0B4142F}"), "After Highschool"},
                };
            }
        }

        public static Dictionary<string, Guid> GradesByValue
        {
            get
            {
                return new Dictionary<string, Guid> 
                { 
                    {"Kindergarten", Guid.Parse("{45ce350d-46d2-4346-9ccc-92c48c557dc1}")},
                    {"1", Guid.Parse("{E26222FB-07CD-413B-9127-9050B6D2D037}")},
                    {"2", Guid.Parse("{0CDA88F1-5F69-485C-AE6B-50E8D5C265EB}")},
                    {"3", Guid.Parse("{67AA2A29-E6FF-49B2-9F9E-D29F07C19C23}")},
                    {"4", Guid.Parse("{32702CD8-0625-498F-9D8F-17691E81BC69}")},
                    {"5", Guid.Parse("{79AB134B-CC1F-4BB6-94F8-12FE9E181F9E}")},
                    {"6", Guid.Parse("{E82EB59B-2A3C-4910-96C9-E276C92B712E}")},
                    {"7", Guid.Parse("{79B1ACCE-CD06-4F0C-84B2-15A6C01020B9}")},
                    {"8", Guid.Parse("{DFF0FA84-B68E-4259-A107-274B5694247D}")},
                    {"9", Guid.Parse("{5EEF6AE2-1CBE-4532-883F-C6C0859581A1}")},
                    {"10", Guid.Parse("{E0B459C0-548A-4E6C-854A-E8F475416F12}")},
                    {"11", Guid.Parse("{9FFF9854-5951-4A7F-94A5-4F8507800916}")},
                    {"12", Guid.Parse("{0762C21C-2B35-439C-A45F-A4FCEF5C87B7}")},
                    {"After Highschool", Guid.Parse("{A1354149-C308-4AEA-A74E-E31EA0B4142F}")},
                };
            }
        }

        public static Dictionary<string, string> StateByAbbreviation
        {
            get
            {
                return new Dictionary<string, string>
                {
                    {"AL", "Alabama"},
                    {"AK", "Alaska"},
                    {"AZ", "Arizona"},
                    {"AR", "Arkansas"},
                    {"CA", "California"},
                    {"CO", "Colorado"},
                    {"CT", "Connecticut"},
                    {"DE", "Delaware"},
                    {"FL", "Florida"},
                    {"GA", "Georgia"},
                    {"HI", "Hawaii"},
                    {"ID", "Idaho"},
                    {"IL", "Illinois"},
                    {"IN", "Indiana"},
                    {"IA", "Iowa"},
                    {"KS", "Kansas"},
                    {"KY", "Kentucky"},
                    {"LA", "Louisiana"},
                    {"ME", "Maine"},
                    {"MD", "Maryland"},
                    {"MA", "Massachusetts"},
                    {"MI", "Michigan"},
                    {"MN", "Minnesota"},
                    {"MS", "Mississippi"},
                    {"MO", "Missouri"},
                    {"MT", "Montana"},
                    {"NE", "Nebraska"},
                    {"NV", "Nevada"},
                    {"NH", "New Hampshire"},
                    {"NJ", "New Jersey"},
                    {"NM", "New Mexico"},
                    {"NY", "New York"},
                    {"NC", "North Carolina"},
                    {"ND", "North Dakota"},
                    {"OH", "Ohio"},
                    {"OK", "Oklahoma"},
                    {"OR", "Oregon"},
                    {"PA", "Pennsylvania"},
                    {"RI", "Rhode Island"},
                    {"SC", "South Carolina"},
                    {"SD", "South Dakota"},
                    {"TN", "Tennessee"},
                    {"TX", "Texas"},
                    {"UT", "Utah"},
                    {"VT", "Vermont"},
                    {"VA", "Virginia"},
                    {"WA", "Washington"},
                    {"WV", "West Virginia"},
                    {"WI", "Wisconsin"},
                    {"WY", "Wyoming"}
               };
            }
        }

        public static Dictionary<string, string> BlogIds
        {
            get
            {
                // TODO: Add remaining Blog Id's
                return new Dictionary<string, string>
                {
                    {"Free Form", "1"},
                    {"What I Wish Id Known Sooner", "2"},
                    {"Insider", "3"},
                };
            }
        }

        public static Dictionary<string, string> BlogNames
        {
            get
            {
                // TODO: Add remaining Blog Id's
                return new Dictionary<string, string>
                {
                    {"1", "Free Form"},
                    {"2", "What I Wish Id Known Sooner"},
                    {"3", "Insider"},
                };
            }
        }

        public static class QueryStrings
        {
            public static class DecisionTool
            {
                public const string IndicationQuestion = "iq";
                public const string IndicationQuestionHistory = "iqh";
                public const string IndicationAnswerHistory = "iah";
                public const string QuestionId = "qid";
            }
            public static class Registration
            {
                public const string Mode = "mode";
                public const string ModeEdit = "edit";
                public const string ModeAdd = "add";
                public const string ChildIndex = "child";                
            }
            public static class LearningTool
            {
                public const string IssueId = "iid";
                public const string GradeId = "gid";
                public const string TypeId = "tid";
                public const string PlatformId = "pid";
                public const string Keyword = "keyword";
                public const string SortOption = "sort";
            }
            public static class PublicProfile
            {
                public const string View = "view";
                public const string ViewConnections = "connections";
                public const string ViewComments = "comments";
            }
            public static class CommunitySearch
            {
                public const string Query = "q";
                public const string SearchLocation = "a";
            }
            public static class PrivateMessage
            {
                public const string Recipient = "recipient";
            }
            public static class ExpertsLive
            {
                public const string Month = "month";
                public const string Year = "year";
            }
        }
        #region User Activty Tracking
        public static class UserActivity_Values 
        {
            public const string SetReminder = "Reminder Set";
            public const string Favorited = "Item Favorited";
            public const string Shared = "Item Shared";
            public const string FoundHelpful_True = "FoundHelpfulTrue";
            public const string FoundHelpful_False = "FoundHelpfulFalse";

            public const string SharedWithEmail = "Shared Email";
            public const string SharedWithFacebook = "Shared on Facebook";
            public const string SharedWithPinterest = "Shared on Pinterest";
            public const string SharedWithTwitter = "Shared on Twitter";
            public const string SharedWithGooglePlus = "Shared on Google+";

            public const string Skipped_Blog = "SkippedBlog";
            public const string Skipped_BlogPost = "SkippedBlogPost";
            public const string Skipped_Question = "SkippedQuestion";
            public const string Skipped_Group = "SkippedGroup";
            public const string Skipped_Discussion = "SkippedDiscussion";

            public const string ItemViewed = "ItemViewed";
            public const string SubtopicItemViewed = "ItemViewed_Subtopic_";

        }
        public static class UserActivity_Types
        {
            public const int Undefined = 0;
            public const int ContentRelated = 1;

            public const int Advocacy_Survey = 2;
            public const int Advocacy_Page = 3;
            public const int Advocacy_Donation = 4;

            public const int Type_BlogPost = 5;
            public const int Type_Blog = 6;
            public const int Type_Board = 7;
            public const int Type_Discussion = 8;
            public const int Type_QuestionAndAnswer = 9;

            public const int FoundHelpfulVote = 10;
            public const int ContentSkipped = 11;
        }
        public static class UserActivity_SpecialFilters
        {
            //values specifically used in the QA section
            public const string QA_QuestionWasHelpful = "QuestionWasHelpful";
            public const string QA_QuestionWasNotHelpoful = "QuestionWasNotHelpful";

            public const string QA_AnswerWasHelpful = "AnswerWasHelpful";
            public const string QA_AnswerWasNotHelpful = "AnswerWasNotHelpful";          
        }
        
        #endregion

   
        public static class SolrFields
        {
            public const string ChildGrades = "_child_grades";
            public const string ChildIssues = "_child_issues";
            public const string ChildDiagnoses = "_child_diagnoses";
            public const string OverrideTypes = "_override_type";
            public const string TimelyStart = "date_start";
            public const string TimelyEnd = "date_end";
            public const string ParentInterests = "_applicable_interests";
            public const string Templates = "alltemplates";
            public const string ImportanceLevels = "_importance_level";
            public const string ApplicableEvaluations = "_other_applicable_evaluations";
            public const string DiagnosedConditions = "_diagnosed_condition";
            public const string ChildChallenges = "_child_challenges";
            public const string ChildBehaviorGrades = "_child_behavior_grades";
            public const string EventIssues = "_event_child_issues";
            public const string EventGrades = "_event_child_grades";
            public const string EventTopics = "_event_parent_interests";
            public const string EventStartDateUtc = "_event_start_date_utc";
            public const string EventEndDateUtc = "_event_end_date_utc";
            public const string SourceItem = "source_item";
            public const string GradeRating = "_grade_rating";
        }

        public static class ArticleTags
        {
            public static string ExcludeFromPersonalization = "{6100E802-A5B9-431F-9F4F-58238DF23DC7}";
            public static string MustRead = "{C15701FE-ACA7-4423-B630-79329383BFB1}";
            public static string Evaluated504 = "{93BF5E6A-9884-42A2-ABB7-7457D1AC0037}";
            public static string EvaluatedIEP = "{5258F442-2E85-4D11-A513-63852B7AA48B}";
            public static string ConditionDiagnosed = "{19EC4E1A-9E55-4FC1-942D-2BCBF99F0083}";
            public static string ConditionUndiagnosed = "{C9D1AD3D-C704-41D1-8817-BA1867030F45}";
            public static string AllChildDiagnosis = "{3FB0E002-E7EE-4726-B21E-2F1E6058AF5F}";
            public static string AllChildGrades = "{7DD838FD-8BD3-4861-8E1E-540E6ED9BBE9}";
            public static string AllChildIssues = "{9E988E8F-4036-49E7-B9ED-687C99A669F9}";
        }

        public static class ChildEvaluation
        {
            public const string Status504InProgress = "{55F38A58-7506-454E-95E5-0ECE22A3B99C}";
            public const string Status504No = "{5754554A-D588-4EF9-8F9C-1E1DE66446F8}";
            public const string Status504Yes = "{82102C70-B526-47FB-BD99-5F71A33C3C87}";
            public const string StatusEvaluationInProgress = "F6849A63-C841-4D79-BF53-AA68DA6D6EEB";
            public const string StatusEvaluationNo = "992AB3CB-BAE7-47C6-B040-B674DC7FD29C";
            public const string StatusEvaluationYes = "990FB117-F12E-4E3C-898B-8A9EB217FCFD";
            public const string StatusIEPInProgress = "{73842143-B6CA-4B6A-A94F-BA59C475A6D7}";
            public const string StatusIEPNo = "{80CB7C44-F570-4991-B395-6A634C2DE1D5}";
            public const string StatusIEPYes = "{FBE464C6-0E52-45C5-A1E9-660CB3C6B688}";
        }

        public static class Events
        {
            public static string OpenOfficeHourChat = "{0EE24E89-5DC8-42EF-8165-304BE63FC20E}";
            public static string Webinar = "{EF7DB9F7-3FC2-4267-805F-1482CB94F40D}";
        }

       


        public enum UserPermission
        {
            CommunityUser,
            RegisteredUser,
            AnonymousUser,
            AdminUser,
            Moderator,
            Blogger,
            Expert,
            InternationalUser,
            AgreedToTerms,
            CanPersonalize
        }

        public enum MyAccountSearchValues
        {
            MostRecent = 1,
            OldestToNewest = 2,
            NumberOfComments = 3,
            RecentComments = 4
        }

        #region Notification templates and types
        
        public static class NotificationElements
        {

            public enum NotificationType
            {
                Comment,
                Connection,
                ForumReply,
                ForumAuthorReply
            }
            public static string CommentTemplatePath
            {
                get
                {
                    return @"~/Presentation/Sublayouts/MyAccount/Notification Templates/CommentTemplate.ascx";
                }
            }
            public static string ConnectTemplatePath
            {
                get
                {
                    return @"~/Presentation/Sublayouts/MyAccount/Notification Templates/ConnectTemplate.ascx";
                }
            }

            public static string ConnectTemplateFrontPath { get { return @"~/Presentation/Sublayouts/MyAccount/Notification Templates/ConnectTemplateFront.ascx"; } }

            public static string CommentTemplateFrontPath { get { return @"~/Presentation/Sublayouts/MyAccount/Notification Templates/CommentTemplateFront.ascx"; } }

            public static string ForumReplyTemplatePath
            {
                get
                {
                    return @"~/Presentation/Sublayouts/MyAccount/Notification Templates/ForumReplyTemplate.ascx";
                }
            }

            public static string ForumReplyTemplateFrontPath { get { return @"~/Presentation/Sublayouts/MyAccount/Notification Templates/ForumReplyTemplateFront.ascx"; } }

        }
        #endregion
    

        public static class Settings
        {
          
            public static string TelligentConfig = "TelligentConfig";
            public static string TelligentBlogIds = "TelligentBlogIds";
            public static string TelligentCommentContentTypeId = "9262536b-49a3-4494-802f-04dff10424ed";
            public static string PersonalizationHandlerAllowedIps = "PersonalizationHandlerAllowedIps";
            public static string TelligentAdminApiKey = "TelligentAdminApiKey";
            public static string TelligentAssistiveTechBlogId = "TelligentAssistiveTechBlogId";
            //Added for default avatar
            public static string AnonymousAvatar = Sitecore.Configuration.Settings.GetSetting("TelligentConfig") + "/utility/anonymous.gif";
            public static string DefaultLocation = "Toronto";
            public static string SearchResultsEndpoint = "SearchResultsEndpoint";
            public static string BehaviorSearchResultsEndpoint = "BehaviorSearchResultsEndpoint";
            public static string BehaviorSuggestionEndpoint = "BehaviorSuggestionEndpoint";
            public static string CincopaApiEndpoint = "CincopaApiEndpoint";
            public static string TopicArticlesEndpoint = "TopicArticlesEndpoint";
            public static string SubtopicArticlesEndpoint = "SubtopicArticlesEndpoint";
            public static string EventArchiveEndpoint = "EventArchiveEndpoint";
            public static string FacebookAppId = "FacebookAppId";
            public static string ExpertListingEndpoint = "ExpertListingEndpoint";
            public static string GradeLevelOnMultiplier = "GradeLevelOnMultiplier";
            public static string GradeLevelOffMultiplier = "GradeLevelOffMultiplier";
            public static string GradeLevelTargetMultiplier = "GradeLevelTargetMultiplier";
            public static string CommentsListEndpoint = "CommentsListEndpoint";
            public static string ContentServiceEndpoint = "ContentServiceEndpoint";
            public static string BehaviorToolSuggestionEmail = "BehaviorToolSuggestionEmail";
            public static string WildcardUrlPlaceholder = "WildcardUrlPlaceholder";
            public static string UserCommentsEndpoint = "UserCommentsEndpoint";
            public static string UserConnectionsEndpoint = "UserConnectionsEndpoint";

            #region Salesforce
            private static string SalesforceUsername = ConfigurationManager.AppSettings[Constants.Settings.SalesforceUsername];
            private static string SalesforcePassword = ConfigurationManager.AppSettings[Constants.Settings.SalesforcePassword];
            private static string SalesforceToken = ConfigurationManager.AppSettings[Constants.Settings.SalesforceToken];
            private static string SalesforceServiceURL = ConfigurationManager.AppSettings[Constants.Settings.SalesforceServiceURL];
            #endregion

            #region Exact Target
            //private static string EmailReminderFromAddress = ConfigurationManager.AppSettings[Constants.Settings.EmailReminder.FromAddress];
            private static string ExactTargetUserName = ConfigurationManager.AppSettings[Constants.Settings.ExactTargetUserName];
            private static string ExactTargetPassword = ConfigurationManager.AppSettings[Constants.Settings.ExactTargetPassword];
            private static string ExactTargetCustomerKey = ConfigurationManager.AppSettings[Constants.Settings.ExactTargetCustomerKey];
            private static string ExactTargetServiceURL = ConfigurationManager.AppSettings[Constants.Settings.ExactTargetServiceURL];
            #endregion


        }

        public static class ContentItem
        {
            // Used for missing personalized
            public static Guid PersonalizedContentNotFound
            {
                get
                {
                    return new Guid("{93BCF308-EE08-4F66-AB64-F4CB495BB64F}");
                }
            }
        }
        
        public static class TemplateIDs
        {
            public static string VideoArticlePage  { get { return "{D84F2F6F-7B29-49B6-B940-5546CDBBE21B}"; } }
            public static string DefaultArticlePage { get { return "{2D5AF94C-1668-44C4-978A-E96E1F42CBFE}"; } }
            public static string TextTipPage { get { return "{F70B81A5-1FD4-4345-BBDE-BE68F255170D}"; } }
            public static string WebinarEventPage { get { return "{173A599B-2836-4A4B-B780-834DD515C701}"; } }
            public static string ChatEventPage { get { return "{F5D0D610-9E5B-4C28-B9D3-F6ADD8412E45}"; } }

            public static string ForgotPasswordPage { get { return "{328F5121-EFF8-441B-AFB6-A3DF41F7BFA4}"; } }

            public static Dictionary<string, string> Dictionary =
	            new Dictionary<string, string>()
                {
	                {VideoArticlePage, "Video"},
	                {DefaultArticlePage, "Article"},
	                {TextTipPage, "Tip"},
	                {WebinarEventPage, "Webinar"},
                    {ChatEventPage, "Chat"}
	            };
	        
        }

        public static class Groups
        {
            public static string GroupTemplateID { get { return "{92FB8D67-690A-45F1-B330-C4BBAE189AAF}"; } }
        }
        public static class Threads
        {
            public static string ThreadTemplateID { get { return "{E230410F-77D7-4E8C-8E6C-0FF9F9335EE5}"; } }
        }
        public static class Forums
        {
            public static string ForumTemplateID { get { return "{F14D990C-8809-4C02-BCF7-AE6719C78CBB}"; } }
        }

        public static class BlogPost
        {
            public static string BlogPostTemplateID { get { return "{261A659C-F4D4-4788-BC26-FD0EF5ADE168}"; } }
        }

        public static class Questions
        {
            public static string QuestionTemplateID { get { return "{7AEB64D9-86C6-4C78-B526-79EDEDF20D6C}"; } }
        }

        #region Salesforce Item Id to Sitecore Guid Mapping
        /// <summary>
        /// Pass in a Guid from Sitecore, get the corresponding ID that is used in Salesoforce to track the constant
        /// Issues, Grades, Journey, Interests, etc
        /// </summary>
        public static Dictionary<Guid, string> SalesforceLookupDictionary
        {
            get
            {
                return new Dictionary<Guid, string>
                { 
                    {Guid.Parse("{00000000-0000-0000-0000-000000000000}"), "a0VF00000094mK666"},	
                    {Guid.Parse("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}"), "a0VF00000094mK4MAI"},	
                    {Guid.Parse("{8FFA90D9-F2DA-402D-9AC4-7C203769C810}"), "a0VF00000094mK5MAI"},	
                    {Guid.Parse("{448FFAC8-AE1E-446D-9A38-DB134C793140}"), "a0VF00000094mK6MAI"},
                    {Guid.Parse("{0A1B36D6-85B0-4B80-A6C0-193B19CF7E94}"), "a0VF00000094mK7MAI"},	
                    {Guid.Parse("{26A98810-4539-4BB7-8D6F-43CFE075AED3}"), "a0VF00000094mK8MAI"},	
                    {Guid.Parse("{8891DE05-873F-43AE-804A-E7D1DCF6DD6D}"), "a0VF00000094mK9MAI"},	
                    {Guid.Parse("{90C09D0B-DB8F-4CAB-94EB-B91C4296AAA2}"), "a0VF00000094mKJMAY"},	
                    {Guid.Parse("{C4563D3E-CBA3-40A1-9072-1FE9584B8586}"), "a0VF00000094mKKMAY"},	
                    {Guid.Parse("{BB193A51-8492-4373-A578-CA0ADFF74A88}"), "a0VF00000094mKLMAY"},	
                    {Guid.Parse("{541EB9E1-8327-4FB8-A750-8EA9A6D0EC34}"), "a0VF00000094mKMMAY"},	
                    {Guid.Parse("{1C5ED05B-2FB6-4297-A037-F35E68C40A23}"), "a0VF00000094mKNMAY"},	
                    {Guid.Parse("{4EA66B91-F632-46E9-8A48-156149B8EEF2}"), "a0VF00000094mKOMAY"},	
                    {Guid.Parse("{447AC977-8C58-48F8-91DB-8ACD62EA5096}"), "a0VF00000094mKPMAY"},	
                    {Guid.Parse("{1F374DA8-9209-4DD2-9E0D-E63FC644941A}"), "a0VF00000094mKQMAY"},	
                    {Guid.Parse("{09DE69B9-6043-47C8-8ECB-40574E013956}"), "a0VF00000094mKRMAY"},	
                    {Guid.Parse("{3C185099-76B4-49DD-80D4-A069A3F55FA1}"), "a0VF00000094mKSMAY"},	
                    {Guid.Parse("{6DF3ED70-3AF6-4D76-8590-808F07AF50DB}"), "a0VF00000094mKTMAY"},	
                    {Guid.Parse("{C291E1B4-9A98-411C-8CFE-C175943B9A23}"), "a0VF00000094mKUMAY"},	
                    {Guid.Parse("{78FC54BD-691A-4C74-9E84-5B299094143E}"), "a0VF00000094mKVMAY"},	
                    {Guid.Parse("{060910C4-FB0C-4ED3-A16F-10E864B2B088}"), "a0VF00000094mKWMAY"},	
                    {Guid.Parse("{B98576AB-E4AD-4FFE-ABCC-1ECFF52D3485}"), "a0VF00000094mKXMAY"},	
                    {Guid.Parse("{CA2E148B-5493-4D89-ADDD-E0BD18F9506C}"), "a0VF00000094mKYMAY"},	
                    {Guid.Parse("{70045D51-CCF8-4CCD-8C14-AFE23F6759B0}"), "a0VF00000094mKZMAY"},	
                    {Guid.Parse("{5927D7F1-D49D-4DF0-82EC-70EB51B93C65}"), "a0VF00000094mKaMAI"},	
                    {Guid.Parse("{6DDF01DA-81BF-4C94-B705-373DDFD40276}"), "a0VF00000094mKbMAI"},	
                    {Guid.Parse("{DDD43387-BE5D-4884-BC13-645FA356150F}"), "a0VF00000094mKcMAI"},		
                    {Guid.Parse("{9E988E8F-4036-49E7-B9ED-687C99A669F9}"), "a0OF0000009nM4cMAE"},
                    {Guid.Parse("{28BB0311-D062-48F0-BEDF-C2D74EB6737E}"), "a0OF0000009nM4rMAE"},
                    {Guid.Parse("{B904242D-E290-4A2E-86D9-372DC42AB692}"), "a0OF0000009nM5uMAE"},
                    {Guid.Parse("{777EA342-4313-45CC-BDB5-AE141FCFA016}"), "a0OF0000009nM4mMAE"},
                    {Guid.Parse("{CE405288-18FA-4665-A94C-AE6A558795DF}"), "a0OF0000009nM5kMAE"},
                    {Guid.Parse("{2611BEA0-33E6-4732-9BD5-B56857C5EA26}"), "a0OF0000009nM5QMAU"},
                    {Guid.Parse("{3B4DC3FC-517D-47B5-B151-198AB7B3C6D4}"), "a0OF0000009nM5pMAE"},
                    {Guid.Parse("{CB5320E9-5F0D-4204-B76C-DE630A8BBE51}"), "a0OF0000009nM5LMAU"},
                    {Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"), "a0OF0000009nM4hMAE"},
                    {Guid.Parse("{1D338D37-CF4E-4C1C-9499-EBA6C0A2BBA0}"), "a0OF0000009nM5GMAU"},
                    {Guid.Parse("{3390C210-0B22-48FD-A411-881F956EDC0C}"), "a0OF0000009nM5BMAU"},
                    {Guid.Parse("{45CE350D-46D2-4346-9CCC-92C48C557DC1}"), "a0NF000001FYqY8MAL"},
                    {Guid.Parse("{E82EB59B-2A3C-4910-96C9-E276C92B712E}"), "a0NF000001FYqc5MAD"},
                    {Guid.Parse("{E26222FB-07CD-413B-9127-9050B6D2D037}"), "a0NF000001FYqYhMAL"},
                    {Guid.Parse("{E0B459C0-548A-4E6C-854A-E8F475416F12}"), "a0NF000001FYqctMAD"},
                    {Guid.Parse("{5EEF6AE2-1CBE-4532-883F-C6C0859581A1}"), "a0NF000001FYqcoMAD"},
                    {Guid.Parse("{DFF0FA84-B68E-4259-A107-274B5694247D}"), "a0NF000001FYqcUMAT"},
                    {Guid.Parse("{7CA91300-1D9F-4031-94A2-6D4950842DD2}"), "a0NF000001FYqWlMAL"},
                    {Guid.Parse("{79B1ACCE-CD06-4F0C-84B2-15A6C01020B9}"), "a0NF000001FYqcKMAT"},
                    {Guid.Parse("{9FFF9854-5951-4A7F-94A5-4F8507800916}"), "a0NF000001FYqcyMAD"},
                    {Guid.Parse("{32702CD8-0625-498F-9D8F-17691E81BC69}"), "a0NF000001FYqbqMAD"},
                    {Guid.Parse("{0CDA88F1-5F69-485C-AE6B-50E8D5C265EB}"), "a0NF000001FYqb2MAD"},
                    {Guid.Parse("{79AB134B-CC1F-4BB6-94F8-12FE9E181F9E}"), "a0NF000001FYqc0MAD"},
                    {Guid.Parse("{67AA2A29-E6FF-49B2-9F9E-D29F07C19C23}"), "a0NF000001FYqbbMAD"},
                    {Guid.Parse("{0762C21C-2B35-439C-A45F-A4FCEF5C87B7}"), "a0NF000001FaYHGMA3"},
                    {Guid.Parse("{A1354149-C308-4AEA-A74E-E31EA0B4142F}"), "a0NF000001FaYHHMA3"},
                    {Guid.Parse("{6985927C-99FF-4EE9-B9F0-A543A368594C}"), "a0SF000000ABvIsMAL"},
	                {Guid.Parse("{8B7EB70D-64B2-45B9-B06E-6AA5CB6FE983}"), "a0SF000000ABvItMAL"},
	                {Guid.Parse("{BF02DC92-2CCE-4D0A-901C-B0F26193895D}"), "a0SF000000ABvIuMAL"},
	                {Guid.Parse("{2BF9D7BE-2E40-432C-ADE7-A25C80B9B9EE}"), "a0UF000000QFoJrMAL"},
                    {Guid.Parse("{890F06AF-284E-43E1-9647-0EFEEB000526}"), "a0UF000000QFoJsMAL"},
                    {Guid.Parse("{cb9f1ac5-4e58-499c-8d07-8bc4e8d42f0f}"), "a0aF000000A3rx0IAB"},	
                    {Guid.Parse("{fa64561b-5118-4d2f-9f03-67e0cf69e6c1}"), "a0aF000000A3rx1IAB"},
                    {Guid.Parse("{0642e401-8e66-4c69-89c6-294c257456c8}"), "a0aF000000A3rx2IAB"},	
                    {Guid.Parse("{3FB0E002-E7EE-4726-B21E-2F1E6058AF5F}"), "a0QF000000HWadZMAT"},	
                    {Guid.Parse("{256CBB20-A2DD-468E-82C6-EA7B7B82BCBA}"), "a0QF000000HWaipMAD"},	
                    {Guid.Parse("{A66286A0-CD70-4FDD-9D13-9CF1C90EFC4A}"), "a0QF000000HWaeXMAT"},
                    {Guid.Parse("{B6D3DF62-CBEC-4311-8544-38B6E890762A}"), "a0QF000000HWadjMAD"},	
                    {Guid.Parse("{D5C01CEF-3A6F-455A-ABDD-282C26086AC5}"), "a0QF000000HWae8MAD"},	
                    {Guid.Parse("{6A4BE256-C9D3-4F3A-9FC0-C2AD9F6304CE}"), "a0QF000000HWaiuMAD"},	
                    {Guid.Parse("{8E9E9A5A-D630-472F-9264-16039F28A12E}"), "a0QF000000HWae3MAD"},	
                    {Guid.Parse("{DF62BA5C-234B-4A4F-813D-FE6F765E2A4A}"), "a0QF000000HWadtMAD"},	
                    {Guid.Parse("{B998E9E7-D05C-4279-B5D7-448F93089228}"), "a0QF000000HWaeDMAT"},	
                    {Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"), "a0QF000000HWadeMAD"},	
                    {Guid.Parse("{493C315E-DDA0-47D6-9B8E-78125858F43A}"), "a0QF000000HWaizMAD"},	
                    {Guid.Parse("{E55DEB0F-00D5-4F59-B86C-05655333FC72}"), "a0QF000000HWaeNMAT"},	
                    {Guid.Parse("{07544BF9-EFD2-4613-8E9D-304347993BA8}"), "a0QF000000HWadyMAD"},	
                    {Guid.Parse("{CC002EC5-4328-4719-9A8D-9350E482A8FB}"), "a0QF000000HWadoMAD"},
                    {Guid.Parse("{73842143-B6CA-4B6A-A94F-BA59C475A6D7}"), "a0dF00000052NiAIAU"},	
                    {Guid.Parse("{80CB7C44-F570-4991-B395-6A634C2DE1D5}"), "a0dF00000052NiBIAU"},	
                    {Guid.Parse("{FBE464C6-0E52-45C5-A1E9-660CB3C6B688}"), "a0dF00000052NiCIAU"},
	                {Guid.Parse("{55F38A58-7506-454E-95E5-0ECE22A3B99C}"), "a0cF0000007Q73nIAC"},		
                    {Guid.Parse("{5754554A-D588-4EF9-8F9C-1E1DE66446F8}"), "a0cF0000007Q73oIAC"},		
                    {Guid.Parse("{82102C70-B526-47FB-BD99-5F71A33C3C87}"), "a0cF0000007Q73pIAC"},	
                    {Guid.Parse("{F6849A63-C841-4D79-BF53-AA68DA6D6EEB}"), "a0eF0000008E3aIIAS"},		
                    {Guid.Parse("{992AB3CB-BAE7-47C6-B040-B674DC7FD29C}"), "a0eF0000008E3aJIAS"},		
                    {Guid.Parse("{990FB117-F12E-4E3C-898B-8A9EB217FCFD}"), "a0eF0000008E3aKIAS"}		
                };
            }
        }
                 
        #endregion

        /// <summary>
        /// Class to store regex validators for client-side validation of form submissions
        /// </summary>
        public static class Validators
        {
            /// <summary>
            /// Built-in .Net Email validator
            /// </summary>
            public const string Email = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            /// <summary>
            /// Build=in .Net US phone number validator
            /// </summary>
            public const string PhoneNumber = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}";

            /// <summary>
            /// Built-in .Net US Zipcode validator
            /// </summary>
            public const string ZipCode = @"\d{5}(-\d{4})?";

            /// <summary>
            /// Minimum of 6 characters, no uppercase/special character restriction
            /// </summary>
            public const string Password = @"[\s\S]{6,}";

            public const string MinLength5Characters = @"^[\s\S]{5,}$";
            public const string MinLength25Characters = @"^[\s\S]{25,}$";
            public const string MaxLength100Characters = @"^[\s\S]{0,100}$";
            public const string MaxLength1000Characters = @"^[\s\S]{0,1000}$";
        
        }

        public static class TelligentCommentSort
        {
            public const string CreateDate = "CreatedUtcDate";
        }

        public enum TelligentContentType
        {
            BlogPost,
            Forum,
            Group,
            Page,
            Weblog,
            Blog
        }
        public static class TelligentSearchParams
        {
            public const string Blog = "blog";
            public const string Question = "wiki";
            public const string Group = "forum";
            public const string Expert = "";
            public const string All = "";
        }
        public static class TelligentConversationStatus
        {
            public const string NotSet = "NotSet";
            public const string Read = "Read";
            public const string Unread = "Unread";
        }
        public static class TelligentFieldNames
        {
            public const string BlogId = "BlogId";
            public const string BlogPostId = "BlogPostId";
            public const string ContentId = "ContentId";
            public const string TelligentUrl = "TelligentUrl";
            public const string ContentTypeId = "ContentTypeId";
        }

        public static class TelligentRoles
        { 
            //Sitecore.Configuration.Settings.GetSetting("TelligentConfig")
            public static int Everyone { get { return int.Parse(Sitecore.Configuration.Settings.GetSetting("TelligentEveryoneRoleID")); } }
            public static int RegisteredUser { get { return int.Parse(Sitecore.Configuration.Settings.GetSetting("TelligentRegisteredUserRoleID")); } }
            public static int Moderator { get { return int.Parse(Sitecore.Configuration.Settings.GetSetting("TelligentModeratorRoleID")); } }
            public static int Administrator { get { return int.Parse(Sitecore.Configuration.Settings.GetSetting("TelligentAdministratorRoleID")); } }
            public static int Expert { get { return int.Parse(Sitecore.Configuration.Settings.GetSetting("TelligentExpertRoleID")); } }
            public static int Blogger { get { return int.Parse(Sitecore.Configuration.Settings.GetSetting("TelligentBloggerRoleID")); } }

            public static Dictionary<int, string> Roles = new Dictionary<int, string>() 
                {
	                {Everyone, DictionaryConstants.CommunityEveryone},
                    {RegisteredUser, DictionaryConstants.CommunityMember},
                    {Moderator, DictionaryConstants.CommunityModerator},
                    {Administrator, DictionaryConstants.CommunityAdministrator},
                    {Expert, DictionaryConstants.CommunityExpert},
                    {Blogger, DictionaryConstants.CommunityBlogger}
                };            
        }

        //public enum TelligentRole
        //{
        //    Expert,
        //    Moderator,
        //    Blogger,
        //    Member
        //}
        public enum TelligentFriendStatus
        {
            NotSpecified,
            Pending,
            Recieved,
            Approved
        }

        public static class GeoIPLookup
        {
            public const string GeoIPDatabaseName = "GeoIPDatabase";
            public const string GeoIPUserId = "GeoIPUserId";
            public const string GeoIPLicenseKey = "GeoIPLicenseKey";

            public enum InternationalStatus
            {
                USUser,
                AcceptedInternationalUser,
                UnknownInternationalUser
            }
        }

        public static class Cookies
        {
            public const string IsInternationalUser = "IsInternationalUser";
        }
    }
}
