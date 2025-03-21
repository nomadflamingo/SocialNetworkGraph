using SocialNetworkGraph.src.Iterators;
using SocialNetworkGraph.src.Models;
using SocialNetworkGraph.src.SocialNetwork;

class Program
{
    static void Main(string[] args)
    {
        // Creating the social network graph
        NetworkGraph graph = new NetworkGraph();

        // Creating users
        User alice = new User("Alice");
        User bob = new User("Bob");
        User charlie = new User("Charlie");
        User diana = new User("Diana");
        User eva = new User("Eva");

        // Adding users to the graph
        graph.AddUser(alice);
        graph.AddUser(bob);
        graph.AddUser(charlie);
        graph.AddUser(diana);
        graph.AddUser(eva);

        // Establishing friendships
        graph.AddFriendship(alice, bob);
        graph.AddFriendship(alice, charlie);
        graph.AddFriendship(bob, diana);
        graph.AddFriendship(charlie, diana);
        graph.AddFriendship(charlie, eva);

        // Using the default iterator
        Console.WriteLine("Users (arbitrary order):");
        Iterator defaultIterator = new UsersDefaultIterator(graph);
        while (defaultIterator.HasMore())
        {
            User user = defaultIterator.GetNext();
            Console.WriteLine($"{user.Name} (Friends: {user.Friends.Count})");
        }

        Console.WriteLine();

        // Using the iterator sorted by the number of friends
        Console.WriteLine("Users sorted by number of friends (descending):");
        Iterator sortedIterator = new UsersMostFriendsDescIterator(graph);
        while (sortedIterator.HasMore())
        {
            User user = sortedIterator.GetNext();
            Console.WriteLine($"{user.Name} (Friends: {user.Friends.Count})");
        }
    }
}