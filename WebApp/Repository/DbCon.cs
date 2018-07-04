using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository
{
    public class DbCon: BaseDbcon
    {
        private ICustomerRepository<Customer> _ICustomerRepository;

        public ICustomerRepository<Customer> _iCustomerRepository
        {
            get
            {
                if (_ICustomerRepository == null)
                {
                    _ICustomerRepository = new CustomerRepository();
                }
                return _ICustomerRepository;
            }
        }
    }
}