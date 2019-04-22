using System.Web;
using System.Linq;
using System.Linq.Expressions;
using System;
using Newtonsoft.Json;

namespace NIC_Parent_Student
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            
            string page_in = context.Request.QueryString["page"];
            if (page_in==null)
            {
                page_in = "1";
            }
            if (isValidQuery(page_in, 20))
            {
                using (SampleDataContext db = new SampleDataContext())
                {
                    int p = Convert.ToInt32(page_in);
                    var students = db.spindexWork(p, 20);
                    context.Response.Write(JsonConvert.SerializeObject(students));

                }
            }
            else
            {
                context.Response.Write(JsonConvert.SerializeObject("null"));
            }
          

        }


        private bool isValidQuery(string req,double div)
        {
            using (SampleDataContext db = new SampleDataContext())

            {
                int rows = db.students.Count();
                double max_page = rows / div;
               
                int.TryParse(req, out int result);
                if (result>=1 && result<=max_page)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}