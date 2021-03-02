using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RequestForRepairWPF
{
    class DataBase
    {
        string connectionString = @"Server = DESKTOP-BSEODEL\SQLEXPRESS; DataBase = DB_RequestForRepair; Trusted_Connection = True;";

        int number = 0;

        public List<string[]> data = new List<string[]>();

        public void Select_7(string query)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        data.Add(new string[7]);
                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = reader[2].ToString();
                        data[data.Count - 1][3] = reader[3].ToString();
                        data[data.Count - 1][4] = reader[4].ToString();
                        data[data.Count - 1][5] = reader[5].ToString();
                        data[data.Count - 1][6] = reader[6].ToString();
                    }
                    connection.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + Convert.ToString(e));
            }
        }

        public void Select(string query)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    number = command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Успешно выбрано " + number + " объектов!");
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + Convert.ToString(e));
            }
        }

        public void Insert(string query)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    number = command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Успешно добавлено " + number + " объектов!");
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + Convert.ToString(e));
            }
        }

        public void Update(string query)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    number = command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Успешно обновлено " + number + " объектов!");
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + Convert.ToString(e));
            }
        }

        public void Delete(string query)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    number = command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Успешно удалено " + number + " объектов!");
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + Convert.ToString(e));
            }
        }

        public string GetResult(string query)
        {
            string result = string.Empty;
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format(query);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;
                                result = (string)reader[i];
                                i++;
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                    return result;
                }
            }
            catch(Exception e)
            {
                result = string.Empty;
                //MessageBox.Show("ERROR!!!\n" + Convert.ToString(e));
                return result;
            }
        }

        public bool Check(string query, string data)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format(query);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            int i = 0;
                            if (data == reader[i].ToString())
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                    return result;
                }
            }
            catch(Exception e)
            {
                //MessageBox.Show("ERROR!!!\n" + Convert.ToString(e));
                return false;
            }
        }

        public int GetID(string query)
        {
            int id = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format(query);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;
                                id = (int)reader[i];
                                i++;
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                    return id;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + Convert.ToString(e));
                return 0;
            }
        }

    }
}
