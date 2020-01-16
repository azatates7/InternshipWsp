using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; 

namespace AdoNetWorkspace
{
    public class UserDAL
    { 
        SqlConnection cnn = new SqlConnection(@"server=(localdb)\mssqllocaldb; Trusted_Connection = true; database = testdb; connection timeout = 30");
        int result;
        private void CheckConnection()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
        }

        public int CountItems()
        {
            string query = "SELECT COUNT(*) FROM userlist"; 
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    CheckConnection(); 
                    result = Convert.ToInt32(command.ExecuteScalar());
                    cnn.Close();
                return result;
                }  
        } 

        public List<User> GetAll(){
            CheckConnection();
            string query = "Select * from userlist";
            SqlCommand command = new SqlCommand(query, cnn);
            SqlDataReader rdr = command.ExecuteReader(); 
            List<User> usr = new List<User>();

            while (rdr.Read())
            {
                User us = new User
                {
                    id = Convert.ToInt32(rdr["id"]),
                    name = Convert.ToString(rdr["name"]),
                    userkey = Convert.ToString(rdr["userkey"]),
                };
                usr.Add(us);
            }
             
            rdr.Close();
            cnn.Close();
            return usr;
        }
         
        public DataTable GetAll2()
        {
            CheckConnection();
            cnn.Open();
            string query = "Select * from userlist";
            SqlCommand command = new SqlCommand(query, cnn);
            SqlDataReader rdr = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(rdr);
            rdr.Close();
            cnn.Close();
            return dt;
        }

        public void InsertUser(User usr)
        {
            CheckConnection(); 
            string query = "INSERT INTO userlist (name, userkey) VALUES (@name, @userkey)";
            using (SqlCommand command = new SqlCommand(query, cnn))
            { 
                command.Parameters.AddWithValue("@name", usr.name);
                command.Parameters.AddWithValue("@userkey", usr.userkey); 
                int result = command.ExecuteNonQuery();
            }
            cnn.Close();
        }

        public void UpdateUser(User usr, int id)
        {
            CheckConnection();
            string query = "UPDATE userlist SET name=@name, userkey=@userkey WHERE id="+id;
            using (SqlCommand command = new SqlCommand(query, cnn))
            {
                command.Parameters.AddWithValue("@name", usr.name);
                command.Parameters.AddWithValue("@userkey", usr.userkey);
                int result = command.ExecuteNonQuery();
            }
            cnn.Close();
        }

        public void DeleteUser(int id)
        {
            CheckConnection();
            String query = "DELETE FROM userlist WHERE id=@id";
            SqlCommand command = new SqlCommand(query, cnn);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            cnn.Close(); 
        }

        public Tuple<DataTable,int> SearchUser(string name)
        { 
            CheckConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from userlist where name like '" + name + "%'", cnn);
            DataTable dt = new DataTable();
            adapter.Fill(dt); 
            cnn.Close();
            string query = "select COUNT(*) from userlist where name like '" + name + "%'";
            using (SqlCommand command = new SqlCommand(query, cnn))
            {
                CheckConnection();
                result = Convert.ToInt32(command.ExecuteScalar());
                Console.WriteLine(result); 
                cnn.Close();
                return new Tuple<DataTable, int>(dt, result);
            }
            
        }
    }
} 