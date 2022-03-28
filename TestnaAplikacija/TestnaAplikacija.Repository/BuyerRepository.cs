using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestnaAplikacija.Model;
using TestnaAplikacija.Repository.Common;

namespace TestnaAplikacija.Repository
{
    public class BuyerRepository : IBuyerRepository
    {
        static string connectionToString = (@"Data Source=VOSTRO-2;Initial Catalog=TestnaAplikacija;Integrated Security=True");
        public List<Buyer> GetAllBuyers()
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Buyer", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    List<Buyer> listbuyer = new List<Buyer>();
                    while (reader.Read())
                    {

                        Buyer buyer = new Buyer();
                        buyer.BuyerId = reader.GetInt32(0);
                        buyer.Name = reader.GetString(1);
                        buyer.Surname = reader.GetString(2);
                        buyer.Oib = reader.GetString(3);                       
                        listbuyer.Add(buyer);
                    }
                    connection.Close();
                    return listbuyer;
                }
                else
                {
                    return null;
                }
            }
        }
        public Buyer PostBuyer(Buyer buyer)
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
               
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand
                ("INSERT INTO Buyer (BuyerId, Name, Surname, Oib)" + "VALUES (@BuyerId, @Name, @Surname, @Oib)", connection);
                DataSet buyers = new DataSet();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
                return buyer;
            }
        }
        public Buyer PutBuyer(Buyer buyer)
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
               
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("UPDATE Buyer SET BuyerId = @BuyerId, Name = @Name , Surname = @Surname,Oib = @Oib" + "WHERE BuyerId = @oldBuyerId", connection);
                adapter.UpdateCommand = command;
                adapter.UpdateCommand.ExecuteNonQuery();
                connection.Close();
                return buyer;
            }
        }
        public Buyer DeleteBuyerById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
               
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet cars = new DataSet();
                adapter.DeleteCommand = new SqlCommand($"DELETE FROM Buyer WHERE BuyerId=@BuyerId;", connection);
                adapter.DeleteCommand.Parameters.Add("@BuyerId");
                connection.Close();
                return null;
            }
        }
    }
    }

