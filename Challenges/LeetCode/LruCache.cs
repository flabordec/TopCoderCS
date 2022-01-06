using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopCoderCS.LeetCode.LruCache
{
    public class LRUCache
    {
        class Node
        {
            public int Key { get; }
            public int Value { get; set; }
            public Node(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<Node>> _valuesByKey;
        private readonly LinkedList<Node> _values;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _values = new();
            _valuesByKey = new();
        }

        public int Get(int key)
        {
            try
            {
                if (_valuesByKey.TryGetValue(key, out LinkedListNode<Node>? node))
                {
                    _values.Remove(node);
                    _values.AddLast(node);
                    return node.Value.Value;
                }
                else
                {
                    return -1;
                }
            }
            finally
            {
                PrintList($"get {key}");
            }
        }

        public void Put(int key, int value)
        {
            try
            {
                if (!_valuesByKey.ContainsKey(key))
                {
                    // Need to add the value

                    // If we are over capacity remove the least recently used
                    if (_valuesByKey.Count >= _capacity)
                    {
                        var firstNode = _values.First;
                        _values.RemoveFirst();
                        _valuesByKey.Remove(firstNode.Value.Key);
                    }

                    var node = _values.AddLast(new Node(key, value));
                    _valuesByKey.Add(key, node);
                }
                else
                {
                    var node = _valuesByKey[key];
                    node.Value.Value = value;
                    _values.Remove(node);
                    _values.AddLast(node);
                }
            }
            finally
            {
                PrintList($"put {key},{value}");
            }
        }

        void PrintList(string operation)
        {
            //new string('-', 10).Dump();
            //operation.Dump();
            //_valuesByKey.Select(i => $"key {i.Key}, v = {i.Value.Value}").Dump();
            //_values.Dump();
            //new string('-', 10).Dump();
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
