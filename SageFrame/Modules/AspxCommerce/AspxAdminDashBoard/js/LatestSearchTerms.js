﻿$(function() {
    var storeId = AspxCommerce.utils.GetStoreID();
    var portalId = AspxCommerce.utils.GetPortalID();
    var userName = AspxCommerce.utils.GetUserName();
    var cultureName = AspxCommerce.utils.GetCultureName();
    var latestSearchTermCount = 5;
    var latestSearchTerms = {
        config: {
            isPostBack: false,
            async: false,
            cache: false,
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            data: '{}',
            dataType: 'json',
            baseURL: AspxCommerce.utils.GetAspxServicePath() + "AspxCommerceWebService.asmx/",
            method: "",
            url: "",
            ajaxCallMode: 0
        },
        ajaxCall: function(config) {
            $.ajax({
                type: latestSearchTerms.config.type,
                contentType: latestSearchTerms.config.contentType,
                cache: latestSearchTerms.config.cache,
                async: latestSearchTerms.config.async,
                url: latestSearchTerms.config.url,
                data: latestSearchTerms.config.data,
                dataType: latestSearchTerms.config.dataType,
                success: latestSearchTerms.ajaxSuccess,
                error: latestSearchTerms.ajaxFailure
            });
        },
        GetLatestSearchTerms: function() {
            this.config.url = this.config.baseURL + "GetSearchStatistics";
            this.config.data = JSON2.stringify({ count: latestSearchTermCount, commandName: commandName, storeID: storeId, portalID: portalId, cultureName: cultureName });
            this.config.ajaxCallMode = 1;
            this.ajaxCall(this.config);
        },
        ajaxSuccess: function(msg) {
            switch (latestSearchTerms.config.ajaxCallMode) {
                case 0:
                    break;
                case 1:
                    if (msg.d.length > 0) {
                        var bodyElements = '';
                        var headELements = '';
                        headELements += '<table class="classTableWrapper"  width="100%" border="0" cellspacing="0" cellpadding="0"><tbody>';
                        headELements += '<tr class="cssClassHeading"><td class="cssClassNormalHeading">SearchTerm</td>';
                        headELements += '<td class="cssClassNormalHeading">No Of Use</td>';
                        headELements += '</tr></tbody></table>';

                        $("#divLatestSearchTerms").html(headELements);
                        $.each(msg.d, function(index, value) {
                            bodyElements += '<tr><td><label class="cssClassLabel">' + value.SearchTerm + '</label></td>';
                            bodyElements += '<td><label class="cssClassLabel">' + value.Count + '</label>';
                            bodyElements += '</tr>';
                        });
                        $("#divLatestSearchTerms").find('table>tbody').append(bodyElements);

                        $(".classTableWrapper > tbody tr:even").addClass("cssClassAlternativeEven");
                        $(".classTableWrapper > tbody tr:odd").addClass("cssClassAlternativeOdd");
                    }
                    else {
                        $("#divLatestSearchTerms").html("<span class=\"cssClassNotFound\">Nothing is searched recently!!</span>");
                    }

                    break;
            }
        },
        ajaxFailure: function(msg) {
            switch (latestSearchTerms.config.ajaxCallMode) {
                case 0:
                    break;
                case 1:
                    csscody.error('<h1>Error Message</h1><p>Failed to load Latest Ordered Items.</p>');
                    break;
            }
        },
        init: function(config) {
            latestSearchTerms.GetLatestSearchTerms();
        }
    }
    latestSearchTerms.init();
});