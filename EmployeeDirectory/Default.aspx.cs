using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeDirectory
{
    public partial class viewdetail : System.Web.UI.Page
    {
        #region Declarations 
        EmployeeDirectory ed = new EmployeeDirectory();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid myguid = Guid.Empty;
            myguid = new Guid(Request.QueryString["guid"]);
            if (myguid != null)
            {
                GetData(myguid);
            }
            else
            {
                phNoViewDetail.Visible = true;
                phViewDetail.Visible = false;
            }
        }
        protected void GetData(Guid myguid)
        {
            phViewDetail.Visible = true;
            ed.GetEmployeesViewGuid(myguid);
            lblFName.Text = ed.fname.ToString();
            lblLName.Text = ed.lname.ToString();
            lblAddress.Text = ed.address.ToString();
            lblAge.Text = ed.age.ToString();
            lblInterests.Text = ed.interests.ToString();
            lblPicture.Text = ed.picture.ToString();
        }
    }

    public partial class _Default : System.Web.UI.Page
    {
        EmployeeDirectory ed = new EmployeeDirectory();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object s, EventArgs e)
        {
            if (IsValid)
            {
                List<EmployeeDirectory> employees = ed.GetEmployeesView(txtName.Text);
                TogglePHVisibility();
                rpEmployeeSearchView.DataSource = employees;
                rpEmployeeSearchView.DataBind();
            }

        }
        protected void TogglePHVisibility()
        {
            phEmployeeSearch.Visible = true;
            phNoEmployeeFound.Visible = false;
        }
    }
}