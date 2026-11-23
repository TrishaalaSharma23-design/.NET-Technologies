using System;
using System.Web.UI.WebControls;

namespace PlacementDashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private readonly PlacementDAL dal = new PlacementDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshDashboard();
            }
        }

        private void RefreshDashboard()
        {
            // Bind FormView (KPI Cards)
            fvSummary.DataSource = dal.GetDashboardSummary();
            fvSummary.DataBind();

            // Bind Repeater (Company Summary)
            rptCompanies.DataSource = dal.GetCompanySummary();
            rptCompanies.DataBind();

            // Bind GridView (Main Table)
            BindGrid();
        }

        private void BindGrid()
        {
            gvPlacements.DataSource = dal.GetPlacements(ddlBranch.SelectedValue, ddlStatus.SelectedValue);
            gvPlacements.DataBind();
        }

        // Filter DropDownLists Changed
        protected void FilterChanged(object sender, EventArgs e)
        {
            gvPlacements.PageIndex = 0;
            BindGrid();
        }

        // GridView Pagination
        protected void gvPlacements_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPlacements.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        // GridView Select Row -> Populate DetailsView
        protected void gvPlacements_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(gvPlacements.SelectedDataKey.Value);
            dvPlacement.ChangeMode(DetailsViewMode.ReadOnly);
            dvPlacement.DataSource = dal.GetPlacementById(selectedId);
            dvPlacement.DataBind();
        }

        // GridView Inline Edit
        protected void gvPlacements_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPlacements.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvPlacements_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPlacements.EditIndex = -1;
            BindGrid();
        }

        protected void gvPlacements_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvPlacements.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvPlacements.Rows[e.RowIndex];

            string studentName = ((TextBox)row.Cells[0].Controls[0]).Text;
            string company = ((TextBox)row.Cells[2].Controls[0]).Text;
            string role = ((TextBox)row.Cells[3].Controls[0]).Text;
            decimal lpa = Convert.ToDecimal(((TextBox)row.Cells[4].Controls[0]).Text);
            string status = ((DropDownList)row.FindControl("ddlEditStatus")).SelectedValue;

            dal.UpdatePlacement(id, studentName, company, role, lpa, status);

            gvPlacements.EditIndex = -1;
            RefreshDashboard();
        }

        // GridView Delete
        protected void gvPlacements_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvPlacements.DataKeys[e.RowIndex].Value);
            dal.DeletePlacement(id);
            RefreshDashboard();
        }

        // Switch DetailsView to Insert Mode
        protected void btnNewRecord_Click(object sender, EventArgs e)
        {
            dvPlacement.ChangeMode(DetailsViewMode.Insert);
        }

        protected void dvPlacement_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dvPlacement.ChangeMode(e.NewMode);
            if (e.NewMode == DetailsViewMode.ReadOnly)
            {
                dvPlacement.DataSource = null;
                dvPlacement.DataBind();
            }
        }

        // Insert New Record via DetailsView
        protected void dvPlacement_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            string name = e.Values["StudentName"]?.ToString();
            string enrollment = e.Values["EnrollmentNo"]?.ToString();
            string branch = e.Values["Branch"]?.ToString();
            string company = e.Values["CompanyName"]?.ToString();
            string role = e.Values["Role"]?.ToString();
            decimal lpa = Convert.ToDecimal(e.Values["PackageLPA"]);
            string status = e.Values["Status"]?.ToString();
            DateTime driveDate = Convert.ToDateTime(e.Values["DriveDate"]);

            dal.InsertPlacement(name, enrollment, branch, company, role, lpa, status, driveDate);

            dvPlacement.ChangeMode(DetailsViewMode.ReadOnly);
            RefreshDashboard();
        }
    }
}
