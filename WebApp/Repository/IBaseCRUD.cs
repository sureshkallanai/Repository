using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Repository
{
    public interface IBaseCRUD<T>
    {
        void Add(T _T, string SP);
        void Update(T _T, string SP);
        void Delete(T _T, string SP);
        void AddParameter(string param, string value);
        DataSet Get();
    }
}