using System;
using System.Collections.Generic;
using System.Text;

namespace Spellchecker
{
    class LousyStringHasher : IStringHasher
    {
        public int Hash(string s)
        {
            int h = 0;

            for (int i = 0; i < s.Length; ++i)
            {
                h += s[i];
            }

            return h;
        }
    }
}
