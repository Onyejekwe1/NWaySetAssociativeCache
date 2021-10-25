using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NWaySetAssocCache
{
    public class Set<K, V>
    {
        private int nItems;
        public ICacheAlgorithms<K, V> cacheAlgo;

        
        public Set(int nItems, Algorithm algorithm)
        {
            this.nItems = nItems;

            if (algorithm == Algorithm.LRU)
            {
                cacheAlgo = new LRU<K, V>(nItems);
            }

            else if (algorithm == Algorithm.MRU)
            {
                cacheAlgo = new MRU<K, V>(nItems);
            }
        }

        
        public Set(int nItems, ICacheAlgorithms<K, V> algorithm)
        {
            this.nItems = nItems;
            cacheAlgo = algorithm;
        }

        
        public V get(K key)
        {
            return cacheAlgo.get(key);
        }

        
        public void add(K newKey, V newValue)
        {
            cacheAlgo.set(newKey, newValue);
        }


        public bool contains(K key)
        {
            return cacheAlgo.contains(key);
        }
    }
}