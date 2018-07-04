using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository
{
    public interface ICustomerRepository<T> : IBaseCRUD<T>
    {
    }
}