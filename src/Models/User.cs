using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGraph.src.Models
{
    // Class representing a user in the social network
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<User> Friends { get; set; }

        public User(string id, string name)
        {
            Id = id;
            Name = name;
            Friends = new List<User>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
