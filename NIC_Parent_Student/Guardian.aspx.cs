using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NIC_Parent_Student
{
    public partial class Guardian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
                btn_Update.Enabled = false;
            }

            
        }
        private void Clear()
        {
            txtFname.Text = txtLname.Text = txtAddress.Text = txtStd_id.Text =hf1.Value= "";
            GridView2.DataSource = null;
            btn_Update.Enabled = false;
        }

        private void GetData()
        {
            using (SampleDataContext context = new SampleDataContext())
            {
                GridView1.DataSource = context.guardians.ToList();
                GridView1.DataBind();
            }
        }

        

       
        protected void MoreStudents_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32((sender as LinkButton).CommandArgument);
            using (SampleDataContext con = new SampleDataContext())
            {

                GridView2.DataSource= con.students.Where(x => x.std_id == i).ToList();
                GridView2.DataBind(); 
            }

        }
        private bool isValid()
        {
            if ((!string.IsNullOrWhiteSpace(txtFname.Text) && txtFname.Text.All(char.IsLetter)) && (!string.IsNullOrWhiteSpace(txtLname.Text) && txtLname.Text.All(char.IsLetter)) && (!string.IsNullOrWhiteSpace(txtAddress.Text) && txtAddress.Text.All(char.IsLetterOrDigit)) && (!string.IsNullOrWhiteSpace(txtStd_id.Text) && txtStd_id.Text.All(char.IsDigit)))
            {
                return true;
            }
            else return false;
        }


        protected void updGuardian_Click(object sender, EventArgs e)
        {
           
                
              hf1.Value=  (sender as LinkButton).CommandArgument;
            int i = Convert.ToInt32(hf1.Value);
            btn_Update.Enabled = true;

            using (SampleDataContext context = new SampleDataContext())
            {
                guardian g = context.guardians.Where(x => x.id == i).Single();
                if (g != null)
                {
                    txtFname.Text = g.g_Fname;
                    txtLname.Text = g.g_Lname;
                   txtAddress.Text = g.g_Address;
                    txtStd_id.Text = g.std_id.ToString();

                }
            }


        }

        protected void dltGuardian_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32((sender as LinkButton).CommandArgument);
            using (SampleDataContext context = new SampleDataContext())
            {
                guardian g= context.guardians.Where(x => x.id == i).SingleOrDefault();
                g.std_id = null;
                context.SubmitChanges();
                context.guardians.DeleteOnSubmit(g);
                context.SubmitChanges();
                GridView2.DataSource = null;
            }
            GetData();
            Clear();
        }

        
        private void Update(int id)
        {
            using (SampleDataContext context = new SampleDataContext())
            {
                guardian g = context.guardians.Where(x => x.id == id).SingleOrDefault();
                int s_id = Convert.ToInt32(txtStd_id.Text);

                if (context.students.Where(x => x.std_id == s_id).Single() != null)
                {
                    g.g_Fname = txtFname.Text;
                    g.g_Lname = txtLname.Text;
                    g.g_Address = txtAddress.Text;
                    g.std_id = s_id;

                    
                    context.SubmitChanges();
                    GetData();
                    Clear();
                    
                }
                else
                {
                    Response.Write("<script>alert('Student ID Not Found!!')</script>");
                }
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hf1.Value);
            if (isValid())
            {
                Update(id);
            }
             else
               {
                    Response.Write("<script>alert('Cannot Process Request, Due To Validation Error!!')</script>");
               }
            }
        }
    }
