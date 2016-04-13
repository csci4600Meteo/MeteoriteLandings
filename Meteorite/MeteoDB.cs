using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoriteLib
{
    public class MeteoDB : DataContext

    {



        public MeteoDB(string connectionString) : base(connectionString)
        {


            //////not the place to put this -jp


            //using (SqlConnection connection =
            //            new SqlConnection(connectionString))  {

            //            //the sql adapter is created here
            //            SqlDataAdapter adapter = new SqlDataAdapter();
            //            //here i am mapping a "Meteorites" table within the adapter to the MeteoTable
            //            adapter.TableMappings.Add("Meteorites", "MeteoTable");
            //            //here i am going to open the connection
            //            connection.Open();
            //            //this is going to create a command copy everything from the database to the table
            //            SqlCommand command = new SqlCommand("SELECT * from dbo.Meteorites");
            //            // seems to be the way to tell it this command type is a string?
            //            command.CommandType = System.Data.CommandType.Text;

            //            //loads the adapter with the command we made
            //            adapter.SelectCommand = command;

            //            //not exactly sure how to do this so or what to put in

            //           //adapter.Fill();

            //            //This is where i got, basically gonna wait til the database is up so
            //            //i can make sure this is right first


        }

    
        public Table<Meteorite> MeteoTable;
  
    }
}
