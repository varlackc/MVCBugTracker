﻿using System;
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
    }
}