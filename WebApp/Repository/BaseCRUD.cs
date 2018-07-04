using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Repository
{
    public class BaseCRUD<T> : IBaseCRUD<T> where T:class
    {
        public SqlConnection _SqlConnection;
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
        public SqlCommand _SqlCommand = new SqlCommand();

        public BaseCRUD()
        {
            _SqlConnection = new SqlConnection(con);
            _SqlCommand.Connection = _SqlConnection;
        }
        void IBaseCRUD<T>.Add(T _T,string SP)
        {
            _SqlConnection.Open();
            _SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _SqlCommand.CommandText = SP;
            List<T> _List = new List<T>();
            _List.Add(_T);           
            var property = _T.GetType().GetProperties();
            foreach (var prop in property)
            {

                var attribute = Attribute.GetCustomAttribute(prop, typeof(KeyAttribute)) as KeyAttribute;
                if (attribute == null)
                {
                    (this as IBaseCRUD<T>).AddParameter(prop.Name, Convert.ToString(prop.GetValue(_T, null)));
                }
            }
            _SqlCommand.ExecuteNonQuery();
            _SqlConnection.Close();
        }

        void IBaseCRUD<T>.AddParameter(string param,string value)
        {
            SqlParameter _SqlParameter = new SqlParameter();
            _SqlParameter.ParameterName = param;
            _SqlParameter.Value = value;
            _SqlCommand.Parameters.Add(_SqlParameter);
        }

        void IBaseCRUD<T>.Delete(T _T,string SP)
        {
            _SqlConnection.Open();
            _SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _SqlCommand.CommandText = SP;
            _SqlCommand.ExecuteNonQuery();
            _SqlConnection.Close();
        }

        DataSet IBaseCRUD<T>.Get()
        {
            _SqlConnection.Open();
            _SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _SqlCommand.CommandText = "";
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            _SqlDataAdapter.SelectCommand = _SqlCommand;
            DataSet _DataSet = new DataSet();
            _SqlDataAdapter.Fill(_DataSet);
            _SqlConnection.Close();
            return _DataSet;
           
        }

        public void Update(T _T, string SP)
        {
            _SqlConnection.Open();
            _SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _SqlCommand.CommandText = SP;
            _SqlCommand.ExecuteNonQuery();
            _SqlConnection.Close();
        }

        
    }
}