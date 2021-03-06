﻿(function($) {
    $.createSageMenu = function(p) {
        p = $.extend
        ({
            PortalID: 1,
            UserModuleID: 1,
            UserName: 'user',
            PageName: 'Home',
            ContainerClientID: 'divNav1',
            CultureCode: 'en-US',
            baseURL: 'Services/Services.aspx/'
        }, p);

        var SageMenu = {
            config: {
                isPostBack: false,
                async: true,
                cache: false,
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                data: { data: '' },
                dataType: 'json',
                baseURL: p.baseURL,
                method: "",
                url: "",
                ajaxCallMode: 0,
                arr: [],
                arrPages: [],
                UserModuleID: p.UserModuleID,
                PortalID: p.PortalID,
                UserName: p.UserName,
                PageName: p.PageName,
                ContainerClientID: p.ContainerClientID,
                CultureCode: p.CultureCode

            },
            init: function() {
                this.LoadUserModuleSettings();
                this.BindEvents();
            },
            HighlightSelected: function() {
                var menu = $(SageMenu.config.ContainerClientID + " ul li");
                $.each(menu, function(index, item) {
                    var hreflink = $(this).find("a").attr("href");
                    if (location.href.toLowerCase().indexOf(hreflink.toLowerCase()) > -1) {
                        $(this).addClass('cssClassActive');
                    }
                });
            },
            ajaxSuccess: function(data) {
                switch (SageMenu.config.ajaxCallMode) {
                    case 0:
                    case 1:
                        SageMenu.BuildMenu(data);
                        break;
                    case 2:
                        SageMenu.BindPages(data);
                        break;
                    case 3:
                        SageMenu.BuildFooterMenu(data);
                        break;
                    case 4:
                        SageMenu.BuildSideMenu(data);
                        break;
                }
            },
            BindEvents: function() {
                $(SageMenu.config.ContainerClientID + " ul li").live("click", function() {
                    $(SageMenu.config.ContainerClientID + " ul li").removeClass("cssClassActive");
                    $(this).addClass("cssClassActive");
                });
            },
            ajaxFailure: function() {
            },
            ajaxCall: function(config) {
                $.ajax({
                    type: SageMenu.config.type,
                    contentType: SageMenu.config.contentType,
                    cache: SageMenu.config.cache,
                    url: SageMenu.config.url,
                    data: SageMenu.config.data,
                    dataType: SageMenu.config.dataType,
                    success: SageMenu.ajaxSuccess,
                    error: SageMenu.ajaxFailure
                });

            },
            GetPages: function() {
                this.config.method = "GetMenuFront";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: parseInt(SageMenu.config.PortalID), UserName: SageMenu.config.UserName, CultureCode: p.CultureCode });
                this.config.ajaxCallMode = 2;
                this.ajaxCall(this.config);
            },
            LoadUserModuleSettings: function() {
                this.config.method = "GetMenuSettings";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: SageMenu.config.PortalID, UserModuleID: SageMenu.config.UserModuleID });
                this.config.ajaxCallMode = 1;
                this.ajaxCall(this.config);
            },
            BuildMenu: function(data) {
                var setting = data.d;
                switch (parseInt(setting.MenuType)) {
                    case 0:
                        SageMenu.LoadTopAdminMenu();
                        break;
                    case 1:
                        SageMenu.GetPages();
                        break;
                    case 2:
                        SageMenu.LoadSideMenu();
                        break;
                    case 3:
                        SageMenu.LoadFooterMenu();
                        break;
                }
            },
            LoadTopAdminMenu: function() { },
            BuildTopAdminMenu: function(data) { },
            LoadSideMenu: function() {
                this.config.method = "GetSideMenu";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: parseInt(SageMenu.config.PortalID), UserName: SageMenu.config.UserName, PageName: SageMenu.config.PageName, CultureCode: p.CultureCode });
                this.config.ajaxCallMode = 4;
                this.ajaxCall(this.config);
            },
            LoadFooterMenu: function() {
                this.config.method = "GetFooterMenu";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: parseInt(SageMenu.config.PortalID), UserName: SageMenu.config.UserName, CultureCode: p.CultureCode });
                this.config.ajaxCallMode = 3;
                this.ajaxCall(this.config);
            },
            BuildFooterMenu: function(data) {
                var pages = data.d;
                var PageID = "";
                var parentID = "";
                var PageLevel = 0;
                var itemPath = '';
                var html = "";
                html += '<ul class="sagemenu-footer">';
                $.each(pages, function(index, item) {
                    PageID = item.PageID;
                    parentID = item.ParentID;
                    categoryLevel = item.Level;
                    if (item.Level == 0) {
                        var PageLink = PagePath + item.TabPath + ".aspx";
                        html += '<li class="menu-header"><a href=' + PageLink + '>';
                        html += item.PageName;
                        html += "</a>";
                        if (item.ChildCount > 0) {
                            html += "<ul>";
                            itemPath += item.PageName;
                            html += SageMenu.BindFooterChildren(pages, PageID);
                            html += "</ul>";
                        }
                        html += "</li>";
                    }
                    itemPath = '';
                });
                html += '</ul>';
                $(SageMenu.config.ContainerClientID).addClass("cssClassFooterMenu");
                $(SageMenu.config.ContainerClientID).append(html);
            },
            BindFooterChildren: function(response, PageID) {
                var strListmaker = '';
                var childNodes = '';
                var path = '';
                var itemPath = "";
                $.each(response, function(index, item) {
                    if (item.Level > 0) {
                        if (item.ParentID == PageID) {
                            itemPath += item.PageName;
                            var PageLink = PagePath + item.TabPath + ".aspx";
                            strListmaker += '<li class="child"><a  href=' + PageLink + '>' + item.PageName + '</a>';
                            childNodes = SageMenu.BindChildCategory(response, item.PageID);
                            if (childNodes != '') {
                                strListmaker += "<ul>" + childNodes + "</ul>";
                            }
                            strListmaker += "</li>";
                        }
                    }
                });
                return strListmaker;
            },
            BindPages: function(data) {
                var pages = data.d;
                var PageID = "";
                var parentID = "";
                var PageLevel = 0;
                var itemPath = "";
                var html = "";
                html += '<div class="cssClassNavigation">';
                html += '<ul class="sf-menu">';
                $.each(pages, function(index, item) {
                    PageID = item.PageID;
                    parentID = item.ParentID;
                    categoryLevel = item.Level;

                    if (item.Level == 0) {
                        var PageLink = PagePath + item.TabPath + ".aspx";
                        if (item.ChildCount > 0) {
                            html += '<li class="cssClassParent"><a href=' + PageLink + '>';
                        }
                        else {
                            html += '<li><a href=' + PageLink + '>';
                        }
                        html += item.PageName;
                        html += "</a>";

                        if (item.ChildCount > 0) {
                            html += "<ul>";
                            itemPath += item.PageName;
                            html += SageMenu.BindChildCategory(pages, PageID);
                            html += "</ul>";
                        }
                        html += "</li>";
                    }
                    itemPath = '';
                });
                html += '</ul>';
                html += '</div>';
                $(SageMenu.config.ContainerClientID).addClass("cssClassNavigationWrapper");
                $(SageMenu.config.ContainerClientID).append(html);
                $(".cssClassNavigation >ul>li:last").addClass("cssClassLastMenu");
                SageMenu.InitializeSuperfish();
                SageMenu.HighlightSelected();
            },
            BindChildCategory: function(response, PageID) {
                var strListmaker = '';
                var childNodes = '';
                var path = '';
                var itemPath = "";
                itemPath += "";
                $.each(response, function(index, item) {
                    if (item.Level > 0) {
                        if (item.ParentID == PageID) {
                            itemPath += item.PageName;
                            var PageLink = PagePath + item.TabPath + ".aspx";
                            strListmaker += '<li><a  href=' + PageLink + '>' + item.PageName + '</a>';
                            childNodes = SageMenu.BindChildCategory(response, item.PageID);
                            itemPath = itemPath.replace(itemPath.lastIndexOf(item.AttributeValue), '');
                            if (childNodes != '') {
                                strListmaker += "<ul>" + childNodes + "</ul>";
                            }
                            strListmaker += "</li>";
                        }
                    }
                });
                return strListmaker;
            },
            InitializeSuperfish: function() {
                jQuery('ul.sf-menu').superfish();
            },
            BuildSideMenu: function(data) {
                var pages = data.d;
                var PageID = "";
                var parentID = "";
                var categoryLevel = 0;
                var itemPath = "";
                var html = "";
                html += '<ul class="sagemenu-side">';
                $.each(pages, function(index, item) {
                    PageID = item.PageID;
                    parentID = item.ParentID;
                    categoryLevel = item.Level;
                    var PageLink = PagePath + item.TabPath + ".aspx";
                    if (item.Level == 0) {
                        html += '<li><a href=' + PageLink + '>';
                        if (item.ChildCount > 0) {
                            html += item.PageName;
                        }
                        else {
                            html += item.PageName;
                        }
                        html += "</a>";

                        if (item.ChildCount > 0) {
                            html += "<ul>";
                            itemPath += item.PageName;
                            html += SageMenu.BindSideMenuChildren(pages, PageID);
                            html += "</ul>";
                        }
                        html += "</li>";
                    }
                    itemPath = '';
                });
                html += '</ul>';
                $(SageMenu.config.ContainerClientID).addClass("cssClassSideMenu");
                $(SageMenu.config.ContainerClientID).append(html);
                SageMenu.HighlightSelected();
            },
            BindSideMenuChildren: function(response, PageID) {
                var strListmaker = '';
                var childNodes = '';
                var path = '';
                var itemPath = '';
                itemPath += "";
                $.each(response, function(index, item) {
                    if (item.Level > 0) {
                        if (item.ParentID == PageID) {
                            itemPath += item.PageName;
                            var PageLink = PagePath + item.TabPath + ".aspx";
                            strListmaker += '<li><a  href=' + PageLink + '>' + item.PageName + '</a>';
                            childNodes = SageMenu.BindChildCategory(response, item.PageID);
                            itemPath = itemPath.replace(itemPath.lastIndexOf(item.AttributeValue), '');
                            if (childNodes != '') {
                                strListmaker += "<ul>" + childNodes + "</ul>";
                            }
                            strListmaker += "</li>";
                        }
                    }
                });
                return strListmaker;
            }

        };
        SageMenu.init();
    };

    $.fn.SageMenuBuilder = function(p) {
        $.createSageMenu(p);
    };
})(jQuery);

   
   