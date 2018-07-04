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
                //SQL Create Table
                //create table customer(id int identity(1, 1) primary key, Cname varchar(max), Caddress varchar(max))
                //SQL Create Store procedure
                //create proc[dbo].[sp_insertcustomer]
                //@Cname varchar(max), @Caddress varchar(max)
                //as
                //begin
                //insert into customer values(@Cname, @Caddress)
                //end
                
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