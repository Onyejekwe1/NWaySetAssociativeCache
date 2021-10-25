namespace NWaySetAssocCache {   
    
public class DNode<K, V>
    {
        
        public K key;

      
        public V val;

      
        public DNode<K, V> previous;

     
        public DNode<K, V> next;

      
        public DNode(K key, V val)
        {
            this.key = key;
            this.val = val;
        }
    }
}