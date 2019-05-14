﻿using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SearchingFilter.UserControls
{
    public partial class Filters : UserControl
    {
        /// <summary>
        /// Provide access to CheckBoxList for Country.
        /// </summary>
        public CheckBoxList ChkCountry { get; set; }

        /// <summary>
        /// Provide access to CheckBoxList for Year.
        /// </summary>
        public CheckBoxList ChkYear { get; set; }

        /// <summary>
        /// Provide access to Label.
        /// </summary>
        public LinkButton LblShow { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkCountry = chkCountries;
            ChkYear = chkYears;
            LblShow = lblShow;
        }

        protected void chkCountries_DataBound(object sender, EventArgs e)
        {
            foreach (ListItem item in chkCountries.Items)
            {
                var builder = new StringBuilder(item.Text);
                var itemValue = item.Text;
                item.Text = builder.Append(" (").Append(item.Value).Append(")").ToString();
                item.Value = itemValue;
            }
        }

        protected void chkYears_DataBound(object sender, EventArgs e)
        {
            foreach (ListItem item in chkYears.Items)
            {
                var builder = new StringBuilder(item.Text);
                var itemValue = item.Text;
                item.Text = builder.Append(" (").Append(item.Value).Append(")").ToString();
                item.Value = itemValue;
            }
        }
    }
}