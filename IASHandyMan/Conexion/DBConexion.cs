using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace IASHandyMan.Conexion
{
    public class DBConexion
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["MySQLConnectionString"].ToString();
        }

        public static string GetLogin(int user, string pwd)
        {
            try
            {

                string response = string.Empty;
                MySqlCommand cmd = new MySqlCommand("`employeeLogin`", new MySqlConnection(GetConnectionString()));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@EmpId", user));
                cmd.Parameters.Add(new MySqlParameter("@pass", pwd));
                cmd.Parameters.Add("@resp", MySqlDbType.Bit);
                cmd.Parameters["@resp"].Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return cmd.Parameters["@resp"].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}