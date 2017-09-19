using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain;

namespace Data
{
    public class FeederSqlServerRepository: IFeederRepository
    {
        public IEnumerable<Feeder> GetAll()
        {
            //using (var connection = new SqlConnection("Server=tcp:192.168.99.100,1433;Initial Catalog=master;User Id=sa;Password=whatever12!"))
            using (var connection = new SqlConnection("Server=tcp:localhost,1433;Initial Catalog=master;User Id=sa;Password=whatever12!"))
            {
                var command = new SqlCommand("SELECT Id, Name FROM Feeder", connection);
                connection.Open();                
                using (var reader = command.ExecuteReader())
                {
                    var feeders = new List<Feeder>();

                    while (reader.Read())
                    {
                        feeders.Add(new Feeder(reader[1].ToString()));
                        Console.WriteLine($"{reader[0]}:{reader[1]}");
                    }

                    return feeders;
                }
            }
        }

        public void Create(Feeder feeder)
        {
            Console.WriteLine("Criando no SqlServer");
            //using (var connection = new SqlConnection("Server=tcp:192.168.99.100,1433;Initial Catalog=master;User Id=sa;Password=whatever12!"))
            using (var connection = new SqlConnection("Server=tcp:localhost,1433;Initial Catalog=master;User Id=sa;Password=whatever12!"))
            {
                var command = new SqlCommand($"Insert Into Feeder values ('{feeder.Name}')", connection);
                connection.Open();                
                command.ExecuteNonQuery();
            }
        }
    }
}
