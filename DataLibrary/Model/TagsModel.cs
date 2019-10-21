using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    public class Tags
    {
       public int Id { get; set; }
       public string TagDescription { get; set; }
       public string TagType { get; set; }
       public DateTime TimeStamp { get; set; }
    }
}
