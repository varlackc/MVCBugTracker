using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Model;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    class UserProcessor
    {
        //method to create Users
        public static int CreateUsers(int id, string userDescription, string userType, DateTime timeStamp)
        {
            //organize the data that will be added
            UserModel data = new UserModel
            {
                Id = id,
                UserDescription = UserDescription,
                UserType = UserType,
                TimeStamp = timeStamp
            };

            //create an sql query to create the new User
            string sql = @"insert into dbo.User (UserDescription, UserType, TimeStamp)
                            values (@UserDescription, @UserType, @TimeStamp);";

            //call the sqlDataAccess to create the new User
            return SqlDataAccess.SaveData(sql, data);
        }

        //Methodto load data
        public static List<UserModel> LoadUser()
        {
            //create the sql command
            string sql = @"SELECT Id, UserDescription, UserType, TimeStamp
                            FROM dbo.User";
            //call the sql data access to load the User data
            return SqlDataAccess.LoadData<UserModel>(sql);
        }

        //Methodto load data
        public static UserModel LoadOneUser(int id)
        {
            //create the sql command
            string sql = @"SELECT Id, UserDescription, UserType
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
        public static void UpdateUser(int id, string UserDescription, string UserType, DateTime timeStamp)
        {

            //organize the data that will be added
            UserModel data = new UserModel
            {
                Id = id,
                UserDescription = UserDescription,
                UserType = UserType,
                TimeStamp = timeStamp
            };

            //create the sql command
            string sql = @" UPDATE dbo.User
                            SET UserDescription = @UserDescription, UserType = @UserType, TimeStamp = @TimeStamp 
                            WHERE Id = @Id";

            //call the sql data access to delete the User entry
            SqlDataAccess.UpdateData(sql, data);
        }

    }
}
