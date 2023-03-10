using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;";
        string query = "SELECT Products.Name AS ProductName, Categories.Name AS CategoryName " +
                       "FROM Products " +
                       "LEFT JOIN ProductCategories ON Products.Id = ProductCategories.ProductId " +
                       "LEFT JOIN Categories ON ProductCategories.CategoryId = Categories.Id " +
                       "ORDER BY ProductName, CategoryName";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string productName = reader["ProductName"].ToString();
                string categoryName = reader["CategoryName"].ToString();

                Console.WriteLine(productName + " - " + categoryName);
            }

            reader.Close();
        }
    }
}