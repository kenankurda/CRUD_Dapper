using CRUD_Dapper.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CodeLib.Models
{
    public class BookRepo
    {
        public void AddBook(Book book)  // this method adds new record in database using stored procedure
        {
            DynamicParameters param = new DynamicParameters();  // create dynamic parameters
            param.Add("@Title", book.Title);  // add aparameters in param object
            param.Add("@Author", book.Author); // add aparameters in param object
            param.Add("@Price", book.Price); // add aparameters in param object
            param.Add("@Description", book.Description); // add aparameters in param object
            param.Add("@CountryId", book.CountryId); // add aparameters in param object

            using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            {
                connection.Execute("InsertBook", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateBook(Book book)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", book.Id);
            param.Add("@Title", book.Title);
            param.Add("@Author", book.Author);
            param.Add("@Price", book.Price);
            param.Add("@Description", book.Description);
            param.Add("@CountryId", book.CountryId);

            using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            {
                connection.Execute("UpdateBook", param, commandType: CommandType.StoredProcedure);
            }

        }

        public List<Book> GetBooks()
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            {

                var books = connection.Query<Book>("GetAllBooks",
                    commandType: CommandType.StoredProcedure).ToList();

                return books;
            }
        }
    }
}
