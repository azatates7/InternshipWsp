using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace C_Sharp_MsSQL_Implements
{
    class Program
    {
                #region base  
        static void Main(string[] args)
        {
            Run();
        }
                
        private static void Run()
        {
            try
            {
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = "server=AA7\\SQLEXPRESS;" + "Trusted_Connection=true;" + "database=testdbb; " + "connection timeout=30";
                cnn.Open(); Console.WriteLine("Connection Opened !");

                Console.WriteLine("MySQL version : {0}", cnn.ServerVersion);
                Console.WriteLine("1-Select operation");
                Console.WriteLine("2-Insert Operation");
                Console.WriteLine("3-Delete Operation");
                Console.WriteLine("4-Update Operation");
                Console.WriteLine("5-Transaction Example");
                Console.WriteLine("6-Display In The Table");
                Console.WriteLine("7-Write Number Of Object");
                Console.WriteLine("8-Write In The DataTable");
                Console.WriteLine("9-Write Select Content In File(xml)");
                Console.WriteLine("Choose Your Operation");

                int choose = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("Your Choose : " + choose);
                switchfunction(choose);

                Console.WriteLine("Exit 0?1 \n");
                int exitstatus = Convert.ToInt32(Console.ReadLine());
                if (exitstatus == 0)
                {
                    Console.Clear();
                    Run();
                }
                else
                {
                    Environment.Exit(1);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("An Error Detected : " + ex.Message);
            }
        }

        private static void switchfunction(int choosen)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = "server=AA7\\SQLEXPRESS;" + "Trusted_Connection=true;" + "database=testdbb; " + "connection timeout=30";
            cnn.Open(); 

            SqlCommand command;
            SqlDataReader rdr;
            StringBuilder sb;
            SqlTransaction tr = null;
            SqlParameter param;
            SqlDataAdapter da;
            DataTable dt;
            DataSet ds;

            int key, result, no = 0;
            string name, userkey, query;
            switch (choosen)
            {
                #endregion base

                #region selectquery
                case 1:
                    query = "SELECT * FROM userlist";
                    command = new SqlCommand(query, cnn);
                    rdr = command.ExecuteReader();
                    Console.WriteLine("id" + "\t" + "name" + "\t\t" + "userkey");
                    Console.WriteLine("_____________________________________________");
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr.GetInt32(0) + "\t" + rdr.GetString(1) + "\t" + rdr.GetString(2));
                    }
                    break;
                #endregion selectquery 

                #region insertquery
                case 2:
                    Console.WriteLine("Enter insert id : "); key = Convert.ToInt32(Console.ReadLine());
                    query = "SELECT * FROM userlist WHERE id=" + key;
                    command = new SqlCommand(query, cnn);
                    rdr = command.ExecuteReader();
                    if (!rdr.Read())
                    {
                        Console.WriteLine("This id already exists");
                        switchfunction(2); break;
                    }
                    else
                    {
                        Console.WriteLine("Enter insert name : "); name = Console.ReadLine();
                        Console.WriteLine("Enter insert userkey : "); userkey = Console.ReadLine();
                        query = "INSERT INTO userlist (id, name, userkey) VALUES (@id, @name, @userkey)";
                        using (command = new SqlCommand(query, cnn))
                        {
                            command.Parameters.AddWithValue("@id", key);
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@userkey", userkey);

                            result = command.ExecuteNonQuery();
                            if (result < 0) Console.WriteLine("Error inserting data into Database!");
                        }
                        Console.WriteLine("Inserted Succesfully"); break;
                    } 
                #endregion insertquery 

                #region deletequery
                case 3:
                    Console.WriteLine("Enter delete id : "); key = Convert.ToInt32(Console.ReadLine());
                    query = "SELECT * FROM userlist WHERE id=" + key;
                    command = new SqlCommand(query, cnn);
                    rdr = command.ExecuteReader();
                    if (!rdr.Read())
                    {
                        Console.WriteLine("Not founded this id");
                        switchfunction(3); break;
                    }
                    else
                    {
                        rdr.Close();
                        command = new SqlCommand("DELETE FROM userlist WHERE id=@id", cnn);
                        param = new SqlParameter("@id", key);
                        command.Parameters.Add(param);
                        result = command.ExecuteNonQuery();
                        if (result < 0) Console.WriteLine("Error deleting data from Database!");
                        else Console.WriteLine("Deleted Succesfully"); break;
                    }
                #endregion deletequery

                #region updatequery 
                case 4:
                    Console.WriteLine("Enter update id : "); key = Convert.ToInt32(Console.ReadLine());
                    query = "SELECT * FROM userlist WHERE id=" + key;
                    command = new SqlCommand(query, cnn);
                    rdr = command.ExecuteReader();
                    if (!rdr.Read())
                    {
                        Console.WriteLine("Not founded this id");
                        switchfunction(4); break;
                    }
                    else
                    {
                        Console.WriteLine("id" + "\t" + "name" + "\t\t" + "userkey");
                        Console.WriteLine("_____________________________________________");
                        Console.WriteLine(rdr.GetInt32(0) + "\t" + rdr.GetString(1) + "\t" + rdr.GetString(2) + "\n");

                        rdr.Close();
                        Console.WriteLine("Enter new name : "); String newname = Console.ReadLine();
                        Console.WriteLine("Enter new userkey : "); String newuserkey = Console.ReadLine();
                        query = "update userlist set name ='" + newname + "',userkey='" + newuserkey + "' where id='" + key + "';";
                        command = new SqlCommand(query, cnn);
                        rdr = command.ExecuteReader();
                        Console.WriteLine("Updated Succesfully"); break;
                    }
                #endregion updatequery

                #region transaction
                case 5:
                    try
                    {
                        query = "UPDATE userlist SET id = 44 WHERE id = 1";
                        command = new SqlCommand(query, cnn);
                        command.ExecuteNonQuery(); 
                         
                        query = "UPDATE userlist SET name ='emiliano' WHERE id = 2";
                        command = new SqlCommand(query, cnn);
                        command.ExecuteNonQuery();
                        
                        tr.Commit();
                    }
                    catch (SqlException ex)
                    {
                        try
                        {
                            tr.Rollback();
                        }
                        catch (SqlException ex1)
                        {
                            Console.WriteLine("Error: {0}", ex1.ToString());
                        }
                        Console.WriteLine("Error: {0}", ex.ToString());
                    }
                    break;
                #endregion transaction

                #region displaytable
                case 6:
                    query = "SELECT * FROM userlist"; 
                    command = new SqlCommand(query, cnn); 
                    rdr = command.ExecuteReader();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine(" no| id  |    name     | userkey");
                    Console.WriteLine("-------------------------------------");
                    while ((rdr.Read()))
                    {
                        object a = rdr[0];
                        object b = rdr[1];
                        object c = rdr[2];
                        Console.WriteLine(String.Format("{0,-2} | {1,3} | {2,11} | {3,4}", no, a, b, c));
                        no++;
                    }
                    break;
                #endregion displaytable

                #region writenumberofobject
                case 7:
                    query = "SELECT COUNT(*) FROM userlist";
                    command = new SqlCommand(query, cnn);
                    Console.WriteLine("Number Of Object : " + Convert.ToInt32(command.ExecuteScalar()));
                    break;
                #endregion writenumberofobject

                #region writeindatatable
                case 8:
                    query = "SELECT * FROM userlist";
                    da = new SqlDataAdapter(query, cnn);
                    ds = new DataSet();
                    da.Fill(ds, "users");
                    dt = ds.Tables["Users"]; // write type table 
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            Console.WriteLine(row[col]);
                        }
                        Console.WriteLine("".PadLeft(20, '='));
                    }  break;
                #endregion writeindatatable

                #region writesqlxmlfile
                case 9:
                    query = "SELECT * FROM userlist";
                    da = new SqlDataAdapter(query, cnn);
                    ds = new DataSet();
                    da.Fill(ds, "users");
                    dt = ds.Tables["Users"];
                    dt.WriteXml("users.xml"); // write file  \bin\Debug\netcoreapp3.1
                    break;
                #endregion writesqlxmlfile

                #region others
                default: Console.WriteLine("Invalid Operation"); break;
            }
        }
    }
}
#endregion others