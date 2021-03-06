﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InventoryDetails.ascx.cs"
    Inherits="Modules_AspxCommerce_AspxAdminDashBoard_InventoryDetails" %>

<script type="text/javascript">
    //<![CDATA[
    var lowStock = '<%=LowStockQuantity%>';
    //]]>
</script>

<div id="divInventoryDetails">
    <div class="cssClassCommonBox Curve">
        <div class="cssClassHeader">
            <h2>
                <asp:Label ID="lblInventoryDetail" runat="server" Text="Inventory "></asp:Label>
            </h2>
        </div>
        <div class="cssClassFormWrapper">
            <div class="classTableWrapper">
                <table cellspacing="0" cellpadding="0" width="100%" border="0" id="tblInventoryDetail">
                    <tr>
                        <td class="cssClassTableLeftCol">
                            <asp:Label ID="lblTotalItem" runat="server" CssClass="cssClassLabel" Text="Total Items: "></asp:Label><label
                                id="lblItemtotal"></label>
                        </td>
                        <td>
                            <asp:Label ID="lblActiveItem" runat="server" CssClass="cssClassLabel" Text="Active Items: "></asp:Label><label
                                id="lblAvtive"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssClassTableLeftCol">
                            <asp:Label ID="lblHiddenItem" runat="server" CssClass="cssClassLabel" Text="Hidden Items: "></asp:Label><label
                                id="lblHidden"></label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssClassTableLeftCol">
                            <asp:Label ID="lblDownloadableItems" runat="server" CssClass="cssClassLabel" Text="Downloadable Items: "></asp:Label><label
                                id="lblDownloadable"></label>
                        </td>
                        <td>
                            <asp:Label ID="lblSpecialItems" runat="server" CssClass="cssClassLabel" Text="Special Items: "></asp:Label><label
                                id="lblSpecial"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cssClassTableLeftCol">
                            <asp:Label ID="lblLowStockItem" runat="server" CssClass="cssClassLabel" Text="LowStock Items: "></asp:Label><label
                                id="lblLowstock"></label>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>
