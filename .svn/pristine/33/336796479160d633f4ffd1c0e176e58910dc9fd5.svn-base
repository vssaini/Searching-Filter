using System;
using System.Text;
using System.Web.UI;
using Telerik.Web.UI;

public partial class Default : Page
{
    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        // Initialize properties
        Utility.OrderID = "OrderID";
        Utility.CustomerID = "Orders.CustomerID";
        Utility.CompanyName = "CompanyName";
        Utility.OrderDate = "OrderDate";
        Utility.RequiredDate = "RequiredDate";
        Utility.ShippedDate = "ShippedDate";
        Utility.ShipCountry = "ShipCountry";
        Utility.EmployeeID = cboEmployee.SelectedValue;

        Session["IsFilter"] = true;
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        cboEmployee.SelectedValue = "1";

        if (Convert.ToBoolean(Session["IsFilter"]))
            PopulateGrid();

        Utility.AddFilters(sqlFilterData, filters.ChkYear, filters.ChkCountry, btnApplyFilter);

        if (filters.ChkCountry.Items.Count <= 0) return;

        var function = "showAll(" + filters.ChkCountry.Items.Count + ");";

        filters.LblShow.Text = "Show All " + filters.ChkCountry.Items.Count;
        filters.LblShow.Attributes.Add("onclick", function);
        filters.LblShow.Attributes.Add("href", "#");

    }

    #endregion

    #region Other controls events

    protected void cboEmployee_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        PopulateGrid();
    }

    protected void btnSearch_Clicked(object sender, EventArgs e)
    {
        PopulateGrid();
    }

    protected void btnApplyFilter_Clicked(object sender, EventArgs e)
    {
        PopulateGridByFilter();
    }

    protected void gridData_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        Session["IsFilter"] = true;
    }

    protected void gridData_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
    {
        Session["IsFilter"] = true;
    }

    #endregion

    #region Top CheckBoxes

    protected void btnOrderID_CheckChanged(object sender, EventArgs e)
    {
        Utility.OrderID = btnOrderID.Checked.Equals(true) ? btnOrderID.Text : null;
    }

    protected void btnCustomerID_CheckChanged(object sender, EventArgs e)
    {
        Utility.CustomerID = btnCustomerID.Checked.Equals(true) ? "Orders." + btnCustomerID.Text : null;
    }

    protected void btnCompanyName_CheckChanged(object sender, EventArgs e)
    {
        Utility.CompanyName = btnCompanyName.Checked.Equals(true) ? btnCompanyName.Text : null;
    }

    protected void btnOrderDate_CheckChanged(object sender, EventArgs e)
    {
        Utility.OrderDate = btnOrderDate.Checked.Equals(true) ? btnOrderDate.Text : null;
    }

    protected void btnRequiredDate_CheckChanged(object sender, EventArgs e)
    {
        Utility.RequiredDate = btnRequiredDate.Checked.Equals(true) ? btnRequiredDate.Text : null;
    }

    protected void btnShippedDate_CheckChanged(object sender, EventArgs e)
    {
        Utility.ShippedDate = btnShippedDate.Checked.Equals(true) ? btnShippedDate.Text : null;
    }

    protected void btnShipCountry_CheckChanged(object sender, EventArgs e)
    {
        Utility.ShipCountry = btnShipCountry.Checked.Equals(true) ? btnShipCountry.Text : null;
    }

    #endregion

    #region Helper Methods

    /// <summary>
    /// Fill GridView based on columns selected by user.
    /// </summary>
    public void PopulateGrid()
    {
        gridData.MasterTableView.GetColumn("OrderID").Display = Utility.OrderID != null;
        gridData.MasterTableView.GetColumn("CustomerID").Display = Utility.CustomerID != null;
        gridData.MasterTableView.GetColumn("CompanyName").Display = Utility.CompanyName != null;
        gridData.MasterTableView.GetColumn("OrderDate").Display = Utility.OrderDate != null;
        gridData.MasterTableView.GetColumn("RequiredDate").Display = Utility.RequiredDate != null;
        gridData.MasterTableView.GetColumn("ShippedDate").Display = Utility.ShippedDate != null;
        gridData.MasterTableView.GetColumn("ShipCountry").Display = Utility.ShipCountry != null;

        var query = Utility.QueryBuilder(cboEmployee.SelectedValue);
        
        if (query != null)
        {
            sqlData.SelectCommand = query;

            var filterSql = "SELECT OrderID,Orders.CustomerID,CompanyName,OrderDate,RequiredDate,ShippedDate,ShipCountry FROM Orders INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID WHERE EmployeeID=" + cboEmployee.SelectedValue;
            sqlFilterData.SelectCommand = filterSql;
            sqlFilterData.DataBind();
        }

      

        gridData.DataBind();
        Session["IsFilter"] = false;

    }

    /// <summary>
    /// Build query by adding filters selected by user.
    /// </summary>
    public void PopulateGridByFilter()
    {
        string sqlFinal;
        var query = Utility.QueryBuilder(cboEmployee.SelectedValue);
        if (query == null) return;
        var queryBuilder = new StringBuilder(query);

        // Apply country filter
        var sqlForCountry = Utility.FilterQuery(filters.ChkCountry, " AND ShipCountry IN ('", queryBuilder);

        if (sqlForCountry != null)
        {
            var yearQBuilder = new StringBuilder(sqlForCountry);
            var sqlForYear = Utility.FilterQuery(filters.ChkYear, " AND YEAR(OrderDate) IN ('", yearQBuilder);

            sqlFinal = sqlForYear ?? sqlForCountry;
        }
        else
        {
            sqlFinal = Utility.FilterQuery(filters.ChkYear, " AND YEAR(OrderDate) IN ('", queryBuilder);
        }


        // Bind data to Grid
        sqlData.SelectCommand = sqlFinal;
        gridData.DataBind();

        // For using in PageLoad Complete
        Session["IsFilter"] = false;
    }

    #endregion


}