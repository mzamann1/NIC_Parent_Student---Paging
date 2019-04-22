using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace NIC_Parent_Student
{
    public partial class Student : System.Web.UI.Page
    {
        int current = 0;
            double div = 20.0;
        int rows;


        //public int index
        //{
        //    get { return Request.QueryString["page"] != null ? Convert.ToInt32(Request.QueryString["page"]) : 0; }
        //    set { index = value; }
        //}
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                HideGrid();
                /*current = 0;
                Response.Redirect("~/Student.aspx?page=" + current);
                
                //GetData();
                
                RowWork();
                */


                if (Request.QueryString["page"] == null)
                {
                    Response.Redirect("~/Student.aspx?page=1");
                   
                }
                else
                {
                    int limit = Get();
                    int newint;
                    int.TryParse(Request.QueryString["page"], out newint);

                    if (newint >= 1 && newint <= limit)
                    {
                        GetList(newint, (int)div);
                        if (newint == 1)
                        {
                            btnPrevious.Enabled = false;
                            btnFirst.Enabled = false;
                        }
                        if (newint == limit)
                        {
                            btnLast.Enabled = false;
                            btnNext.Enabled = false;
                        }


                    }
                    else
                        Response.Redirect("~/Student.aspx?page=1");




                }
            }
           
            
            HideGrid();
            

            // GetGuardian();
        }
        int i;
        private void GetGuardian()
        {
            using (SampleDataContext dbContext = new SampleDataContext())
            {
                dbContext.guardians.ToList();
            }
        }

        private void GetData()
        {
            using (SampleDataContext dbContext = new SampleDataContext())
            {
                GridView1.DataSource = dbContext.students.ToList();
                GridView1.DataBind();
            }
        }

       

        private void InsertOrUpdate(int ind)
        {
            
            using (SampleDataContext dbContext = new SampleDataContext())
            {
                if (ind == 0)
                {
                    student newstd = new student()
                    {
                        std_Fname = txtFirstName.Text,
                        std_Lname = txtLastName.Text,
                        std_class = Convert.ToInt32(txtClass.Text)
                    };
                    dbContext.students.InsertOnSubmit(newstd);
                }
                else
                {
                    student student_obj = dbContext.students.Single(x => x.std_id == ind);
                    if (student_obj == null)
                    {
                        Response.Write("<script>alert('Not Found')</script>");
                    }
                    else
                    {
                        student_obj.std_id = ind;
                        student_obj.std_Fname = txtFirstName.Text;
                        student_obj.std_Lname = txtLastName.Text;
                        student_obj.std_class = Convert.ToInt32(txtClass.Text);
                    }
                }

                
                dbContext.SubmitChanges();
                Response.Write("<script>alert('Changes Saved!')</script>");
                Clear();
                GetData();
                RowWork();
            }
        }

        //enables te add guardian button and disables the view guardian button if guardian already exists for the 'i' student and viceversa
        private void RowWork()
        {
            if (GridView1.DataSource!=null)
            {
                using (SampleDataContext context = new SampleDataContext())
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        LinkButton lb_add = (LinkButton)GridView1.Rows[i].FindControl("AddGuardian");
                        int id = Convert.ToInt32(lb_add.CommandArgument);


                        LinkButton lb_view= (LinkButton)GridView1.Rows[i].FindControl("ViewSingleGuardian");
                        guardian g_check = context.guardians.Where(x => x.std_id == id).SingleOrDefault();
                        if (g_check!=null)
                        {
                            lb_add.Enabled = false;
                            lb_view.Enabled = true;

                        }
                        else
                        {
                            lb_add.Enabled = true;
                            lb_view.Enabled = false;
                        }
                    }
                }
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                InsertOrUpdate(0);
            }
            else
            {
                Response.Write("<script>alert('Cannot Update Data Due to Validations Error!!')</script>");
            }
            
        }
        private bool isValid()
        {
            if ((!string.IsNullOrWhiteSpace(txtFirstName.Text) && txtFirstName.Text.All(char.IsLetter)) && (!string.IsNullOrWhiteSpace(txtLastName.Text) && txtLastName.Text.All(char.IsLetter)) && (!string.IsNullOrWhiteSpace(txtClass.Text) && txtClass.Text.All(char.IsDigit)))
            {
                return true;
            }
            else return false;
        }
       
        protected void AddGuardian_Click1(object sender, EventArgs e)
        {
           
            hf1.Value = (sender as LinkButton).CommandArgument;
            Server.Transfer("~/AddGuardian.aspx");
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            btnInsert.Enabled = false;
            HideGrid();
            hf1.Value= (sender as LinkButton).CommandArgument;
            i = Convert.ToInt32(hf1.Value);
            using (SampleDataContext context = new SampleDataContext())
            {
                student std = context.students.SingleOrDefault(x => x.std_id == i);

                if (std!=null)
                {
                    txtFirstName.Text = std.std_Fname;
                    txtLastName.Text = std.std_Lname;
                    txtClass.Text = std.std_class.ToString();
                    
                }
            }

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            HideGrid();
            hf1.Value = (sender as LinkButton).CommandArgument;
            i = Convert.ToInt32(hf1.Value);
            using (SampleDataContext context = new SampleDataContext())
            {

                guardian g = context.guardians.Where(x => x.std_id == i).SingleOrDefault();
                if (g != null)
                {
                    g.std_id = null;

                    context.SubmitChanges();
                }
                student std = context.students.SingleOrDefault(x=>x.std_id==i);
                context.students.DeleteOnSubmit(std);
                context.SubmitChanges();
                Clear();
                GetData();
            }
        }

        private void Clear()
        {
            txtFirstName.Text  = txtLastName.Text=txtClass.Text   = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           int  id = Convert.ToInt32(hf1.Value);
            if (isValid())
            {
                InsertOrUpdate(id);
            }
            else
            {
                Response.Write("<script>alert('Cannot Update Data Due to Validations Error!!')</script>");
            }
        }


        //Hides The Guardian's Grid named as GridView2, which was invoked by  ViewSingleGuardian_Click1
        private void HideGrid()
        {
            GridView2.Visible = false;
        }

        protected void ViewSingleGuardian_Click1(object sender, EventArgs e)
        {
            //getting std_id value from row by using command argument and storing it into the hidden field, checkout the command argument in Student.aspx Line num 38
            hf1.Value = (sender as LinkButton).CommandArgument;
            i = Convert.ToInt32(hf1.Value);
            using (SampleDataContext context = new SampleDataContext())
            {
                GridView2.DataSource = context.guardians.Where(x => x.std_id == i).ToList();
                GridView2.DataBind();
                GridView2.Visible = true;
            }
        }

        /* protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
         {
             GridView1.PageIndex = e.NewPageIndex;
             GetList(e.NewPageIndex,10);
             RowWork();
         }
         */


        int? count = 0;
        protected int GetRowCount()
        {

            using (SampleDataContext db = new SampleDataContext())
            {
                return db.students.Count();
            }
               
            
           
        }

        protected void GetList(int pageindex=1,int incr=10)
        {
            
            using (SampleDataContext db = new SampleDataContext())
            {
                //db.students.Skip(pageindex * incr).Take(incr);
                var data=db.spindexWork(pageindex, incr);
                GridView1.DataSource = data;
                GridView1.DataBind();
               
               

            }
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Student.aspx");
            
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            int current;
           bool res= int.TryParse(Request.QueryString["page"], out current);
            --current;
            Response.Redirect("~/Student.aspx?page="+current);
            


        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int current;
            int.TryParse(Request.QueryString["page"], out current);
            ++current;
            Response.Redirect("~/Student.aspx?page=" + current);



        }

        private int Get()
        {
            
            double res = GetRowCount() / div;
            return (int)Math.Ceiling(res);
         
        }
        protected void btnLast_Click(object sender, EventArgs e)
        {
            int l = Get();
            Response.Redirect("~/Student.aspx?page="+l);
            
            
        }
    }
}