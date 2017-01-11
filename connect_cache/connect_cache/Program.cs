using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterSystems.Data.CacheClient;
using InterSystems.Data.CacheTypes;

// Author: Vicky Li Horst

namespace ConsoleApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
			Connection(); //first have one thread call multiple Open()
			System.Threading.Thread[] threads;
            threads = new System.Threading.Thread[50];
            for (int i = 0; i < 50; i++)
            {

                threads[i] = new System.Threading.Thread(() => Connection());  //use an anonymous delegate then define a method
                
				threads[i].Start();
            }

        }
        public static void Connection()
        {
			for (int j = 0; j < 70; j++)
			{
				CacheConnection CacheConnect = new CacheConnection();
				CacheConnect.ConnectionString = "Server = localhost; "
				  + "Port = 1972; " + "Namespace = SAMPLES; "
				  + "Password = SYS; " + "User ID = _SYSTEM;" + "LogFile=//Tmp//NET.txt;" + "Min Pool Size=50;Max Pool Size=500;Connection Reset=false;Connection Lifetime=300;";

				CacheConnect.Open();

				//The following code runs again against the database
                /*string SQLtext = "SELECT * FROM Sample.Person WHERE ID = 1";
	            CacheCommand Command = new CacheCommand(SQLtext, CacheConnect);
	            CacheDataReader Reader = Command.ExecuteReader();
	            while (Reader.Read())
	            {
	                Console.WriteLine("Output: \r\n   "
	                  + Reader[Reader.GetOrdinal("ID")] + ": "
	                  + Reader[Reader.GetOrdinal("Name")]);
	            };
	            //Console.ReadLine();
				Reader.Close();
				Command.Dispose();*/

				CacheConnect.Close();
			}
        }
    }
}
