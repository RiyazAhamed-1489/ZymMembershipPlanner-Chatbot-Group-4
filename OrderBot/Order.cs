using Microsoft.Data.Sqlite;

namespace OrderBot
{
    public class Order : ISQLModel
    {
        private string _plans = String.Empty;
        private string _phone = String.Empty;
       
        public string Phone{
            get => _phone;
            set => _phone = value;
        }

        public string Plans{
            get => _plans;
            set => _plans = value;
        }
      

        public void Save(){
           using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandUpdate = connection.CreateCommand();
                commandUpdate.CommandText =
                @"
        UPDATE orders
        SET plans = $plans
        WHERE phone = $phone
    ";
                commandUpdate.Parameters.AddWithValue("$plans", Plans);
                commandUpdate.Parameters.AddWithValue("$phone", Phone);
                int nRows = commandUpdate.ExecuteNonQuery();
                if(nRows == 0){
                    var commandInsert = connection.CreateCommand();
                    commandInsert.CommandText =
                    @"
            INSERT INTO orders(plans, phone)
            VALUES($plans, $phone)
        ";
                    commandInsert.Parameters.AddWithValue("$plans", Plans);
                    commandInsert.Parameters.AddWithValue("$phone", Phone);
                    int nRowsInserted = commandInsert.ExecuteNonQuery();

                }
            }

        }
    }
}
