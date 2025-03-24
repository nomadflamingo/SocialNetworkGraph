using SocialNetworkGraph.src.Models;
using SocialNetworkGraph.src.SocialNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGraph.src.Iterators
{
    // Iterator for traversing users sorted by the number of friends in descending order
    public class UsersMostFriendsDescIterator : IIterator
    {
        private List<User> collection;
        private int currentIndex;

        public UsersMostFriendsDescIterator(NetworkGraph graph)
        {
            // Sorting users by the number of friends in descending order
            collection = [.. graph.Users.OrderByDescending(u => u.Friends.Count)];
            currentIndex = 0;
        }

        public bool HasMore()
        {
            return currentIndex < collection.Count;
        }

        public User GetNext()
        {
            if (!HasMore())
                throw new InvalidOperationException("No more elements");

            return collection[currentIndex++];
        }
    }
}
