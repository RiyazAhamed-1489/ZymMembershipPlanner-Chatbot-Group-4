using System;
using System.IO;
using Xunit;
using OrderBot;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace OrderBot.tests
{
    public class OrderBotTest
    {
        public OrderBotTest()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandUpdate = connection.CreateCommand();
                commandUpdate.CommandText =
                @"
        DELETE FROM orders
    ";
                commandUpdate.ExecuteNonQuery();

            }
        }
        [Fact]
        public void Test1()
        {

        }
        [Fact]
        public void TestWelcome()
        {
            Session oSession = new Session("123");
            String sInput = oSession.OnMessage("hello")[0];
            Assert.True(sInput.Contains("Welcome"));
        }
        [Fact]
        public void TestWelcomPerformance()
        {
            DateTime oStart = DateTime.Now;
            Session oSession = new Session("123");
            String sInput = oSession.OnMessage("information")[0];
            DateTime oFinished = DateTime.Now;
            long nElapsed = (oFinished - oStart).Ticks;
            System.Diagnostics.Debug.WriteLine("Elapsed Time: " + nElapsed);
            Assert.True(nElapsed < 10000);
        }
        [Fact]
        public void TestName()
        {
            Session oSession = new Session("123");
            oSession.OnMessage("hello");
            String sInput = oSession.OnMessage("fullname")[0];
            Assert.Contains("fullname", sInput);
        }

        [Fact]
        public void TestGender()
        {
             Session oSession = new Session("123");
            oSession.OnMessage("hello");
            oSession.OnMessage("fullname");
            String sInput = oSession.OnMessage("Gender")[0];
            Assert.Contains("Gender", sInput);
        }
        [Fact]
        public void TestAge()
        {
            Session oSession = new Session("123");
            oSession.OnMessage("hello");
            oSession.OnMessage("fullname");
            oSession.OnMessage("Gender");
            String sInput = oSession.OnMessage("Age")[0];
           Assert.Contains("Age", sInput);
        }
        [Fact]
        public void TestEmail()
        {
            Session oSession = new Session("123");
            oSession.OnMessage("hello");
            oSession.OnMessage("fullname");
            oSession.OnMessage("Gender");
            oSession.OnMessage("Age");
            String sInput = oSession.OnMessage("Email id")[0];
            Assert.Contains("Email id", sInput);
        }
        [Fact]
        public void TestContactNo()
        {
            Session oSession = new Session("123");
            oSession.OnMessage("hello");
            oSession.OnMessage("fullname");
            oSession.OnMessage("Gender");
            oSession.OnMessage("Age");
            oSession.OnMessage("Email id");
            String sInput = oSession.OnMessage("Contact no")[0];
            Assert.Contains("Contact no", sInput);
        }

        [Fact]
        public void TestThanksMessage()
        {
            Session oSession = new Session("123");
            oSession.OnMessage("hello");
            oSession.OnMessage("fullname");
            oSession.OnMessage("Gender");
            oSession.OnMessage("Age");
            oSession.OnMessage("Email id");
            oSession.OnMessage("Contact no");
            String sInput = oSession.OnMessage("Thank you")[0];
            Assert.Contains("Thank you", sInput);
        }

        [Fact]
        public void TestMembershipPlan()
        {
            Session oSession = new Session("123");
            oSession.OnMessage("hello");
            oSession.OnMessage("fullname");
            oSession.OnMessage("Gender");
            oSession.OnMessage("Age");
            oSession.OnMessage("Email id");
            oSession.OnMessage("Contact no");
          
            String sInput = oSession.OnMessage("membership types")[1];
            Assert.Contains("membership types", sInput);
        }

        [Fact]
        public void TestMembershipDetails()
        {
            Session oSession = new Session("123");
            oSession.OnMessage("hello");
            oSession.OnMessage("fullname");
            oSession.OnMessage("Gender");
            oSession.OnMessage("Age");
            oSession.OnMessage("Email id");
            oSession.OnMessage("Contact no");
            oSession.OnMessage("membership types");

            String sInput = oSession.OnMessage("Silver plan")[0];
            Assert.Contains("Silver plan", sInput);
        }
        


        
    }
}
