﻿<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Register Assembly="Telerik.Web.UI" TagPrefix="telerik" Namespace="Telerik.Web.UI" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="UnderstoodDotOrg.Common.Extensions" %>
<%@ Import Namespace="Sitecore.Collections" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="Telerik.Web.UI" %>

<script runat="server">

    public IEnumerable<TSource> DistinctBy<TSource, TKey>
              (IEnumerable<TSource> source, Func<TSource, TKey> keySelector) {
        HashSet<TKey> seenKeys = new HashSet<TKey>();
        foreach (TSource element in source) {
            if (seenKeys.Add(keySelector(element))) {
                yield return element;
            }
        }
    }

    string templateId = string.Empty;
    List<Item> _realItems = new List<Item>();
    List<Item> _realItemsWithAllVersions = new List<Item>();
    List<Item> _cloneItems = new List<Item>();
    List<Item> _cloneItemsWithAllVersions = new List<Item>();
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            if (rbtLstOptions.SelectedItem != null && !rbtLstOptions.SelectedItem.ToString().IsNullOrEmpty()) {
                GetAllSitecoreItem();
            }
        }
    }

    public IEnumerable<Item> GetCloneItems(Item original) {
        return (from link in Sitecore.Globals.LinkDatabase.GetReferrers(original)
                select link.GetSourceItem() into clone
                where ((clone != null) && (clone.Source != null)) && (clone.Source.ID == original.ID)
                select clone);
    }

    Item siteItem = null;
    private void GetAllSitecoreItem() {
        Sitecore.Data.Database db = Sitecore.Data.Database.GetDatabase("master");
        siteItem = db.GetItem(Sitecore.Context.Site.RootPath);
        if (siteItem != null) {
            GetItems(siteItem);
        }
    }

    private void GetItems(Item siteItem) {
        var childList = siteItem.Children;
        Item root;
        foreach (Item child in childList) {
            AddRequiredItem(child);
            root = BuildXmlNodesForChildren(child);
        }
        if (_realItems.Any()) {
            ltItemsCount.Text = "Real Items Count - " + _realItems.Count().ToString();
            realH2Tag.Visible = true;
            RadTreeListRealItems.Visible = true;
        }
        else {
            RadTreeListRealItems.Visible = false;
            realH2Tag.Visible = false;
            ltItemsCount.Text = "No Results Found";
        }
        if (_realItemsWithAllVersions.Any()) {
            ltItemsCount.Text += "      Real Items With All Versions Count - " + _realItemsWithAllVersions.Count().ToString();
        }

        if (_cloneItems.Any()) {
            ltItemsCount.Text += "<br>Clone Items Count - " + _cloneItems.Count().ToString();
            cloneH2Tag.Visible = true;
            RadTreeListCloneItems.Visible = true;
        }
        else {
            RadTreeListCloneItems.Visible = false;
            cloneH2Tag.Visible = false;
        }
        if (_cloneItemsWithAllVersions.Any()) {
            ltItemsCount.Text += "      Clone Items With All Versions Count - " + _cloneItemsWithAllVersions.Count().ToString();
        }
    }

    /// <summary>
    /// On submit button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSubmit_OnClick(object sender, EventArgs e) {
        if (rbtLstOptions.SelectedItem != null && !rbtLstOptions.SelectedItem.ToString().IsNullOrEmpty()) {
            templateId = rbtLstOptions.SelectedValue.ToString();
            GetAllSitecoreItem();
        }
    }

    /// <summary>
    /// Recursive method to iterate through all child items and build
    /// XML tree.
    /// </summary>
    /// <param name="parentItem"></param>
    /// <param name="root"></param>
    /// <param name="doc">Initial XML Document item.</param>
    private Item BuildXmlNodesForChildren(Item parentItem) {
        //Iterate though children
        Sitecore.Collections.ChildList childList = parentItem.Children;
        foreach (Item child in childList) {
            if (child != null) {
                AddRequiredItem(child);
                BuildXmlNodesForChildren(child);
            }
        }
        return parentItem;
    }

    private void AddRequiredItem(Item child) {

        if (child.TemplateID.ToString().ToLower().Equals(templateId.ToLower()) && child.Source == null) {
            _realItems.Add(child);
            LanguageCollection collection = Sitecore.Data.Managers.ItemManager.GetContentLanguages(child);
            foreach (var lang in collection) {
                var itm = Sitecore.Data.Database.GetDatabase("master").GetItem(child.ID, lang);

                if (itm.Versions.Count > 0) {
                    _realItemsWithAllVersions.Add(itm);
                }
            }
            RadTreeListRealItems.DataSource = _realItemsWithAllVersions;
            RadTreeListRealItems.DataBind();
            RadTreeListRealItems.AllowSorting = true;
        }

        if (child.TemplateID.ToString().ToLower().Equals(templateId.ToLower()) && GetCloneItems(child).Count() > 0) {
            var cloneItems = DistinctBy(GetCloneItems(child), x => x.ID.ToString());
            foreach (var itm in cloneItems) {
                _cloneItems.Add(itm);
                LanguageCollection collection = Sitecore.Data.Managers.ItemManager.GetContentLanguages(itm);
                foreach (var lang in collection) {
                    var cloneItem = Sitecore.Data.Database.GetDatabase("master").GetItem(itm.ID, lang);
                    if (cloneItem.Versions.Count > 0) {
                        _cloneItemsWithAllVersions.Add(cloneItem);
                    }
                }
                RadTreeListCloneItems.DataSource = _cloneItemsWithAllVersions;
                RadTreeListCloneItems.DataBind();
                RadTreeListCloneItems.AllowSorting = true;
            }
        }
    }

    //protected void trReport_Sorting(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
    //{
    //    //Default sort order Descending

    //    if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
    //    {
    //        GridSortExpression sortExpr = new GridSortExpression();
    //        sortExpr.FieldName = e.SortExpression;
    //        sortExpr.SortOrder = GridSortOrder.Ascending;

    //        e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
    //    }

    //}

    protected override void OnPreRender(EventArgs e) {
        base.OnPreRender(e);
        this.RadTreeListRealItems.DataBind();
        this.RadTreeListCloneItems.DataBind();
    }
   
