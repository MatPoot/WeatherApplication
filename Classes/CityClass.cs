using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JamboApplication.Classes
{
    public class CityClass
    {
        // fetch all database records - containing city names and descriptions
        public List<City> FetchCities()
        {

            //Connect to SQL server

            SqlConnection MasterConnection = new SqlConnection();
            MasterConnection.ConnectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=master; Integrated Security=True";
            
            MasterConnection.Open();


            //  create command to trigger the "FetchCities" stored procesure

            SqlCommand FetchCustomersCommand = new SqlCommand();
            FetchCustomersCommand.CommandType = CommandType.StoredProcedure;
            FetchCustomersCommand.Connection = MasterConnection;
            FetchCustomersCommand.CommandText = "FetchCities";

            // loop through all the results using reader and return
            SqlDataReader rdr = FetchCustomersCommand.ExecuteReader();

            List<City> ReturnCities = new List<City>();

            int counter = 0;
            while (rdr.Read())
            {
                City insertCity = new City();
                insertCity.Name = (string)rdr["Name"];
                insertCity.Label = (string)rdr["Label"];


                ReturnCities.Add(insertCity);
                counter = counter++;
            }


            MasterConnection.Close();
            return ReturnCities;
        }
    }
}
