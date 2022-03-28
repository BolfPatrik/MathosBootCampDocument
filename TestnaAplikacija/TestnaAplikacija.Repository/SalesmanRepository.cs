using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TestnaAplikacija.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestnaAplikacija.Repository.Common;
using System.Data;

namespace TestnaAplikacija.Repository
{
    public class SalesmanRepository : ISalesmanRepository
    {
        static string connectionToString = (@"Data Source=VOSTRO-2;Initial Catalog=TestnaAplikacija;Integrated Security=True");
        public List<Salesman> GetAllSalesman()
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Salesman", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    List<Salesman> listsalesman = new List<Salesman>();
                    while (reader.Read())
                    {

                        Salesman salesman = new Salesman();
                        salesman.SalesmanId = reader.GetInt32(0);
                        salesman.Name = reader.GetString(1);
                        salesman.Surname = reader.GetString(2);
                        salesman.Oib = reader.GetString(3);
                        salesman.Salary = reader.GetInt32(4);
                        listsalesman.Add(salesman);
                    }
                    connection.Close();
                    return listsalesman;

                }
                else
                {
                    return null;
                }
            }
        }
        public Salesman PostSalesman(Salesman salesman)
        {

            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
               
                SqlCommand command = new SqlCommand
         ("INSERT INTO Salesman (SalesmanId, Name, Surname, Oib, Salary)" + "VALUES (@SalesmanId, @Name, @Surname, @Oib, @Salary)", connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet salesmen = new DataSet();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
                return salesman;
            }
        }
        public Salesman PutSalesman(Salesman salesman)
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
                SqlCommand command = new SqlCommand("UPDATE Salesman SET SalesManId = @SalesmanId, Name = @Name , Surname = @Surname,Oib = @Oib, Salary = @Salary" + "WHERE SalesmanId = @oldSalesmanId", connection);
                    connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet salesmen = new DataSet();
                adapter.UpdateCommand = command;
                    adapter.UpdateCommand.ExecuteNonQuery();
                    connection.Close();
                    return salesman;
                }
            }
        public Salesman DeleteSalesmanById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {             
                connection.Open();                              
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet cars = new DataSet();
                adapter.DeleteCommand = new SqlCommand($"DELETE FROM Salesman WHERE SalesmanId=@SalesmanId;", connection);
                adapter.DeleteCommand.Parameters.Add("@SalesmanId");
                connection.Close();
                return null ;
                }              
            }
        }
    }





