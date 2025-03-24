using SocialNetworkGraph.src.Iterators;
using SocialNetworkGraph.src.Models;
using SocialNetworkGraph.src.SocialNetwork;
using System.Text.Json;

class Program
{
    // Method to load social network graph from a JSON file
    public static NetworkGraph LoadGraphFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File {filePath} not found.");
        }

        string jsonString = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; 
        JsonGraphData data = JsonSerializer.Deserialize<JsonGraphData>(jsonString, options);

        NetworkGraph graph = new NetworkGraph();
        // Dictionary to store created users by id
        Dictionary<string, User> usersDictionary = new Dictionary<string, User>();

        // Creating users
        foreach (var jsonUser in data.Users)
        {
            User user = new(jsonUser.id, jsonUser.name);
            graph.AddUser(user);
            usersDictionary[jsonUser.id] = user;
        }

        // Establishing friendships
        foreach (var jsonUser in data.Users)
        {
            User currentUser = usersDictionary[jsonUser.id];
            foreach (var friendId in jsonUser.friends)
            {
                if (usersDictionary.TryGetValue(friendId, out User friend))
                {
                    // Establish mutual friendship
                    graph.AddFriendship(currentUser, friend);
                }
            }
        }

        return graph;
    }

    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 1)
            {
                throw new ArgumentException("No arguments provided. Please specify a path to \"UserGraph.json\" file");
            }
            // Load the graph from the JSON file
            NetworkGraph graph = LoadGraphFromJson(args[0]);

            // Using the default iterator
            Console.WriteLine("Users (arbitrary order):");
            IIterator defaultIterator = new UsersDefaultIterator(graph);
            while (defaultIterator.HasMore())
            {
                User user = defaultIterator.GetNext();
                Console.WriteLine($"{user.Name} (Friends: {user.Friends.Count})");
            }

            Console.WriteLine();

            // Using the sorted iterator (by number of friends in descending order)
            Console.WriteLine("Users sorted by number of friends (descending):");
            IIterator sortedIterator = new UsersMostFriendsDescIterator(graph);
            while (sortedIterator.HasMore())
            {
                User user = sortedIterator.GetNext();
                Console.WriteLine($"{user.Name} (Friends: {user.Friends.Count})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
