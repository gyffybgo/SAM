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
            string ut = "";
            int rad = 0;
            int kolonne = 0;
            if (kolonne == 1)
            {
                throw new System.IndexOutOfRangeException("Kan ikke være 0");
            }
            ut = $"Verdier: {bb.Rows[rad][kolonne]} og {bb.Rows[rad][kolonne + 2]}";
            return ut;
        }
    }
}
