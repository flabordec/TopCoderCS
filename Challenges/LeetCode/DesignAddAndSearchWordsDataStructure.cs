using Challenges.LeetCode.ConstructQuadTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.DesignAddAndSearchWordsDataStructure
{
    public class WordDictionary
    {
        public class Node
        {
            public Dictionary<char, Node> Children { get; } = new Dictionary<char, Node>();
            public char C { get; }
            public int Depth { get; }
            public bool Word { get; set; }


            public Node(char c, int depth)
            {
                C = c;
                Depth = depth;
            }
        }


        public Node Head { get; private set; }


        public WordDictionary()
        {
            Head = new Node('\0', 0);
        }

        public void AddWord(string word)
        {
            Node curr = Head;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (!curr.Children.ContainsKey(c))
                {
                    curr.Children.Add(c, new Node(c, i + 1));
                }
                curr = curr.Children[c];
                if (i == word.Length - 1)
                {
                    curr.Word = true;
                }
            }
        }

        public bool Search(string word)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(Head);
            while (queue.Any())
            {
                Node node = queue.Dequeue();
                if (word.Length == node.Depth)
                {
                    if (node.Word)
                        return true;
                }
                else
                {
                    char c = word[node.Depth];
                    if (c == '.')
                    {
                        foreach (Node child in node.Children.Values)
                            queue.Enqueue(child);
                    }
                    else if (node.Children.ContainsKey(c))
                    {
                        queue.Enqueue(node.Children[c]);
                    }
                }
            }
            return false;
        }
    }

    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     */
}
