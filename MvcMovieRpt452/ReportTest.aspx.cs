using Microsoft.Reporting.WebForms;
using MvcMovieEntity6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcMovieRpt452.Views
{
    public partial class ReportTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Customer> customers = null;
                northwindEntities dc = new northwindEntities();
                customers = dc.Customers.OrderBy(a => a.ContactName).ToList();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdl");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", customers);
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}