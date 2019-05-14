<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register Src="~/UserControls/Filters.ascx" TagName="filters" TagPrefix="site" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SearchingFilter - Filter your searches further</title>
    <link href="Style/Main.css" rel="stylesheet" type="text/css" />
    <link href="Style/favicon.ico" rel="Shortcut Icon" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <telerik:RadScriptReference Path="Style/jquery-1.10.2.min.js" />
            <telerik:RadScriptReference Path="Style/script.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadFormDecorator ID="FormDecorator1" runat="server" DecoratedControls="CheckBoxes" />
    <telerik:RadAjaxManager ID="RAM1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cboEmployee">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridData" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="filters" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridData" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="btnApplyFilter" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnApplyFilter">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridData" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gridData">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridData" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Office2010Silver" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="false" Skin="Office2010Silver">
        <TargetControls>
            <telerik:TargetControl ControlID="btnSearch" Skin="Office2007" />
            <telerik:TargetControl ControlID="btnApplyFilter" Skin="Office2007" />
            <telerik:TargetControl ControlID="gridData" Skin="Office2010Silver" />
        </TargetControls>
    </telerik:RadSkinManager>
    <div id="container">
        <h2>
            <span class="h2">Searching</span> Filter</h2>
        <div class="leftCol" align="center">
            <div style="padding-top: 90px;">
                <div class="infoPanel">
                    Filters</div>
                <site:filters ID="filters" runat="server" />
                <div style="padding-top: 10px;">
                    <telerik:RadButton ID="btnApplyFilter" runat="server" Text="Apply Filter" ButtonType="StandardButton"
                        AutoPostBack="True" OnClick="btnApplyFilter_Clicked" />
                </div>
            </div>
        </div>
        <div class="rightCol">
            <div>
                <span>Select Employee: </span>
                <telerik:RadComboBox ID="cboEmployee" runat="server" AutoPostBack="true" Width="140px"
                    Skin="Vista" OnSelectedIndexChanged="cboEmployee_SelectedIndexChanged" DataSourceID="SqlEmpData"
                    DataTextField="EmployeeID" DataValueField="EmployeeID" />
            </div>
            <div style="padding-top: 20px;">
                <table>
                    <tr>
                        <td>
                            <telerik:RadAjaxPanel ID="radAjaxPanel" runat="server">
                                <span>Select columns: </span>
                                <telerik:RadButton ID="btnOrderID" runat="server" ToggleType="CheckBox" Checked="True"
                                    Text="OrderID" ButtonType="ToggleButton" AutoPostBack="true" OnCheckedChanged="btnOrderID_CheckChanged" />
                                <telerik:RadButton ID="btnCustomerID" runat="server" ToggleType="CheckBox" Checked="True"
                                    Text="CustomerID" ButtonType="ToggleButton" AutoPostBack="true" OnCheckedChanged="btnCustomerID_CheckChanged" />
                                <telerik:RadButton ID="btnCompanyName" runat="server" ToggleType="CheckBox" Checked="True"
                                    Text="CompanyName" ButtonType="ToggleButton" AutoPostBack="true" OnCheckedChanged="btnCompanyName_CheckChanged" />
                                <telerik:RadButton ID="btnOrderDate" runat="server" ToggleType="CheckBox" Checked="True"
                                    Text="OrderDate" ButtonType="ToggleButton" AutoPostBack="true" OnCheckedChanged="btnOrderDate_CheckChanged" />
                                <telerik:RadButton ID="btnRequiredDate" runat="server" ToggleType="CheckBox" Checked="True"
                                    Text="RequiredDate" ButtonType="ToggleButton" AutoPostBack="true" OnCheckedChanged="btnRequiredDate_CheckChanged" />
                                <telerik:RadButton ID="btnShippedDate" runat="server" ToggleType="CheckBox" Checked="True"
                                    Text="ShippedDate" ButtonType="ToggleButton" AutoPostBack="true" OnCheckedChanged="btnShippedDate_CheckChanged" />
                                <telerik:RadButton ID="btnShipCountry" runat="server" ToggleType="CheckBox" Checked="True"
                                    Text="ShipCountry" ButtonType="ToggleButton" AutoPostBack="true" OnCheckedChanged="btnShipCountry_CheckChanged" />
                            </telerik:RadAjaxPanel>
                        </td>
                        <td>
                            <telerik:RadButton ID="btnSearch" runat="server" ButtonType="StandardButton" AutoPostBack="true"
                                Text="GO" OnClick="btnSearch_Clicked" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="padding-top: 20px;">
                <telerik:RadGrid ID="gridData" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False" AllowSorting="true" HorizontalAlign="Center" DataSourceID="sqlData"
                    OnPageIndexChanged="gridData_PageIndexChanged" OnPageSizeChanged="gridData_PageSizeChanged">
                    <MasterTableView DataSourceID="sqlData" CommandItemDisplay="None" ItemStyle-Wrap="true"
                        Width="100%">
                        <NoRecordsTemplate>
                            <div style="padding-left: 5px; padding-top: 10px;">
                                <i>* No records found matching with filters selected</i>
                            </div>
                        </NoRecordsTemplate>
                        <Columns>
                            <telerik:GridBoundColumn DataField="OrderID" HeaderText="Order ID" UniqueName="OrderID" />
                            <telerik:GridBoundColumn DataField="CustomerID" HeaderText="Customer ID" UniqueName="CustomerID" />
                            <telerik:GridBoundColumn DataField="CompanyName" HeaderText="Company Name" UniqueName="CompanyName" />
                            <telerik:GridDateTimeColumn DataField="OrderDate" HeaderText="Order Date" UniqueName="OrderDate"
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <telerik:GridDateTimeColumn DataField="RequiredDate" HeaderText="Required Date" UniqueName="RequiredDate"
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <telerik:GridDateTimeColumn DataField="ShippedDate" HeaderText="Shipped Date" UniqueName="ShippedDate"
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <telerik:GridBoundColumn DataField="ShipCountry" HeaderText="Ship Country" UniqueName="ShipCountry" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <asp:SqlDataSource ID="sqlData" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" />
                <asp:SqlDataSource ID="sqlFilterData" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" />
                <asp:SqlDataSource ID="SqlEmpData" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                    SelectCommand="SELECT EmployeeID FROM Employees ORDER BY EmployeeID" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
