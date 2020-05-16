using Newtonsoft.Json;
using System;
using System.Data;
using System.Security.Authentication;
using Xunit;
using Xunit.Abstractions;

namespace go.test.sam.reader.test
{
    public class UnitTest1
    {
            //public string testData = "[{ \"id\":\"10\",\"name\":\"User\",\"name\":\"User\"}, { \"id\":\"11\",\"name\":\"Group\",\"name\":\"User\"}, { \"id\":\"12\",\"name\":\"Permission\",\"name\":\"User\"}]";
            public string testData = "[{ \"id\": 26582,\"index\": 0,\"guid\": \"9e1253e4-2dd0-433e-a191-84852f72f9b7\", \"isActive\": true, \"balance\": 1951},{\"id\": 22982,\"index\": 1,\"guid\": \"cbdbaa0b-4796-45dc-a1cd-52c3e6448156\",\"isActive\": false,\"balance\": 3379},{\"id\": 61311,\"index\": 2,\"guid\": \"8675fac1-53a9-4d09-9a9b-796104bfe912\",\"isActive\": false,\"balance\": 2900}]";
           
        [Fact]
        public void testIfNumberOfRowsAreCountedCorrect()
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(testData, (typeof(DataTable)));

            var a = readDB.antall(dt);
            Assert.Equal(3, a);
        }

        [Fact]
        public void testIfZeroRowsAreCountedCorrect()
        {
            string testData = "[]";
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(testData, (typeof(DataTable)));

            var a = readDB.antall(dt);
            Assert.Equal(0, a);
        }
        [Fact]
        public void testIfFirstRowAreReturned()
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(testData, (typeof(DataTable)));
                       
            var a = readDB.firstRow(dt);
            Assert.Equal($"Verdier: {dt.Rows[0][0]} og {dt.Rows[0][2]}", a);
        }

        [Fact]
        
        public void testIfFirstRowOfEmptyTableAreReturnedIndexOutOfRangeException()
        {
            string testDataEmpty = "[]";
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(testDataEmpty, (typeof(DataTable)));

            Assert.Throws<IndexOutOfRangeException>(() => readDB.firstRow(dt)) ;
            Exception ex = Assert.Throws<System.IndexOutOfRangeException>(() => readDB.firstRow(dt));
            Assert.Equal("There is no row at position 0.", ex.Message);

        }
        [Fact]
        public void testIfFirstRowOfEmptyTableAreReturnedRightString()
        {
            string testDataEmpty = "[]";
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(testDataEmpty, (typeof(DataTable)));

            Exception ex = Assert.Throws<System.IndexOutOfRangeException>(() => readDB.firstRow(dt));
            Assert.Equal("There is no row at position 0.", ex.Message);

        }
    }
}
