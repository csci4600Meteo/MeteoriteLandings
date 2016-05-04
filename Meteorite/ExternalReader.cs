using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace MeteoriteLib
{

    


    //this class CollumnData is an intermediary for the Data being pulled from the CSV file

    /*
        Alright i feel a quick explanation is in order, "John, why do you have inherit from a list<string> AND Have a string member? it 
        seems like you have all the strings you could need in that list" CORRECT, i do have a place for strings in the other list, BUT
        I like to keep things tidy(ish). the "Data" member is the Entirety of the data being read from the file, the List<string> part will 
        contain the fields after we go through and seperate them out. Genius right? :D
    */

    public class CollumnData : List<string> {
        private string data;

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }
    }

    public class ExternalReader : StreamReader
    {
        //constructor that takes a stream
        public ExternalReader(Stream stream)
            : base(stream)
        {
        }
        //constructor that takes a file path
        public ExternalReader(string filename)
            : base(filename)
        {
        }


      


        //this method ReadMeteorite Allows us to create a Meteorite Object from information provided by the CSV file
        public Meteorite ReadMeteorite() {
            //--------------------our first step in pulling the meteorite data should be creating our temp variables
            CollumnData D = new CollumnData();  //to store info
            int position = 0;                   // keeps track of our position within the string
            int row = 0;                        //keeps track of which row in our collumn we are copying to
            string temp="";                     //well this is a string for temporary storage 
            //alright now, first things first, we should read our line from the file
            D.Data = ReadLine();

            //--------------------alright  thats awesome! but there is a problem...
            //for this specific file, there is a sort of key on the first line, so what we are gonna do is get rid of that key 
            //IF it exists! becasue we are gonna be reusing this function in a loop (youll see later). we only wanna skip the line
            //IF its the line we...well wanna skip. Makes sense right?

            //Definitely need to make that key a global const...Or maybe not, not sure yet, i think it looks ugly as is though
            if (D.Data == "name,id,nametype,recclass,mass (g),fall,year,reclat,reclong,GeoLocation (address),GeoLocation (zip),GeoLocation (city),GeoLocation,GeoLocation (state)")
            {
                D.Data = ReadLine();
            }
            //alright what that little marvel does is checks if the we wanna skip our current line. Brilliant right? Sorry i gotta stop giving myself so much credit. heh


            //--------------------so all that was the really basic and easy part, this is the "Meat and Potatoes" portion of our function

            //so we need to make a note of what we are doing right off the bat. we are going through our raw string, character by character to
            //populate our CollumnData List thingies elements with the data that will eventually go into the meteorite, since we are going through
            //a collection of variable size repeatedly, we need a while loop

            //this is saying "do this as long as we arent at the end of our string"
            while (position < D.Data.Length)
            {
                int start = position;           //this is to track where we are within our string

                //Alright so here we are gonna need another while loop to extract from the raw string the values we
                //want to store in our list

                //--------------------Inner Loop 
                //this loop checks to make sure we arent done with the string AND the value isnt a comma
                //the file is a CSV (comma seperated values) so each thing we wanna put into our list is seperated 
                //by
                //....BY
                //......
                //......
                //...zzzz
                //oops, what i was gonna say was commas so it makes sense to check for those
                while (position < D.Data.Length && D.Data[position] != ',')
                {
                    position += 1;
                    temp = D.Data.Substring(start, position - start);
                    //what this does is figures out what we want to turn into a substring 
                    //and then saves it to our temp string
                }

                //--------------------Checking for our rows
                if (row < D.Count)
                    D[row] = temp;
                else
                    D.Add(temp);

                row += 1;

                //what this above section does is add out temp string to our list  then increment the row so 
                //the next field is added to the correct place

                //-------------------- Getting rid of bad data
                while (position < D.Data.Length && D.Data[position] != ',')
                {
                    position += 1;
                }
                if (position < D.Data.Length)
                    position += 1;
                

                while (D.Count > row)
                    D.RemoveAt(row);
                //the above statement will Actually be the one getting rid of the data from the raw string we dont need anymore 
                //this works in conjunction with the Inner Loop 2 and If Statement to clean our data and keep the gravy train rolling


            }
            //--------------------FINALLY OUT OF THE WHILE LOOP NIGHTMARE

            //--------------------Data Checking and meteorite Creation
            //so what we need to do here is bascially take our strings from our collumn data, Parse what needs to be 
            //Parsed and create and return a meteorite Object, I will comment for the first field, but after that it should
            //be pretty self explanatory


            //we need these temp variables to parse into, the others are already strings so
            //there is no need to parse
            int tempID;
            int tempMass;
            DateTime tempDate;
            double tempLat;
            double tempLong;
            //we need this bool for testing below
            bool isSuccessful;

            //uses the isSuccessful to see if the value can be parsed
            //(sometimes it cannot be) and if it fails, we KILL THE BATMAN
            //nah just kidding we assign it to a -1 or an obvious date to denote 
            // the data is unknown

            isSuccessful = int.TryParse(D[1], out tempID);
            if (!isSuccessful)
                tempID = -1;

            isSuccessful = int.TryParse(D[4], out tempMass);
            if (!isSuccessful)
                tempMass = -1;

            isSuccessful = DateTime.TryParse(D[6],out tempDate);
            if (!isSuccessful)
                tempDate = DateTime.MaxValue;

            isSuccessful = double.TryParse(D[7], out tempLat);
            if (!isSuccessful)
                tempLat = -1.0;

            isSuccessful = double.TryParse(D[8], out tempLong);
            if (!isSuccessful)
                tempLong = -1.0;

            //That beatiful code should take care of any problems we have, Yipee!!! now we can create our meteorite and send her back!

            Meteorite M = new Meteorite(D[0],tempID,tempMass,D[3],D[5],DateTime.Now.ToString(),tempLat,tempLong);

            return M;


        }

        public List<Meteorite> ReturnList() {

            List<Meteorite> list = new List<Meteorite>();
            Meteorite m;

            using (ExternalReader read = new ExternalReader("Meteorites.csv"))
            {

                while (read.EndOfStream != true)
                {
                    m = read.ReadMeteorite();
                    if (m.Name != "name")
                    {
                        list.Add(m);
                    }
                }

            }
            return list;

        } 

    }
}





//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++NEEEEEEEDDDDDSSSSS TOOOOO BE IMPLEMENTED ELSEWHERE


////this function allows us to pull the csv file from the website
////This PullCSV() function pulls a csv file from the database
////---NEEDS
////--Global Constants for the address and the filename 
//public void PullCSV()
//{
//    WebClient client = new WebClient();
//    client.DownloadFile("https://data.nasa.gov/api/views/gh4g-9sfh/rows.csv?accessType=DOWNLOAD", "Meteorites.csv");
//}