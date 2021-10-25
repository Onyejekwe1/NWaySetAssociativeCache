using System.Collections;
using System.Collections.Generic;

namespace NWaySetAssocCache
{
    class LRU<K, V> : ICacheAlgorithms<K, V>
    {
        private Dictionary<K, DNode<K, V>> setData = new Dictionary<K, DNode<K, V>>();
        public DNode<K, V> head, tail = null;
        private int nItems;

        public LRU(int nItems)
        {
            this.nItems = nItems;
        }

      
        public Dictionary<K, DNode<K, V>> getSetData()
        {
            return setData;
        }

        
        public V get(K key)
        {
            if (setData.TryGetValue(key, out DNode<K, V> d))
            {
                if (head == null)
                {
                    head = d;
                    tail = d;
                }

                else
                {
                    head.previous = d;
                    d.next = head;
                    head = d;
                }
            }
            return d.val;
        }

       
        public void set(K key, V value)
        {
            DNode<K, V> dNew = new DNode<K, V>(key, value);
            remove(dNew);

            if (setData.Count >= nItems && tail != null)
            {
                remove(tail);
            }

            setData.Add(key, dNew);
            if (head == null)
            {
                head = dNew;
                tail = dNew;
            }

            else
            {
                head.previous = dNew;
                dNew.next = head;
                head = dNew;
            }
        }

        
        public void remove(DNode<K, V> d)
        {
            DNode<K, V> actualValue = d;
            setData.TryGetValue(d.key, out actualValue);
            
            setData.Remove(d.key);
            removeDNode(actualValue);
        }

        
        public void removeDNode(DNode<K, V> d)
        {
            if (d == null)
                return;
            if (d.previous != null)
                d.previous.next = d.next;
            if (d.next != null)
                d.next.previous = d.previous;
            if (d == tail)
                tail = d.previous;
            if (d == head)
                head = d.next;
        }

        
        public DNode<K, V> getHead()
        {
            return head;
        }

        
        public DNode<K, V> getTail()
        {
            return tail;
        }

        
        public bool contains(K key)
        {
            return setData.ContainsKey(key);
        }
    }
}
