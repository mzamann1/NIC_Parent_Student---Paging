using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NIC_Parent_Student
{
    public partial class AddGuardian : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page prev_Page = (Page)Context.Handler;
                hf2.Value = ((HiddenField)prev_Page.FindControl("hf1")).Value;
            }
        }

        private bool isValid()
        {
            if ((!string.IsNullOrWhiteSpace(txtGuardianFName.Text) && txtGuardianFName.Text.All(char.IsLetter)) && (!string.IsNullOrWhiteSpace(txtGuardianLname.Text) && txtGuardianLname.Text.All(char.IsLetter)) && (!string.IsNullOrWhiteSpace(txtGuardianAddress.Text) && txtGuardianAddress.Text.All(char.IsLetterOrDigit)))
            {
                return true;
            }
            else
            { return false; }
        }

       

        protected void adGuardianBtn_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                using (SampleDataContext dbcontext = new SampleDataContext())
                {

                    guardian newg = new guardian()
                    {
                        g_Fname = txtGuardianFName.Text,
                        g_Lname = txtGuardianLname.Text,
                        g_Address = txtGuardianAddress.Text,
                        std_id = Convert.ToInt32(hf2.Value)
                    };
                    dbcontext.guardians.InsertOnSubmit(newg);
                    dbcontext.SubmitChanges();
                    Response.Redirect("~/Guardian.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Cannot Process Request due to validation error')</script>");
            }

        }
    }
}