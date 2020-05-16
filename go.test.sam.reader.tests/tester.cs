

using Newtonsoft.Json;
using System.Data;
using Xunit;

namespace go.test.sam.reader.test
{
    public class tester
    {
        [Fact]
        public void testIfNumberOfRowsAreCountedCorrect()
        {
            string testData = "[{ \"id\":\"10\",\"name\":\"User\"}, { \"id\":\"11\",\"name\":\"Group\"}, { \"id\":\"12\",\"name\":\"Permission\"}]";
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
    }
}
