using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NIC_Parent_Student
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            storeData();
        }

        private void GetData()
        {
            using (SampleDataContext dbcontext = new SampleDataContext())
            {
                GridView1.DataSource = dbcontext.guardians.ToList();
                GridView1.DataBind();
            }
        }

        private void storeData()
        {
            student std = new student
            {
                std_Fname = "Muhammad",
                std_class = 16,
                std_Lname = "Zaman"
            };

            List<student> lst = new List<student>();
            for (int i = 0; i < 999; i++)
            {
                lst.Add(std);
            }
            using (SampleDataContext dbcontext = new SampleDataContext())
            {
                dbcontext.students.InsertAllOnSubmit(lst);
                dbcontext.SubmitChanges();
            }


        }
    


        protected void Unnamed_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32((sender as LinkButton).CommandArgument);

            using (SampleDataContext dbContext = new SampleDataContext())
            {
                GridView2.DataSource = dbContext.students.FirstOrDefault(x => x.std_id == id);
                GridView2.DataBind();
            }
        }
    }
}