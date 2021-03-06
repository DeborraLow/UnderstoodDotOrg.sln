using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class AboutUnderstoodItem : CustomItem
{

public static readonly string TemplateId = "{BD10EB3B-54F6-462A-882D-B99C7628C7A9}";

#region Inherited Base Templates

private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AboutUnderstoodItem(Item innerItem) : base(innerItem)
{
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator AboutUnderstoodItem(Item innerItem)
{
	return innerItem != null ? new AboutUnderstoodItem(innerItem) : null;
}

public static implicit operator Item(AboutUnderstoodItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField VideoEmbed
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Video Embed"]);
	}
}


public CustomTextField PartnerListHeadline
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner List Headline"]);
	}
}


public CustomTextField PartnerListSummary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Partner List Summary"]);
	}
}


public CustomTextField VideoTranscript
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Video Transcript"]);
	}
}


#endregion //Field Instance Methods
}
}