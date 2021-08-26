using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public class ProjectManagementDbConfig
    {
        public string Database_name { get; set; }
        public string Tickets_Collection_name { get; set; }
        public string Projects_Collection_name { get; set; }
        public string Users_Collection_name { get; set; }
        public string Connection_String { get; set; }
    }
}
