using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Data;

namespace UserManagement_Dapper.Models
{
    public class UserRepository : IUserRepository
    {
        string? connectionString = null;

        public UserRepository(string conn)
        {
            connectionString = conn;
        }

        public User CreateUser(User user)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "INSERT INTO Users(UserName, Age) VALUES(@UserName, @Age);";
                connection.Execute(sqlQuery, user);
                return user;

            }

        }

        public void DeleteUser(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id=@Id";
                var user = connection.Execute(sqlQuery, new { id });
            }
        }


        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Users";
                users = connection.Query<User>(sqlQuery).ToList();
            }
            return users;
        }

        public User GetUser(int id)
        {
            User? user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Users WHERE Id = @id";
                user = db.Query<User>(sqlQuery, new {id}).FirstOrDefault();
            }
            return user;
        }

        public void UpdateUser(User user)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE Users SET UserName = @UserName, Age = @Age WHERE Id=@Id";
                 connection.Execute(sqlQuery, user);
            }
            
        }
    }
}
