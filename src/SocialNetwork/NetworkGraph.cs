using SocialNetworkGraph.src.Iterators;
using SocialNetworkGraph.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGraph.src.SocialNetwork
{
    // Social network graph class that implements IterableCollection
    public class NetworkGraph : IIterableCollection
    {
        public List<User> Users { get; private set; }

        public NetworkGraph()
        {
            Users = new List<User>();
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void AddFriendship(User user1, User user2)
        {
            if (!user1.Friends.Contains(user2))
                user1.Friends.Add(user2);
            if (!user2.Friends.Contains(user1))
                user2.Friends.Add(user1);
        }

        // By default, create a default iterator
        public IIterator CreateIterator()
        {
            return new UsersDefaultIterator(this);
        }
    }

    

    
}
