using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages
{
public partial class AssistiveToolsSearchResultsPageItem : CustomItem
{

public static readonly string TemplateId = "{DC8A235B-39D1-46BC-BCFE-DC752E6ABB04}";

#region Inherited Base Templates

private readonly AssistiveToolsBasePageItem _AssistiveToolsBasePageItem;
public AssistiveToolsBasePageItem AssistiveToolsBasePage { get { return _AssistiveToolsBasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AssistiveToolsSearchResultsPageItem(Item innerItem) : base(innerItem)
{
	_AssistiveToolsBasePageItem = new AssistiveToolsBasePageItem(innerItem);

}

public static implicit operator AssistiveToolsSearchResultsPageItem(Item innerItem)
{
	return innerItem != null ? new AssistiveToolsSearchResultsPageItem(innerItem) : null;
}

public static implicit operator Item(AssistiveToolsSearchResultsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}