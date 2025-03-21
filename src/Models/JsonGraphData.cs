using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGraph.src.Models
{
    public class JsonGraphData
    {
        public List<JsonUser> Users { get; set; }
    }

    public class JsonUser
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> friends { get; set; }
    }
}
