using System;
using System.Collections.Generic;
using System.Text;

namespace Spellchecker
{
    class DegenerateStringHasher : IStringHasher
    {
        public int Hash(string s)
        {
            return 0;
        }
    }
}
