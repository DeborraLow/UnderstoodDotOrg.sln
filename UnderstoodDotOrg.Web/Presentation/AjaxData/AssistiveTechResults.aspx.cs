﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData
{
    public partial class AssistiveTechResults : System.Web.UI.Page
    {
        protected IEnumerable<AssistiveToolsReviewPageItem> SearchResults { get; set; }
        protected int ClickCount { get; set; }
        protected Guid SearchPageId { get; set; }
        protected Guid CategoryId { get; set; }
        protected SearchHelper.SortOptions.AssistiveToolsSortOptions SortOption { get; set; }
        protected string Keyword { get; set; }
        protected Guid? IssueId { get; set; }
        protected Guid? GradeId { get; set; }
        protected Guid? TechTypeId { get; set; }
        protected Guid? PlatformId { get; set; }

        protected AssistiveToolsSearchResultsPageItem SearchPage
        {
            get
            {
                return Sitecore.Context.Database.GetItemAs<AssistiveToolsSearchResultsPageItem>(SearchPageId);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SearchPageId = Request["pageId"].AsNGuid().Value;
                CategoryId = Request["categoryId"].AsNGuid().Value;
                ClickCount = Request["count"].AsInt();
                Keyword = Request["keyword"];
                if (!string.IsNullOrEmpty(Keyword))
                {
                    IssueId = Request["issueId"].AsNGuid();
                    GradeId = Request["gradeId"].AsNGuid();
                    TechTypeId = Request["techTypeId"].AsNGuid();
                    PlatformId = Request["platformId"].AsNGuid();
                }

                var defaultSortValue = (int)SearchHelper.SortOptions.AssistiveToolsSortOptions.Relevance;
                SortOption = Request["sortOption"].AsEnum<SearchHelper.SortOptions.AssistiveToolsSortOptions>(defaultValue: defaultSortValue);

                SearchResults = AssistiveToolsSearchResultsPageItem.GetSearchResults(
                    IssueId, 
                    GradeId, 
                    TechTypeId, 
                    PlatformId, 
                    Keyword, 
                    SortOption);

                SearchResults = SearchResults
                    .Where(i => i.Category.Item != null && i.Category.Item.ID.Guid == CategoryId)
                    .Skip(ClickCount * Constants.ASSISTIVE_TECH_ENTRIES_PER_PAGE)
                    .Take(Constants.ASSISTIVE_TECH_ENTRIES_PER_PAGE);

                rptrResults.DataSource = SearchResults;
                rptrResults.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to load more results", ex);
            }
        }
    }
}