using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_Model.Models
{
    public class MessagePublished
    {
        public string Message { get; set; }
    }
    public  class MessagePublishDto
    {
        public string Message { get; set; }

        public string Event { get; set; }
    }
}
