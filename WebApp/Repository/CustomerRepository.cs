using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository
{
    public class CustomerRepository: BaseCRUD<Customer>,ICustomerRepository<Customer>
    {
        public CustomerRepository():base()
        {

        }
    }
}