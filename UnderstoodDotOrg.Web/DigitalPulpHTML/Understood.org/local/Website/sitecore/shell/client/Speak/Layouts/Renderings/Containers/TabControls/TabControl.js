﻿define(["sitecore"], function (_sc) {
  var model = _sc.Definitions.Models.BlockModel.extend({
    initialize: function () {
      var self = this;
      this._super();
      this.set("staticTabs", []);
      this.set("dynamicTabs", []);
      this.set("selectedTab", "");
      this.set("isProgressive", false);
      this.set("tabs", "", {
        computed: true,
        read: function () {
          var dynamics = $.map(this.dynamicTabs(), function (t) {
            return t.id;
          });
          return this.staticTabs().concat(dynamics);
        }
      });

      this.viewModel.tabs.subscribe(function () {

        var allTabs = self.viewModel.tabs();
        if ($.inArray(self.viewModel.selectedTab(), allTabs) < 0) {
          self.viewModel.selectedTab(allTabs[0]);
        }
      });

      this.set("selectedTabIndex", "", {
        computed: true,
        read: function () {
          var selectedTab = this.selectedTab();
          if (!selectedTab) {
            return -1;
          }
          return $.inArray(selectedTab, this.tabs());
        },

        write: function (index) {
          if (index < 0 || index >= this.tabs().length) {
            throw "Tab index should be within a valid range";
          }
          this.selectedTab(this.tabs()[index]);
        }
      });
    }
  });

  var view = _sc.Definitions.Views.BlockView.extend({
    initialize: function () {
      var tabIds, i, selectedTabId, view = this;
      this._super();

      tabIds = $.map(this.$el.find("> ul li[data-tab-id]"), function (tab) {
          var $tab = $(tab);

          $tab.click(function (event) {
              view.onTabClicked.call(view, event);
          });
          return $tab.attr("data-tab-id");
      });

      for (i = 0; i < tabIds.length; i += 1) {
          this.model.viewModel.staticTabs.push(tabIds[i]);
      }

      selectedTabId = this.$el.attr("data-selected-tab");
      if (!selectedTabId && tabIds.length) {
        selectedTabId = tabIds[0];
      }

      this.model.set("selectedTab", selectedTabId);
      this.$el.find("> ul li[data-tab-id='" + selectedTabId + "']").nextUntil('li.sc-tabcontrol-header a').first().addClass("active-first-sibling");
    },
    onTabClicked: function (e) {
      e.preventDefault();

      var tabId = $(e.currentTarget).attr("data-tab-id");
      this.$el.find(".active-first-sibling").removeClass("active-first-sibling");
      $(e.currentTarget).nextUntil('li.sc-tabcontrol-header a').first().addClass("active-first-sibling");
        
      this.model.set("selectedTab", tabId);
    },
    addDynamicTab: function (tab) {
      var tabId = tab.id;
      
      this.model.viewModel.dynamicTabs.push(tab);
    } 
    

  });

 _sc.Factories.createComponent("TabControl", model, view, ".sc-tabcontrol");
});