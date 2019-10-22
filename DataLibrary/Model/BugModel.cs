using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    public class BugModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Status { get; set; }
        public int CreatedByUserId { get; set; }
        public string Details { get; set; }
        public string PriorityLevel { get; set; }
        public int UserAssignedId { get; set; }
    }
}
