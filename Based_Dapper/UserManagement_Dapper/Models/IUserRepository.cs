namespace UserManagement_Dapper.Models
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        User CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);

    }
}
