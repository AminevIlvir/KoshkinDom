using System;
using System.Windows;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace Books
{
	/// <summary>
	/// Description of BDClass.
	/// </summary>
	public class BDClass
	{
		public BDClass()
		{
		}
		static string path="C:\\";
    	const string db = "CatHome";
	    const string serv = "localhost\\SQLEXPRESS";
	    const string login = "test";
	    const string pass = "test";
        const string conn1 = "Data Source=" + serv + ";user=" + login + ";password=" + pass + ";";
		public static ArrayList QueryGet(string query, int timeout=0)
	    {
	        SqlConnection SqlConnection1 = new SqlConnection(conn1);
	        try
	        {
	            SqlConnection1.Open();
	            ArrayList ar = new ArrayList();
	            if (SqlConnection1.State == ConnectionState.Open)
	            {
	                SqlConnection1.ChangeDatabase(db);
	                SqlCommand scommand = new SqlCommand(query, SqlConnection1);
	                if (timeout > 0) scommand.CommandTimeout = timeout;
	                SqlDataReader sreader = scommand.ExecuteReader();
	                if (sreader.HasRows)
	                {
	                    while (sreader.Read())
	                    {
	                        ArrayList ar1 = new ArrayList();
                            for (int i = 0; i < sreader.FieldCount; i++)
	                        {
	                            ar1.Add(sreader.GetValue(i).ToString());
	                        }
                            ar.Add(ar1);
	                    }
	                }
	                sreader.Close();
	            }
	            SqlConnection1.Close();
	            return ar;
	        }
	        catch (Exception ex)
	        {
	            if (SqlConnection1.State == ConnectionState.Open) SqlConnection1.Close();
	            MessageBox.Show(ex.Message);
	        	System.IO.File.AppendAllText(path + "\\BD_Errors.txt", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\t" + ex.Message + "\r\n");
	            System.IO.File.AppendAllText(path + "\\BD_Errors.txt", "Conn: " +conn1+ "\r\nZapr: " + query + "\r\n");
	            return new ArrayList();
	        }
	        
		}
		
		public static bool QueryNA(string query, int timeout=0)
	    {
	        SqlConnection SqlConnection1 = new SqlConnection(conn1);
	        try
	        {
	            SqlConnection1.Open();
	            if (SqlConnection1.State == ConnectionState.Open)
	            {
	                SqlConnection1.ChangeDatabase(db);
	                SqlCommand scommand = new SqlCommand(query, SqlConnection1);
	                if (timeout > 0) scommand.CommandTimeout = timeout;
	                scommand.ExecuteNonQuery();
	            }
	            SqlConnection1.Close();
	            return true;
	        }
	        catch (Exception ex)
	        {
	        	if (SqlConnection1.State == ConnectionState.Open) SqlConnection1.Close();
	            MessageBox.Show(ex.Message);
	        	System.IO.File.AppendAllText(path + "\\BD_Errors.txt", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\t" + ex.Message + "\r\n");
	            System.IO.File.AppendAllText(path + "\\BD_Errors.txt", "Conn: " +conn1+ "\r\nZapr: " + query + "\r\n");
	            return false;
	        }
	        
		}
		
	}
}
