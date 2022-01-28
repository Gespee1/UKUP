using System.Data.SqlClient;
using System.Configuration;

namespace РасчетКУ
{
    class Global_parameters
    {
        
        private void addParameter(string name)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand($"INSERT INTO Global_parameters (Name) VALUES ('{name}')", conn);
            command.ExecuteNonQuery();
           
            conn.Close();
        }

        public void setParameter(string name, string value)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand($"SELECT Value FROM Global_parameters WHERE Name = '{name}'", conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                reader.Close();
                command = new SqlCommand($"UPDATE Global_parameters SET Value = '{value}' WHERE Name = '{name}'", conn);
                command.ExecuteNonQuery();
            }
            else
                reader.Close();

            conn.Close();
        }

        public string getParameter(string name)
        {
            string param = "null";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            SqlCommand command = new SqlCommand($"SELECT Value FROM Global_parameters WHERE Name = '{name}'", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if(reader.HasRows)
                param = reader[0].ToString();
            else
            {
                reader.Close();
                conn.Close();
                addParameter(name);
                getParameter(name);
            }
            reader.Close();
            conn.Close();
           return param;
        }

        private void addPath(string user, string textPath)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand($"INSERT INTO UsersPathes ([User], Path) VALUES ('{user}', '{textPath}')", conn);
            command.ExecuteNonQuery();

            conn.Close();
        }

        public void setPath(string user, string textPath)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand($"SELECT Path FROM UsersPathes WHERE User = '{user}'", conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                reader.Close();
                command = new SqlCommand($"UPDATE UsersPathes SET Path = '{textPath}' WHERE User = '{user}'", conn);
                command.ExecuteNonQuery();
            }
            else
            {
                reader.Close();
                addPath(user, textPath);
            }    
                

            conn.Close();
        }

        public string getPath(string user)
        {
            string param = "null";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            SqlCommand command = new SqlCommand($"SELECT Path FROM UsersPathes WHERE [User] = '{user}'", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
                param = reader[0].ToString();
           /* else
            {
                reader.Close();
                conn.Close();
                addPath(user);
                getPath(user);
            }*/
            reader.Close();
            conn.Close();
            return param;
        }
    }
}
