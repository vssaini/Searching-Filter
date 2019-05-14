/****************************** Module Utility ******************************\
* Module Name:  Utility.cs
* Project:      SearchingFilter
* Date:         14 Nov, 2013
* Copyright (c) Vikram Singh Saini
* 
* Provide function for building query, building filter query and showing filters.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Provide function for building query, building filter query and showing filters. 
/// Also provide public properties for storing other details.
/// </summary>
public static class Utility
{
    // Properties
    public static string OrderID { get; set; }
    public static string CustomerID { get; set; }
    public static string CompanyName { get; set; }
    public static string OrderDate { get; set; }
    public static string RequiredDate { get; set; }
    public static string ShippedDate { get; set; }
    public static string ShipCountry { get; set; }
    public static string EmployeeID { get; set; }

    private static StringBuilder _queryBuilder;

    /// <summary>
    /// Generate query based on columns selected by user.
    /// </summary>
    /// <returns>Return complete Initial query.</returns>
    public static string QueryBuilder(string empId)
    {
        string query = null;
        _queryBuilder = new StringBuilder("SELECT ");

        if (OrderID != null)
            _queryBuilder.Append(OrderID).Append(",");

        if (CustomerID != null)
            _queryBuilder.Append(CustomerID).Append(",");

        if (CompanyName != null)
            _queryBuilder.Append(CompanyName).Append(",");

        if (OrderDate != null)
            _queryBuilder.Append(OrderDate).Append(",");

        if (RequiredDate != null)
            _queryBuilder.Append(RequiredDate).Append(",");

        if (ShippedDate != null)
            _queryBuilder.Append(ShippedDate).Append(",");

        if (ShipCountry != null)
            _queryBuilder.Append(ShipCountry).Append(",");

        // Remove trailing commas
        var selectQuery = _queryBuilder.ToString().TrimEnd(',');
        var queryColumns = selectQuery.Trim().Substring(6);

        // Ensure if there is chances for query building
        if (queryColumns.Length > 7)
        {
            _queryBuilder = null;
            _queryBuilder = new StringBuilder(selectQuery);
            _queryBuilder.Append(" FROM Orders INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID WHERE EmployeeID=").
                Append(empId);

            query = _queryBuilder.ToString();
        }

        return query;
    }

    /// <summary>
    /// Generate query based on filtes selected by user.
    /// </summary>
    /// <param name="checkBoxList">CheckBoxList control from which selected items will be retrieved.</param>
    /// <param name="queryPart">Initial query to which filter query part would be appened.</param>
    /// <param name="builder">StringBuilder which would be used for building query.</param>
    /// <returns></returns>
    public static string FilterQuery(ListControl checkBoxList, string queryPart, StringBuilder builder)
    {
        string query = null;
        var chkList = new ArrayList();

        foreach (var item in checkBoxList.Items.Cast<ListItem>().Where(item => item.Selected))
        {
            chkList.Add(item.Value);
        }

        // Build final query
        if (chkList.Capacity > 0)
        {
            builder.Append(queryPart).Append(chkList[0]).Append("',");

            for (var i = 1; i < chkList.Count; i++)
            {
                builder.Append("'").Append(chkList[i]).Append("',");
            }

            var sql = builder.ToString().TrimEnd(',');
            query = sql + ")";
        }

        return query;
    }

    /// <summary>
    /// Show filters based on employee selected by user.
    /// </summary>
    public static void AddFilters(SqlDataSource sqlFilterData, CheckBoxList chkYear, CheckBoxList chkCountry, RadButton radButton)
    {
        // Get DataTable from SqlDataSource for performance
        var args = new DataSourceSelectArguments();
        var dataView = (DataView)sqlFilterData.Select(args);

        if (dataView == null) return;
        var dt = dataView.ToTable();

        #region Biding years to checkbox

        var years = from row in dt.AsEnumerable()
                    orderby (DateTime)row["OrderDate"] descending
                    group row by new
                    {
                        date = row.Field<DateTime>("OrderDate").Year
                    }
                        into grp
                        select new
                        {
                            File = grp.Key.date,
                            count = grp.Count()
                        };

        chkYear.DataSource = years;
        chkYear.DataTextField = "File";
        chkYear.DataValueField = "count";
        chkYear.DataBind();

        #endregion

        #region Binding countries to checkbox

        var countries = from row in dt.AsEnumerable()
                        orderby (string)row["ShipCountry"]
                        group row by new
                        {
                            country = row.Field<string>("ShipCountry")
                        }
                            into grp
                            select new
                            {
                                File = grp.Key.country,
                                count = grp.Count()
                            };

        chkCountry.DataSource = countries;
        chkCountry.DataTextField = "File";
        chkCountry.DataValueField = "count";
        chkCountry.DataBind();

        #endregion
    }
}