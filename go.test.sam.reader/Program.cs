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
        public static void Main(string[] args)
        {
            DateTime startTid = DateTime.Now;
            DataTable bb = new DataTable("bbusdef");
            string sstring = "select CONVERT(varchar(10),USDEFID) USDEFID,rtrim(NAVN) NAVN, rtrim(BESKRIVELSE),rtrim(TELEFON) from BBUSDEF where ABONTYPE = 1 and USTYPEID not in (544,471,430,335,263,360,543) and USAKTIV=1 and SAMBTYPE = 3";

            string ems_sql_cluster = @"Data Source=bkksql06;Initial Catalog=dg10;Integrated Security=True";
            SqlConnection _con = new SqlConnection(ems_sql_cluster);

            connectToDB(sstring, _con, bb);

            string testDataEmpty = "[]";
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(testDataEmpty, (typeof(DataTable)));
             
        }


        public static void connectToDB(string sstring, SqlConnection _con, DataTable bb)
        {
            string json;
            //using (SqlCommand _cmd = new SqlCommand(sstring, _con))
            //{
            //    //SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
            //    //_con.Open();
            //    //_dap.Fill(bb);
            //    //_con.Close();
            //    // readDB.printOut(bb);
            //    Console.WriteLine(readDB.firstRow(bb));
            //}
            using (StreamReader r = new StreamReader("generated.json"))
            {
                 json = r.ReadToEnd();
               
            } 
            DataTable items = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            Console.WriteLine(readDB.firstRow(items));


        }

    }
}
