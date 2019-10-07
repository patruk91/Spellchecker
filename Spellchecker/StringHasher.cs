using System;
using System.Collections.Generic;
using System.Text;

namespace Spellchecker
{
    public interface IStringHasher
    {
        /** 
       * Returns an integer that is a hash value for the given string s.
       * The integer can potentially be any value in the range of Java ints
       * (i.e. Integer.MIN_VALUE .. Integer.MAX_VALUE).
       *
       * @param s String to hash
       * @return hash code for the input string
       */

        int Hash(String s);
    }
}
