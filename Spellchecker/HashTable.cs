/**
 *
 * ICS 23 Summer 2004
 * Project #5: Lost for Words
 *
 * Implement your hash table here.  You are required to use the separate
 * chaining strategy that we discussed in lecture, meaning that collisions
 * are resolved by having each cell in the table be a linked list of all of
 * the strings that hashed to that cell.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Spellchecker
{
    class HashTable
    {
        /**
   * The constructor is given a table size (i.e. how big to make the array)
   * and a StringHasher, which is used to hash the strings.
   *
   * @param tableSize number of elements in the hash array
   *        hasher    Object that creates the hash code for a string
   * @see StringHasher
   */
        private int _tableSize;
        private IStringHasher _stringHasher;
        private readonly LinkedList<KeyValue>[] elements;

        public HashTable(int tableSize, IStringHasher stringHasher)
        {
            this._tableSize = tableSize;
            this._stringHasher = stringHasher;
            elements = new LinkedList<KeyValue>[_tableSize];
        }

        private int GetPositionByHash(int key)
        {
            // This function converts somehow the key to an integer between 0 and bucketSize
            // In Java, hashCode() is a function of Object, so all non-primitive types
            // can easily be converted to an integer.
            int position = key % _tableSize;
            return Math.Abs(position);
        }


        /**
       * Takes a string and adds it to the hash table, if it's not already
       * in the hash table.  If it is, this method has no effect.
       *
       * @param s String to add
       */
        public void Add(string word)
        {
            // Find out which position of the elements array to use:
            int key = _stringHasher.Hash(word);
            int position = GetPositionByHash(key);

            // If the key already exists, replace the old value with the new.
            // Make a new instance of the KeyValue class, fill it with the key, value parameters, then add it to the list.
            LinkedList<KeyValue> element = GetElementByPosition(position);
            if (IsKeyInHashMap(key, word, element, out KeyValue expectedItem))
            {
                expectedItem.value = word;
            }
            else
            {
                element.AddLast(expectedItem);
            }
        }

        private bool IsKeyInHashMap(int key, string value, LinkedList<KeyValue> element, out KeyValue expectedItem)
        {
            foreach (KeyValue item in element)
            {
                if (item.key.Equals(key))
                {
                    expectedItem = item;
                    return true;
                }
            }
            expectedItem = new KeyValue(key, value);
            return false;
        }

        private LinkedList<KeyValue> GetElementByPosition(int position)
        {
            LinkedList<KeyValue> linkedList = elements[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue>();
                elements[position] = linkedList;
            }

            return linkedList;
        }


        /**
      * Takes a string and returns true if that string appears in the
        * hash table, false otherwise.
      *
      * @param s String to look up
      */
        public bool Lookup(string word)
        {
            int key = _stringHasher.Hash(word);
            int position = GetPositionByHash(key);
            LinkedList<KeyValue> element = GetElementByPosition(position);
            foreach (KeyValue item in element)
            {
                if (item.key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        /**
       * Takes a string and removes it from the hash table, if it
       * appears in the hash table.  If it doesn't, this method has no effect.
       *
       * @param s String to remove
      */
        public void Remove(string word)
        {
            int key = _stringHasher.Hash(word);
            int position = GetPositionByHash(key);
            LinkedList<KeyValue> element = GetElementByPosition(position);
            bool itemFound = false;
            KeyValue foundItem = default(KeyValue);
            foreach (KeyValue item in element)
            {
                if (item.key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }

            if (itemFound)
            {
                element.Remove(foundItem);
            }
        }
    }

}
