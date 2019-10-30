using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Model;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class UserProcessor
    {
        //method to create Users
        public static int CreateUsers(string userName, string firstName, string lastName)
        {
            //organize the data that will be added
            UserModel data = new UserModel
            {
                UserName = userName,
                FirstName = firstName,
                LastName = lastName
            };

            //create an sql query to create the new User
            string sql = @"insert into dbo.User (UserName, FirstName, LastName)
                            values (@UserName, @FirstName, @LastName)";

            //call the sqlDataAccess to create the new User
            return SqlDataAccess.SaveData(sql, data);
        }

        //Methodto load data
        public static List<UserModel> LoadUser()
        {
            //create the sql command
            string sql = @"SELECT Id, UserName, FirstName, LastName
                            FROM dbo.[User]";
            //call the sql data access to load the User data
            return SqlDataAccess.LoadData<UserModel>(sql);
        }

        //Methodto load data
        public static UserModel LoadOneUser(int id)
        {
            //create the sql command
            string sql = @"SELECT Id, UserName, FirstName, LastName
                            FROM dbo.User
                            WHERE Id = @id";
            //call the sql data access to load the User data
            return SqlDataAccess.LoadOne<UserModel>(sql, id); // the <UserModel> is used to specify the type
        }

        //Method to delete User
        public static void DeleteUser(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.User WHERE Id = @id";

            //call the sql data access to delete the User entry
            SqlDataAccess.DeleteData(sql, id);
        }

        //Method to update User
        public static void UpdateUsers(int id, string userName, string firstName, string lastName)
        {

            //organize the data that will be added
            UserModel data = new UserModel
            {
                Id = id,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName
            };

            //create the sql command
            string sql = @" UPDATE dbo.User
                            SET UserName = @UserName, FirstName = @FirstName, LastName = @LastName 
                            WHERE Id = @Id";

            //call the sql data access to delete the User entry
            SqlDataAccess.UpdateData(sql, data);
        }

    }
}
