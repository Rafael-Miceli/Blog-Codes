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
            using (var connection = new SqlConnection("Server=tcp:YourServer,1433;Initial Catalog=YourDatabase;Persist Security Info=True;"))
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

            // return new List<Feeder> {
            //     new Feeder("Hello from SqlServer")                
            // };
        }

        public void Create(Feeder feeder)
        {
            Console.WriteLine("Criando no SqlServer");
            using (var connection = new SqlConnection("Server=tcp:YourServer,1433;Initial Catalog=YourDatabase;Persist Security Info=True;"))
            {
                var command = new SqlCommand($"Insert Into Feeder values ('{feeder.Name}')", connection);
                connection.Open();                
                command.ExecuteNonQuery();
            }
        }
    }
}
