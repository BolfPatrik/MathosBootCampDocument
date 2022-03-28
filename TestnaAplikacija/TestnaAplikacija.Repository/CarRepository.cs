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
    public class CarRepository : ICarRepository
    {
        static string connectionToString = (@"Data Source=VOSTRO-2;Initial Catalog=TestnaAplikacija;Integrated Security=True");
        public List<Car> GetAllCars()
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Car", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    List<Car> listcar = new List<Car>();
                    while (reader.Read())
                    {
                        Car car = new Car();
                        car.CarId= reader.GetInt32(0);
                        car.Name = reader.GetString(1);
                        car.Manufacturer = reader.GetString(2);                      
                        listcar.Add(car);
                    }
                    connection.Close();
                    return listcar;
                }
                else
                {
                    return null;
                }
            }
        }
        public Car PostCar(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
                
                SqlCommand command = new SqlCommand
         ("INSERT INTO Car (CarId, Name,Manufacturer)" + "VALUES (@SalesmanId, @Name, @Manufacturer)", connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet cars = new DataSet();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
                return car;
            }
        }
        public Car PutCar(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
                
                SqlCommand command = new SqlCommand("UPDATE Car SET CarId = @CarId, Name = @Name ,Manufacturer = Manufacturer" + "WHERE CarId = @oldCarId", connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet cars = new DataSet();
                adapter.UpdateCommand = command;
                adapter.UpdateCommand.ExecuteNonQuery();
                connection.Close();
                return car;
            }
        }
        public Car DeleteCarById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionToString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet cars = new DataSet();
                adapter.DeleteCommand = new SqlCommand($"DELETE FROM Car WHERE CarId=@CarId;", connection);
                adapter.DeleteCommand.Parameters.Add("@CarId");
                connection.Close();
                return null;
            }
        }
    }
    }
