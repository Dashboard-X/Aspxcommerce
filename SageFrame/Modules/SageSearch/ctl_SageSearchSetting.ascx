﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_SageSearchSetting.ascx.cs" Inherits="Modules_SageSearch_ctl_SageSearchSetting" %>
<h2 class="cssClassFormHeading">
        <asp:Label ID="lblSearchSettingManagement" runat="server" Text="Search Setting Management"></asp:Label></h2>
<div class="cssClassFormWrapper">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="20%">
                <asp:Label ID="lblSearchButtonType" runat="server" Text="Button Type:" CssClass="cssClassFormLabel"
                    ToolTip="Choose one of them Button, or Image or Link"></asp:Label>
            </td>
            <td class="cssClassRadioBtnWrapper">
                <asp:RadioButtonList ID="rdblSearchButtonType" ToolTip="Choose one of them Button, or Image or Link" RepeatLayout="Table" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                    CssClass="cssClassRadioBtn">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSearchButtonText" runat="server" Text="Button Text:" CssClass="cssClassFormLabel"
                    ToolTip="like Search/Go/..."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSearchButtonText" ToolTip="like Search/Go/..." runat="server" CssClass="cssClassNormalTextBox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSearchButtonImage" runat="server" Text="Button Image:" CssClass="cssClassFormLabel"
                    ToolTip="like imbSearch.png <br/> Before Setting the image name you must be sure that the image is in your template of adjusted size. This image will play role when you set the button type is Image"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSearchButtonImage" ToolTip="like imbSearch.png <br/> Before Setting the image name you must be sure that the image is in your template of adjusted size. This image will play role when you set the button type is Image" runat="server" CssClass="cssClassNormalTextBox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSearchResultPageName" runat="server" Text="Result Page Name:" CssClass="cssClassFormLabel"
                    ToolTip="Note You shure that this page is exists on your portal and Serch result module is placed on the page."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSearchResultPageName" ToolTip="Note You shure that this page is exists on your portal and Serch result module is placed on the page." runat="server" CssClass="cssClassNormalTextBox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSearchResultPerPage" runat="server" Text="Result Per Page:" CssClass="cssClassFormLabel"
                    ToolTip="10/20/30 etc"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSearchResultPerPage" ToolTip="10/20/30 etc" runat="server" CssClass="cssClassNormalTextBox" MaxLength="5"></asp:TextBox>
            </td>
        </tr>        
        <tr>
            <td>
                <asp:Label ID="lblMaxSearchChracterAllowedWithSpace" runat="server" Text="Number of Character allowed:" CssClass="cssClassFormLabel"
                    ToolTip="Like 50/100/200 or its upto you the default value is 200<br/>Note Count include with space."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMaxSearchChracterAllowedWithSpace" ToolTip="Like 50/100/200 or its upto you the default value is 200<br/>Note Count include with space." runat="server" CssClass="cssClassNormalTextBox" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>
<div class="cssClassButtonWrapper cssClassRadioBtnButton">
    <asp:ImageButton ID="imbSave" runat="server" onclick="imbSave_Click" />
    <asp:Label ID="lblSave" runat="server" Text="Save" AssociatedControlID="imbSave"
        Style="cursor: pointer;"></asp:Label>
        
        <asp:ImageButton ID="imbCancel" runat="server" onclick="imbCancel_Click"  />
    <asp:Label ID="lblCancel" runat="server" Text="Cancel" AssociatedControlID="imbCancel"
        Style="cursor: pointer;"></asp:Label>
</div>