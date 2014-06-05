/**
 * Definition for the at search tool conditions.
 */

 (function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.searchTool();
    new U.searchToolFindButton();

    $(window).resize(function(){
      U.searchToolFindButton();
    });
  });

  U.searchTool = function(){
    var self = this;

    // style checkboxes / mobile select
    // initiate uniform before selecting containers generated by uniform.
    $('#search-by-tool-tabs input[type=text], #search-by-tool-tabs select').uniform({'selectedClass':'selected'});

    // cache selectors
    var searchByToolTabs = $('#search-by-tool-tabs');
    var atBrowseByTechnology = $('#at-browse-by-technology');
    var atBrowseByApp = $('#at-browse-by-app');
    var uniformAtBrowseByApp = $('#uniform-at-browse-by-app');
    var atBrowseByGames = $('#at-browse-by-games');
    var uniformAtBrowseByGames = $('#uniform-at-browse-by-games');

    // initiate easytabs for the 'browse by', 'search by' buttons
    searchByToolTabs.easytabs();

    self.atSearchSelect = $('#browse-by select');

    // make select boxes go 100%
    self.atSearchSelect.siblings('span').css('width', '100%').parent('.selector').css('width', '100%');

    //NOTE - uniform will auto hide elements with inline display:none;

    searchByToolTabs.on('change', function() {
      if( atBrowseByTechnology.val() == "at-browse-by-app" ){
        atBrowseByGames.hide();
        uniformAtBrowseByGames.hide();
        atBrowseByApp.show();
        uniformAtBrowseByApp.show();
      }else if( atBrowseByTechnology.val() == "at-browse-by-games" ){
        atBrowseByApp.hide();
        uniformAtBrowseByApp.hide();
        atBrowseByGames.show();
        uniformAtBrowseByGames.show();
      }else{
        atBrowseByApp.hide();
        uniformAtBrowseByApp.hide();
        atBrowseByGames.hide();
        uniformAtBrowseByGames.hide();
      }
    });

    return this;
  };

  U.searchToolFindButton = function(){
    var self = this;

    //cache selectors
    var searchByToolTabsFind = $('#search-by-tool-tabs input[type=submit]');

    // only above 768 viewport or nonresponsive
    if(Modernizr.mq('(min-width: 769px)') || !Modernizr.mq('only all')){
      searchByToolTabsFind.val('Find');
    }else{
      searchByToolTabsFind.val('Go');
    }

    return this;
  }

})(jQuery);
/**
 * Definition for the Assistive Technology Detail Thumb javascript module.
 * U.AtDetailThumb function is called from _what-you-need-to-know-tabs.js
 */

(function($){

  U.AtDetailThumb = function() {
    var self = this;

    //cache slider element
    var sliderElement = jQuery(".screenshot-thumbs-wrapper");

    sliderElement.royalSlider({
      keyboardNavEnabled: false,  // enable keyboard arrows nav
      autoScaleSlider: false,
      autoScaleSliderWidth: 191, // base slider width. slider will autocalculate the ratio based on these values.
      autoHeight: false,
      imageScaleMode: 'none',
      imageAlignCenter: false,
      loop: true,
      controlNavigation: 'none',
      arrowsNav: true,
      arrowsNavAutoHide: false,
      sliderDrag:false,
      autoPlay: {
        delay: 4000,
        enabled: false
      }
    });

    U.carousels.keyboardAccess(sliderElement);

    var screenshotThumbsCarousel = sliderElement.data('royalSlider');

    if(screenshotThumbsCarousel){
      jQuery('.at-detail-thumb-total-slides').html( screenshotThumbsCarousel.numSlides );
      screenshotThumbsCarousel.ev.on('rsAfterSlideChange', function(event) {
        jQuery('.at-detail-thumb-curr-slide').html( 1 + ( screenshotThumbsCarousel.currSlideId ) );
      });
    }

    return this;
  };
})(jQuery);
/**
 * Definition for the rateThisApp javascript module.
 */

(function($){

// Initialize the module on page load.
  $(document).ready(function() {
    new U.rateThisApp();
  });

  U.rateThisApp = function() {
    var self = this;

    $(".rate-this-app input").uniform();
    $(".rate-this-app select").uniform();

    return this;
  };

})(jQuery);
/**
 * Definition for the whatYouNeedToKnow javascript module.
 */