</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:Label runat="server" ID="lblMessage" Text="Please select article type:"></asp:Label>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_OnClick"></asp:Button>&nbsp;&nbsp;<br />
            <asp:RadioButtonList ID="rbtLstOptions" runat="server"
                RepeatDirection="Vertical" RepeatLayout="Table">
                <asp:ListItem Text="Landing Page Resource Article Page" Value="{A4D4F492-6782-44B5-89AC-C513065152C5}"></asp:ListItem>
                <asp:ListItem Text="Basic Article Page" Value="{67D1EA88-ECA0-4B4F-BA2A-AD2E83ED4FF0}"></asp:ListItem>
                <asp:ListItem Text="Action Style List Page" Value="{DE610867-BB6C-4E3F-957C-3A340BF028F5}"></asp:ListItem>
                <asp:ListItem Text="Audio Article Page" Value="{F1826F3A-1F30-4D63-8EDC-A0093E185D6A}"></asp:ListItem>
                <asp:ListItem Text="Checklist Article Page" Value="{8EF35E23-A052-4458-A799-4736C7D1F8C5}"></asp:ListItem>
                <asp:ListItem Text="Deep Dive Article Page" Value="{155A3DF6-CE18-4332-A872-7FE10693AECA}"></asp:ListItem>
                <asp:ListItem Text="Infographic Article Page" Value="{BE7A3EE2-B9EE-4ACA-8C61-7EAF22B9E341}"></asp:ListItem>
                <asp:ListItem Text="Simple Expert Article" Value="{30244F7E-3B61-4DB1-B101-622CAE7936D8}"></asp:ListItem>
                <asp:ListItem Text="Slideshow Article Page" Value="{11511214-ECAD-46D7-9370-878299E45BEA}"></asp:ListItem>
                <asp:ListItem Text="Text Only Tips Article Page" Value="{2B01CB7C-78DE-46B8-B1B9-66263F58D343}"></asp:ListItem>
                <asp:ListItem Text="Video Article Page" Value="{D84F2F6F-7B29-49B6-B940-5546CDBBE21B}"></asp:ListItem>
                <asp:ListItem Text="Glossary Page" Value="{CE1AAFB1-90B3-44DF-8F09-38C9B3ACA9C1}"></asp:ListItem>
                <asp:ListItem Text="Toolkit Article Page" Value="{8A8EE8DC-7953-433A-B3B1-79E19B76A9A9}"></asp:ListItem>
                <asp:ListItem Text="Knowledge Quiz Question Article Page" Value="{28A9E7F1-9265-4F10-B288-19A254E0F64D}"></asp:ListItem>
                <asp:ListItem Text="Assessment Quiz Article" Value="{6AC5B76A-6EC6-4561-868C-9A0EBC3190D3}"></asp:ListItem>
            </asp:RadioButtonList>

            <br />
            <asp:Literal ID="ltItemsCount" runat="server"></asp:Literal>
        </div>

        <br />

        <div>
            <telerik:radajaxpanel runat="server" id="RadAjaxPanel1">
                <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />

                <h2 id="realH2Tag" runat="server" visible="false">Real Items Are:</h2>
                <br />
                <telerik:RadGrid ID="RadTreeListRealItems" runat="server" AllowSorting="True">
                    <mastertableview autogeneratecolumns="false" isfilteritemexpanded="false" editmode="InPlace"
                        allowfilteringbycolumn="True" showfooter="True" tablelayout="Auto" allowautomaticdeletes="true" allowautomaticinserts="true" allowautomaticupdates="true">
                        <Columns>
                            <telerik:GridEditCommandColumn UniqueName="EditCommandColumn1" Visible="false"></telerik:GridEditCommandColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="Serial No">
                                <ItemTemplate>
                                    <%#Container.DataSetIndex+1%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridDateTimeColumn DataField="DisplayName" HeaderText="Display Name" SortExpression="DisplayName"
                                UniqueName="DisplayName1" PickerType="None" DataFormatString="{0:d}">
                            </telerik:GridDateTimeColumn>
                            <telerik:GridBoundColumn DataField="Fields['Page Title']" HeaderText="Page Title" SortExpression="Fields['Page Title']"
                                UniqueName="PageTitle1" ReadOnly="true" Visible="true" AllowSorting="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ID" HeaderText="Item IDs" SortExpression="ID" Visible="true" AllowSorting="false"
                                UniqueName="ItemID1" ReadOnly="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridDateTimeColumn DataField="Paths.ContentPath" HeaderText="Path" SortExpression="Paths.ContentPath"
                                UniqueName="Path1" PickerType="None" DataFormatString="{0:D}">
                            </telerik:GridDateTimeColumn>
                        </Columns>
                    </mastertableview>
                </telerik:RadGrid>

                <br />
                <br />

                <h2 id="cloneH2Tag" runat="server" visible="false">Clone Items Are:</h2>
                <br />
                <telerik:RadGrid ID="RadTreeListCloneItems" runat="server" AllowSorting="True">
                    <mastertableview autogeneratecolumns="false" isfilteritemexpanded="false" editmode="InPlace"
                        allowfilteringbycolumn="True" showfooter="True" tablelayout="Auto" allowautomaticdeletes="true" allowautomaticinserts="true" allowautomaticupdates="true">
                        <Columns>
                            <telerik:GridEditCommandColumn UniqueName="EditCommandColumn2" Visible="false"></telerik:GridEditCommandColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn2" HeaderText="Serial No">
                                <ItemTemplate>
                                    <%#Container.DataSetIndex+1%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridDateTimeColumn DataField="DisplayName" HeaderText="Display Name" SortExpression="DisplayName"
                                UniqueName="DisplayName2" PickerType="None" DataFormatString="{0:d}">
                            </telerik:GridDateTimeColumn>
                            <telerik:GridBoundColumn DataField="Fields['Page Title']" HeaderText="Page Title" SortExpression="Fields['Page Title']"
                                UniqueName="PageTitle2" ReadOnly="true" Visible="true" AllowSorting="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ID" HeaderText="Item IDs" SortExpression="ID" Visible="true" AllowSorting="false"
                                UniqueName="ItemID2" ReadOnly="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridDateTimeColumn DataField="Paths.ContentPath" HeaderText="Path" SortExpression="Paths.ContentPath"
                                UniqueName="Path2" PickerType="None" DataFormatString="{0:D}">
                            </telerik:GridDateTimeColumn>
                        </Columns>
                    </mastertableview>
                </telerik:RadGrid>

            </telerik:radajaxpanel>
        </div>
    </form>
</body>
</html>
