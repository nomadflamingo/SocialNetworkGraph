using SocialNetworkGraph.src.Models;
using SocialNetworkGraph.src.SocialNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGraph.src.Iterators
{
    // Iterator for traversing users in an arbitrary order
    public class UsersDefaultIterator : IIterator
    {
        private List<User> collection;
        private int currentIndex;

        public UsersDefaultIterator(NetworkGraph graph)
        {
            // Using the order of adding users
            collection = graph.Users;
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