(function($){

  $(document).ready(function(){
    $('#tab-container').easytabs();

    new U.WhatYouNeedToKnow();
  });

  U.WhatYouNeedToKnow = function() {
    var self = this;

    //cache containers
    var whatYouNeedToKnowMobile = $('.screenshot-thumbs.screenshot-thumbs-mobile');
    var whatYouNeedToKnow = $('.screenshot-thumbs.screenshot-thumbs-lg');
    //cache keep reading html
    var whatYouNeedToKnowHTML = whatYouNeedToKnowMobile.html();

    // only above 650 viewport or nonresponsive
    if(Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
      whatYouNeedToKnowMobile.hide().empty();
      whatYouNeedToKnow.empty().html(whatYouNeedToKnowHTML).show();

      new U.AtDetailThumb();
    }else{
      whatYouNeedToKnow.hide().empty();
      whatYouNeedToKnowMobile.empty().html(whatYouNeedToKnowHTML + '<hr>').show();

      new U.AtDetailThumb();
    }

    return this;
  };

})(jQuery);
/**
 * Assistive tech javascript module.
 */

(function($){
  $(document).ready(function() {
    new U.assistiveTech();

    //perform action on resize, but delay the amount of times this is called while resizing.
    var doTheAction;
    $(window).resize(function() {
      clearTimeout(doTheAction);
      doTheAction = setTimeout(U.SeeRating, 100);
    });

  });

  U.assistiveTech = function(){
    var self = this;

    self.init = function(){

      $('.result-image.screenshots-popover img').popover({
        html: true,
        placement: 'bottom',
        trigger: 'click',
        content: function() {
          $this = $(this);
          var $container = $this.parent().parent();
          setTimeout(function() {
            if (!$container.find('.change-slide-buttons').hasClass('lock')) {
              $container.find('.change-slide-buttons').addClass('lock');
              $container.find('.rsArrowRight .rsArrowIcn').click(self.nextSlide);
              $container.find('.rsArrowLeft .rsArrowIcn').click(self.prevSlide);
              $('body').click(function(e) {
                if ($(e.target).hasClass('rsArrowIcn')) {
                  return;
                }
                $this.popover('hide');
                $container.find('.popover').hide();
              });
            }
          }, 250);
          return $(this).parent().find('.popover-container').html();
        }
      });

      // Trigger hover and popover actions for icon-search
      self.iconSearch();
    };

    self.iconSearch = function(){
      self.screenshotsPopoverImg = $('.result-image.screenshots-popover img');

      self.screenshotsPopoverImg.hover(function(){
        $(this).parent('a').siblings('.icon-search').toggleClass('is-hover');
      });

      $('.result-image.screenshots-popover .icon-search').click(function(){
        $(this).prev('a.popover-link').children('img').trigger('click');
      });
    }

    self.changeSlide = function(context, direction) {
      var $pop = $(context).parent().parent().parent();
      var currSlide = 0;
      var numSlides = $pop.find('.slide').length;
      $pop.find('.slide').each(function() {
        if ($(this).hasClass('active')) {
          $(this).removeClass('active');
          return false; // break
        }
        currSlide++;
      });
      var next = (currSlide+direction)%numSlides;
      $pop.find('.count .curr').html(next+1 ? next+1 : 3);
      $pop.find('.slide').eq(next).addClass('active');
    };

    self.nextSlide = function() {
      self.changeSlide(this, 1);
    };

    self.prevSlide = function() {
      self.changeSlide(this, -1);
    };

    self.init();
  };

})(jQuery);
/**
 * Definition for the assistiveToolRelatedArticles javascript module.
 */

(function($){

  // Initialize the module on page load.
  $(document).ready(function() {
    new U.assistiveToolRelatedArticles();
  });

  /**
   * Checks whether the tool-related-articles module exists on the page and inits if it does
   * If the viewport is >= 650 then pop the module into the page-topic container
   *
   * spec/issue : https://digitalpulp.atlassian.net/browse/UN-2575 & UN-2635
   */
  U.assistiveToolRelatedArticles = function() {

    var $module = $('.assistive-tool-related-articles'),
        $html = $('html');
    // if get-better-recommendations module exists on the page
    if(!$module.length) { return; }

    // Run once on window load
    $html.on('equalHeights', repositionElement);
    // Run on resize
    jQuery(window).resize(repositionElement);

    // repositions tool based on size of window
    function repositionElement() {

      var toolRelatedArticles = $('.assistive-tool-related-articles');
      var largePosition = $('.assistive-tool-related-articles-large');
      var smallPosition = $('.assistive-tool-related-articles-small');

      // only above 650 viewport or nonresponsive
      if(Modernizr.mq('(min-width: 650px)') || !Modernizr.mq('only all')){
        largePosition.append(toolRelatedArticles);
        $('.assistive-tool-related-articles-large').show();
      }else{
        smallPosition.append(toolRelatedArticles);
        $('.assistive-tool-related-articles-large').hide();
      }

    }

    $('.search-tool-layout-wrapper .col').equalHeights();

    // On change of Select by Technology drop call equalHeights again
    // Function gets called but equalHeights does not update
    // Same issue happening on resize
    $('#at-browse-by-technology').change(function() {
      $('.search-tool-layout-wrapper .col').css('height', 'auto');
      // Slight delay to fix race-condition bug with equalHeights.
      setTimeout(function() {
        $('.search-tool-layout-wrapper .col').equalHeights();
      }, 25);
    });

  };

})(jQuery);
/**
 * Definition for the resultsSlider javascript module.
 */

