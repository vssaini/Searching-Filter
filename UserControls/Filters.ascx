﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Filters.ascx.cs" Inherits="SearchingFilter.UserControls.Filters" %>
<div>
    <div class="filterCountry">
        <b>Ship Country</b>
    </div>
    <div id="country" class="hide">
        <div id="childcountry">
            <asp:CheckBoxList ID="chkCountries" runat="server" OnDataBound="chkCountries_DataBound" />
        </div>
    </div>
    <asp:LinkButton runat="server" ID="lblShow" Text="Show" CssClass="bold" ClientIDMode="Static" />
</div>
<div>
    <div class="filterYear">
        <b>Year</b>
    </div>
    <div>
        <asp:CheckBoxList ID="chkYears" runat="server" OnDataBound="chkYears_DataBound" />
    </div>
</div>
