using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace go.test.sam.reader
{
    public class readDB
    {

        public static void printOut(DataTable bb)
        {
            Console.WriteLine(antall(bb));
            foreach (DataRow dataRow in bb.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static int antall(DataTable bb)
        {
            return bb.Rows.Count;
        }

        public static string firstRow(DataTable bb)
        {
            string ut ="";
            ut = $"Verdier: {bb.Rows[0][0]} og {bb.Rows[0][2]}";
            return ut;
        }
    }
}
