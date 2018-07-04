using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using Repository;
using System.Collections;


namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly Type IEnumerableType = typeof(IEnumerable);
        private readonly Type StringType = typeof(String);

        protected void Page_Load(object sender, EventArgs e)
        {            
            try
            {
                Customer entity = new Customer();
                entity.Cname = "testname";
                entity.Caddress = "testaddress";
                using (DbCon dbcon = new DbCon())
                {
                    dbcon._iCustomerRepository.Add(entity, "sp_insertcustomer");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}