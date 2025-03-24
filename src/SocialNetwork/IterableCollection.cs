using SocialNetworkGraph.src.Iterators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGraph.src.SocialNetwork
{
    // Iterable collection interface, which can create an iterator
    public interface IIterableCollection
    {
        IIterator CreateIterator();
    }
}
