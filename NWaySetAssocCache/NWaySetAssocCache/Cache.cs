using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Diagnostics;

namespace NWaySetAssocCache
{
    
    public class Cache<K, V>
    {
        public int cacheSize, nSets, nItems;
        private Algorithm algorithm = Algorithm.LRU;
        public List<Set<K, V>> cache = new List<Set<K, V>>();

     
        public Cache(int cacheSize, int nItems)
        {
            this.cacheSize = cacheSize;
            this.nItems = nItems;
            this.nSets = this.cacheSize / this.nItems;

            for (int i = 0; i < nSets; i++)
            {
                cache.Add(new Set<K, V>(nItems, algorithm));
            }
        }

     
        public Cache(int cacheSize, int nItems, Algorithm algorithm)
        {
            this.cacheSize = cacheSize;
            this.nItems = nItems;
            this.nSets = this.cacheSize / this.nItems;
            this.algorithm = algorithm;

            for (int i = 0; i < nSets; i++)
            {
                cache.Add(new Set<K, V>(nItems, this.algorithm));
            }
        }

      
        public Cache(int cacheSize, int nItems, ICacheAlgorithms<K, V> custAlgorithm)
        {
            this.cacheSize = cacheSize;
            this.nItems = nItems;
            this.nSets = this.cacheSize / this.nItems;

            for (int i = 0; i < nSets; i++)
            {
                cache.Add(new Set<K, V>(nItems, custAlgorithm));
            }
        }

      
        public List<Set<K, V>> getCache()
        {
            return cache;
        }

    
        public int getSetIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % nSets);
        }

    
        public V get(K key)
        {
            return cache[getSetIndex(key)].get(key);
        }

       
        public void put(K key, V value)
        {
            cache[getSetIndex(key)].add(key, value);
        }

  
        public bool contains(K key)
        {
            return cache[getSetIndex(key)].contains(key);
        }

        public void printCache()
        {
            for (int i = 0; i < nSets; i++)
            {
                foreach (var pair in cache[i].cacheAlgo.getSetData())
                {
                    Debug.WriteLine($"Cache Key: {pair.Key}, Value: {pair.Value.val}");
                }
                Debug.WriteLine("");
            }
        }
    }
}


