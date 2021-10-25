using System;
using System.Collections;
using System.Collections.Generic;

namespace NWaySetAssocCache
{
     public interface ICacheAlgorithms<K, V> {

         
        Dictionary<K, DNode<K, V>> getSetData();

        
        V get(K key);

      
        void set(K key, V value);

        
        void remove(DNode<K, V> d);

        
        void removeDNode(DNode<K, V> d);

       
        DNode<K, V> getHead();


        
        DNode<K, V> getTail();

       
        bool contains(K key);
    } 
}
