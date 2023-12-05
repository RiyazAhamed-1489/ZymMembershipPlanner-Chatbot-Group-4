using Microsoft.Data.Sqlite;

namespace OrderBot
{
    public class Order : ISQLModel
    {
        private string _plans = String.Empty;
        private string _phone = String.Empty;
        private string _membershipplan = String.Empty;
        private string _name = String.Empty;
        private string _welcome = String.Empty;
        private string _gender = String.Empty;
        private string _age = String.Empty;
        private string _emailid = String.Empty;
        private string _contactno = String.Empty;
        private string _membershipdetails = String.Empty;
        public string Phone{
            get => _phone;
            set => _phone = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Plans{
            get => _plans;
            set => _plans = value;
        }
        public string Age
        {
            get => _age;
            set => _age = value;
        }


        public string Welcome
        {
            get => _welcome;
            set => _welcome = value;
        }
        public string MembershipPlan
        {
            get => _membershipplan;
            set => _membershipplan = value;
        }

        public string MembershipDetails
        {
            get => _membershipdetails;
            set => _membershipdetails = value;
        }
       

        public string Gender
        {
            get => _gender;
            set => _gender = value;
        }
        public string Emailid
        {
            get => _emailid;
            set => _emailid = value;
        }
        public string ContactNo
        {
            get => _contactno;
            set => _contactno = value;
        }

       
        public void Save(){
           using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandUpdate = connection.CreateCommand();
                commandUpdate.CommandText =
                @"
        UPDATE orders
        SET plans = $plans,
         name =$name,
         gender =$gender,
         age = $age,
         emailid =$emailid,
         contactno =$contactno

        WHERE plans = $plans
    ";
                commandUpdate.Parameters.AddWithValue("$plans", Plans);
                commandUpdate.Parameters.AddWithValue("$name", Name);
                commandUpdate.Parameters.AddWithValue("$gender", Gender);
                commandUpdate.Parameters.AddWithValue("$age", Age);
                commandUpdate.Parameters.AddWithValue("emailid", Emailid);
                commandUpdate.Parameters.AddWithValue("contactno", ContactNo);
                int nRows = commandUpdate.ExecuteNonQuery();
                if(nRows == 0){
                    var commandInsert = connection.CreateCommand();
                    commandInsert.CommandText =
                    @"
            INSERT INTO orders(plans,name,gender,age,emailid,contactno)
            VALUES($plans,$name,$gender,$age,$emailid,$contactno)
        ";
                    commandInsert.Parameters.AddWithValue("$plans", Plans);
                    commandInsert.Parameters.AddWithValue("$name", Name);
                    commandInsert.Parameters.AddWithValue("$gender", Gender);
                    commandInsert.Parameters.AddWithValue("$age", Age);
                    commandInsert.Parameters.AddWithValue("emailid", Emailid);
                    commandInsert.Parameters.AddWithValue("contactno", ContactNo);
                    int nRowsInserted = commandInsert.ExecuteNonQuery();

                }
            }

        }
    }
}
