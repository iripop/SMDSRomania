using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Controllers;
using Test.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Http;


namespace Test
{
    public class UserMng
    {
        public HttpResponseMessage LogIn(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SQLConnectionString"]))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT staff_id FROM Staff WHERE staff_username='" + username + "' AND staff_password='" + password + "'", conn))
                {
                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        HttpResponseMessage response = new HttpResponseMessage();

                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                response.Content = new StringContent(reader.GetInt32(0).ToString());
                                return response;
                            }
                        }

                        response.Content = new StringContent("Wrong username or password.");
                        return response;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public HttpResponseMessage LoginAdmin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SQLConnectionString"]))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT admin_id FROM AdminUsers WHERE admin_username='" + username + "' AND admin_password='" + password + "'", conn))
                {
                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        HttpResponseMessage response = new HttpResponseMessage();

                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                response.Content = new StringContent(reader.GetInt32(0).ToString());
                                return response;
                            }
                        }

                        response.Content = new StringContent("Wrong username or password.");
                        return response;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

    }
}