(function($){

// Initialize the module on page load.
  $(document).ready(function() {
    new U.resultsSlider();
  });

  U.resultsSlider = function() {
    var self = this;

    /*
     Hover rate this app functionality
     Hovering on element executes class change temporarily based on location of click relative to the element.
     */
    var setClasses = jQuery('.results-slider.blue, .results-slider.purple').attr('class');

    jQuery('.results-slider.blue, .results-slider.purple').mousemove(function(e){
      var a = e;
      var that = this;
      setTimeout(function(){
        var posX = a.pageX - $(that).offset().left,
            percentX = posX / jQuery(that).width(),
            colorClass = 'blue';

        if( jQuery(that).hasClass('purple') ){
          colorClass = 'purple';
        }

        /*
         Checks where in element hover occurs; writes class based on that hover location
         timeout is set to prevent flickering
         */
        if( percentX <= 0.20 ){
          jQuery(that).attr('class', colorClass + ' results-slider ' + colorClass + '-one');
        }else if( percentX <= 0.40 ){
          jQuery(that).attr('class', colorClass + ' results-slider ' + colorClass + '-two');
        }else if( percentX <= 0.60 ){
          jQuery(that).attr('class', colorClass + ' results-slider ' + colorClass + '-three');
        }else if( percentX <= 0.80){
          jQuery(that).attr('class', colorClass + ' results-slider ' + colorClass + '-four');
        }else{
          jQuery(that).attr('class', colorClass + ' results-slider ' + colorClass + '-five');
        }
      }, 100);

    });

    // On mouseout, reverts hovered items back to default classes before hover began
    jQuery('.results-slider.blue, .results-slider.purple').mouseout(function(){
      var that = jQuery(this);
      setTimeout(function(){
        jQuery(that).attr('class', setClasses);
      }, 100);
    });

    /*
     Clickable rate this app functionality
     Clicking on element executes class change based on location of click relative to the element.
     */
    jQuery('.results-slider.blue, .results-slider.purple').click(function(e){
      var posX = e.pageX - $(this).offset().left,
          percentX = posX / jQuery(this).width(),
          colorClass = 'blue';

      if( jQuery(this).hasClass('purple') ){
        colorClass = 'purple';
      }

      /*
       Checks where in element click occurs; writes class based on that click location
       If element already has that item selected, it clears it
       */
      if( percentX <= 0.20 ){
        jQuery(this).attr('class', colorClass + ' results-slider ' + colorClass + '-one');
        jQuery(this).attr('aria-label', '1');
      }else if( percentX <= 0.40 ){
        jQuery(this).attr('class', colorClass + ' results-slider ' + colorClass + '-two');
        jQuery(this).attr('aria-label', '2');
      }else if( percentX <= 0.60 ){
        jQuery(this).attr('class', colorClass + ' results-slider ' + colorClass + '-three');
        jQuery(this).attr('aria-label', '3');
      }else if( percentX <= 0.80){
        jQuery(this).attr('class', colorClass + ' results-slider ' + colorClass + '-four');
        jQuery(this).attr('aria-label', '4');
      }else{
        jQuery(this).attr('class', colorClass + ' results-slider ' + colorClass + '-five');
        jQuery(this).attr('aria-label', '5');
      }

      // Click changes class in a more permanent basis, unlike hover function
      // Also changes other rate this app sliders that should change on the page to match
      setClasses = jQuery(this).attr('class');
      jQuery('body').find('.'+colorClass).each(function(){
        if( jQuery(this).hasClass ('results-slider') ){
          jQuery(this).attr('class', setClasses);
        }
      });

    });

    return this;
  };

})(jQuery);
(function($) {

  $(document).ready(function() {
    var uniformElements = [
      '.selector',
      '.radio'
    ];

    new U.Global.readspeakerUniform(uniformElements);
  });



})(jQuery);








