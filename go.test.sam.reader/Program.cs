using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.CompilerServices;


namespace go.test.sam.reader
{
    class Program
    {
        public static string testData = "[{ \"id\": 26582,\"index\": 0,\"guid\": \"9e1253e4-2dd0-433e-a191-84852f72f9b7\", \"isActive\": true, \"balance\": 1951},{\"id\": 22982,\"index\": 1,\"guid\": \"cbdbaa0b-4796-45dc-a1cd-52c3e6448156\",\"isActive\": false,\"balance\": 3379},{\"id\": 61311,\"index\": 2,\"guid\": \"8675fac1-53a9-4d09-9a9b-796104bfe912\",\"isActive\": false,\"balance\": 2900}]";

        public static void Main(string[] args)
        {

            //connectToDB();
            dataFromJason();
        }

        public static void connectToDB()
        {
            DateTime startTid = DateTime.Now;
            DataTable bb = new DataTable("bbusdef");
            string sstring = "select CONVERT(varchar(10),USDEFID) USDEFID,rtrim(NAVN) NAVN, rtrim(BESKRIVELSE),rtrim(TELEFON) from BBUSDEF where ABONTYPE = 1 and USTYPEID not in (544,471,430,335,263,360,543) and USAKTIV=1 and SAMBTYPE = 3";

            string ems_sql_cluster = @"Data Source=bkksql06;Initial Catalog=dg10;Integrated Security=True";
            SqlConnection _con = new SqlConnection(ems_sql_cluster);

            using (SqlCommand _cmd = new SqlCommand(sstring, _con))
            {
                SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                _con.Open();
                _dap.Fill(bb);
                _con.Close();
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(testData, (typeof(DataTable)));

                Console.WriteLine(readDB.firstRow(dt));
            }
        }
        public static void dataFromJason()
        {

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(testData, (typeof(DataTable)));

                Console.WriteLine(readDB.firstRow(dt));
            }
       
    public static void dataFromJason2()
        {

        DataTable dt = (DataTable)JsonConvert.DeserializeObject(testData, (typeof(DataTable)));

        Console.WriteLine(readDB.firstRow(dt));
        } 

    }

    
}
