using SocialNetworkGraph.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGraph.src.Iterators
{
    // Iterator interface
    public interface IIterator
    {
        bool HasMore();
        User GetNext();
    }
}
