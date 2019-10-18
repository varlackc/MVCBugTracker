using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBuckTrackerDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
}