using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Model;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class TagsProcessor
    {
        //method to create Tagss
        public static int CreateTags(int id, string tagDescription, string tagType, DateTime timeStamp)
        {
            //organize the data that will be added
            TagsModel data = new TagsModel
            {
                Id = id,
                TagDescription = tagDescription,
                TagType = tagType,
                TimeStamp = timeStamp
            };

            //create an sql query to create the new Tags
            string sql = @"insert into dbo.Tags (TagDescription, TagType, TimeStamp)
                            values (@TagDescription, @TagType, @TimeStamp);";

            //call the sqlDataAccess to create the new Tags
            return SqlDataAccess.SaveData(sql, data);
        }

        //Methodto load data
        public static List<TagsModel> LoadTags()
        {
            //create the sql command
            string sql = @"SELECT Id, TagDescription, TagType, TimeStamp
                            FROM dbo.Tags";
            //call the sql data access to load the Tags data
            return SqlDataAccess.LoadData<TagsModel>(sql);
        }

        //Methodto load data
        public static TagsModel LoadOneTag(int id)
        {
            //create the sql command
            string sql = @"SELECT Id, TagDescription, TagType
                            FROM dbo.Tags
                            WHERE Id = @id";
            //call the sql data access to load the Tags data
            return SqlDataAccess.LoadOne<TagsModel>(sql, id); // the <TagsModel> is used to specify the type
        }

        //Method to delete Tags
        public static void DeleteTags(int id)
        {
            //create the sql command
            string sql = @"DELETE FROM dbo.Tags WHERE Id = @id";

            //call the sql data access to delete the Tags entry
            SqlDataAccess.DeleteData(sql, id);
        }

        //Method to update Tags
        public static void UpdateTags(int id, string tagDescription, string tagType, DateTime timeStamp)
        {

            //organize the data that will be added
            TagsModel data = new TagsModel
            {
                Id = id,
                TagDescription = tagDescription,
                TagType = tagType,
                TimeStamp = timeStamp
            };

            //create the sql command
            string sql = @" UPDATE dbo.Tags
                            SET TagDescription = @TagDescription, TagType = @TagType, TimeStamp = @TimeStamp 
                            WHERE Id = @Id";

            //call the sql data access to delete the Tags entry
            SqlDataAccess.UpdateData(sql, data);
        }

    }
}
