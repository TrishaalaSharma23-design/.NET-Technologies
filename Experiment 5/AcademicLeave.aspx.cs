using System; 
 
namespace AcademicLeaveManagement 
{ 
    public partial class AcademicLeave : System.Web.UI.Page 
    { 
        protected void Page_Load(object sender, EventArgs e) 
        { 
            if (!IsPostBack) 
            { 
                // SESSION 
                // Store default student name in Session 
                Session["StudentName"] = "Student"; 
                // Display welcome message 
                lblUser.Text = "Welcome, Student"; 
                // COOKIE 
                // Create Cookie 
                Response.Cookies["StudentCookie"]["Name"] = "Student" ; 
                // Cookie will remain for 7 days 
                Response.Cookies["StudentCookie"].Expires = 
                    DateTime.Now.AddDays(7); 
                // ACADEMIC CALENDAR 
                // Display current date in Academic Calendar 
                calAcademic.SelectedDate = DateTime.Today; 
            } 
        } 
        // APPLY LEAVE BUTTON 
        protected void btnApply_Click(object sender, EventArgs e) 
        { 
            // Get student name 
            string name = txtName.Text.Trim(); 
            // Check whether name is entered 
            if (name == "") 
            { 
                lblMessage.Text = 
                    "<div class='error'>" + 
                    "Please enter student name." + 
                    "</div>"; 
                Return ; 
            } 
            // Check whether date is selected 
            if (calLeave.SelectedDate == DateTime.MinValue) 
            { 
                lblMessage.Text = 
                    "<div class='error'>" + 
                    "Please select a leave date." + 
                   "</div>"; 
                return; 
            } 
            // Get Leave Type 
            string leaveType = ddlLeave.SelectedValue; 
            // Get selected date 
            DateTime leaveDate = calLeave.SelectedDate; 
            // SESSION 
            // Store student name in Session 
            Session["StudentName"] = name; 
            // COOKIE 
            // Store student name in Cookie 
            Response.Cookies["StudentCookie"]["Name"] = name; 
            // Cookie expires after 7 days 
            Response.Cookies["StudentCookie"].Expires = 
                DateTime.Now.AddDays(7); 
            // Update welcome message 
            lblUser.Text = "Welcome, " + name; 
            // DISPLAY SUCCESS MESSAGE 
            lblMessage.Text = 
                "<div class='success'>" + 
                "<b>✓ Leave Applied Successfully!</b><br/>" + 
                "Student: " + name + "<br/>" + 
                "Leave Type: " + leaveType + "<br/>" + 
                "Date: " + 
                leaveDate.ToString("dd/MM/yyyy") + 
                "</div>"; 
        } 
// CLEAR BUTTON 
protected void btnClear_Click(object sender, EventArgs e) 
{ 
// Clear student name 
txtName.Text = ""; 
// Clear message 
lblMessage.Text = ""; 
// Reset leave calendar 
calLeave.SelectedDate = DateTime.MinValue; 
// Reset leave type 
ddlLeave.SelectedIndex = 0; 
// Reset Session 
Session["StudentName"] = "Student"; 
// Display default welcome 
lblUser.Text = "Welcome, Student"; 
} 
} 
} 
