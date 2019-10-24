using System;
using System.Collections.Generic;
using DataLibrary.Model;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class BugProcessor
    {
        //method to create Projects
        public static int CreateBug(int id, string description, string status,
            string details, string priorityLevel, int bugProjectId)
        {
            //organize the data that will be added
            BugModel data = new BugModel
            {
                Id = id,
                Description = description,
                Status = status,
                Details = details,
                PriorityLevel = priorityLevel,
                BugProjectId = bugProjectId
            };

            //create an sql query to create the new project
            string sql = @"insert into dbo.Bug (Description, Status, Details, PriorityLevel, BugProjectId)
                            values (@Description, @Status, @Details, @PriorityLevel, @BugProjectId);";

            //call the sqlDataAccess to create the new project
            return SqlDataAccess.SaveData(sql, data);
        }

        //Methodto load data
        public static List<BugModel> LoadBugs(int id)
        {
            //create the sql command
            string sql = @"SELECT Id, Description, Status, Details, PriorityLevel, BugProjectId
                            FROM dbo.Bug
                            WHERE BugProjectId = @id";
            //call the sql data access to load the project data
            return SqlDataAccess.LoadData<BugModel>(sql, id);
        }

        //Methodto load data
        public static BugModel LoadOneBug(int id)
        {
            //create the sql command
            string sql = @"SELECT Id, Description, Status, Details, PriorityLevel, BugProjectId
                            FROM dbo.Bug
                            WHERE Id = @id";
            //call the sql data access to load the project data
            return SqlDataAccess.LoadOne<BugModel>(sql, id); // the <ProjectModel> is used to specify the type
        }

        //Method to delete Project
        public static void DeleteBug(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.Bug WHERE Id = @id";

            //call the sql data access to delete the project entry
            SqlDataAccess.DeleteData(sql, id);
        }

        //Method to update Project
        public static void UpdateBug( int id, string description,
        string status, string details, string priorityLevel, int bugProjectId)//will have to add deadline after getting it to work
        {
            //organize the data that will be added
            BugModel data = new BugModel
            {
                Id = id,
                Description = description,
                Status = status,
                Details = details,
                PriorityLevel = priorityLevel,
                BugProjectId = bugProjectId
            };

            //create the sql command
            string sql = @" UPDATE dbo.Bug
                            SET Description = @Description, Status = @Status,
                                Details = @Details, PriorityLevel = @PriorityLevel, BugProjectId = @BugProjectId
                            WHERE Id =@Id";

            //call the sql data access to delete the project entry
            SqlDataAccess.UpdateData(sql, data);
        }


    }
}