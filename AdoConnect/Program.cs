using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

public class Proqram
{
    public static void Main()
    {

        SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-DUE6JJJ;Database=DynemicDataMaskingLingDb;Trusted_Connection=true");
        sqlConnection.Open();
        SqlCommand sqlCommand = new SqlCommand("EXECUTE AS USER = 'Ali'\r\nSELECT Id,Name,Surname,CardNumber FROM Users\r\nREVERT;", sqlConnection);
        DataTable table = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        adapter.Fill(table);
        sqlConnection.Close();
        
        Console.WriteLine(new string('-', 100));
        for (int i = 0; i < table.Columns.Count; i++)
        {

            Console.Write(table.Columns[i]);
            Console.Write($"{new String(' ', 20 - table.Columns[i].ToString().Length)}{'|'}");


        }
        Console.WriteLine();
        foreach (DataRow row in table.Rows)
        {
            foreach (var item in row.ItemArray)
            {
                
                Console.Write(item);
                Console.Write($"{new String(' ', 20- item.ToString().Length )}{'|'}");
               

            }
            Console.WriteLine();
        }
        Console.WriteLine(new String('-', 100));


    }
}

