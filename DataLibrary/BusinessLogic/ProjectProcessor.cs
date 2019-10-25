using System;
using System.Collections.Generic;
using DataLibrary.Model;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class ProjectProcessor
    {
        //method to create Projects
        public static int CreateProject(int id, string name,
        string description,
        DateTime deadLine)
        {
            //organize the data that will be added
            ProjectModel data = new ProjectModel
            {
                Id = id,
                Name = name,
                Description = description,
                DeadLine = deadLine
            };

            //create an sql query to create the new project
            string sql = @"insert into dbo.Project (Name, Description, DeadLine)
                            values (@Name, @Description, @DeadLine);";

            //call the sqlDataAccess to create the new project
            return SqlDataAccess.SaveData(sql, data);
        }

        //Methodto load data
        public static List<ProjectModel> LoadProjects()
        {
            //create the sql command
            string sql = @"select Id, Name, Description, DeadLine
                            from dbo.Project;";
            //call the sql data access to load the project data
            return SqlDataAccess.LoadData<ProjectModel>(sql);
        }

        //Methodto load data
        public static ProjectModel LoadOneProject(int id)
        {
            //create the sql command
            string sql =  @"SELECT Id, Name, Description, DeadLine
                            FROM dbo.Project
                            WHERE Id = @id";
            //call the sql data access to load the project data
            return SqlDataAccess.LoadOne<ProjectModel>(sql, id); // the <ProjectModel> is used to specify the type
        }

        //Method to delete Project
        public static void DeleteProject(int id) {

            //delete all of the bugs related to the project
            string sql = @"DELETE FROM dbo.Bug WHERE BugProjectId = @id";//create the sql query
            SqlDataAccess.DeleteData(sql, id);// access the data access to delete files

            //create the sql command
            sql = @"DELETE FROM dbo.Project WHERE Id = @id";

            //call the sql data access to delete the project entry
            SqlDataAccess.DeleteData(sql, id);
        }

        //Method to update Project
        public static void UpdateProject(int id, string name,
        string description)//will have to add deadline after getting it to work
        {
            //organize the data that will be added
            ProjectModel data = new ProjectModel
            {
                Id = id,
                Name = name,
                Description = description
            };

            //create the sql command
            string sql = @" UPDATE dbo.project
                            SET Name = @Name, Description = @Description
                            WHERE Id = @Id";

            //call the sql data access to delete the project entry
            SqlDataAccess.UpdateData(sql, data);
        }

        
    }
}