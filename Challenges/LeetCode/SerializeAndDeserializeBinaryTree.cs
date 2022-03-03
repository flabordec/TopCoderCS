using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.LeetCode.SerializeAndDeserializeBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
        public TreeNode(int x, TreeNode l, TreeNode r)
        {
            val = x;
            left = l;
            right = r;
        }
    }

    public class TreeNodeDto
    {
        public int Val { get; set; }
        public TreeNodeDto Left { get; set; }
        public TreeNodeDto Right { get; set; }

        public TreeNodeDto()
        {
        }

        public TreeNodeDto(TreeNode node)
        {
            Val = node.val;
            if (node.left != null)
                Left = new TreeNodeDto(node.left);
            if (node.right != null)
                Right = new TreeNodeDto(node.right);
        }


        public TreeNode ToTreeNode()
        {
            var node = new TreeNode(Val);
            if (Left != null)
            {
                node.left = Left.ToTreeNode();
            }
            if (Right != null)
            {
                node.right = Right.ToTreeNode();
            }
            return node;
        }
    }

    public class XmlCodec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return "null";

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TreeNodeDto));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, new TreeNodeDto(root));
                return writer.ToString();
            }
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == "null")
                return null;

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TreeNodeDto));

            // A FileStream is needed to read the XML document.
            var fs = new StringReader(data);
            // Declare an object variable of the type to be deserialized.
            TreeNodeDto root = (TreeNodeDto)serializer.Deserialize(fs);
            return root.ToTreeNode();
        }
    }

    public class JsonCodec
    {
        //// Encodes a tree to a single string.
        //public string serialize(TreeNode root)
        //{
        //    return System.Text.Json.JsonSerializer.Serialize(new TreeNodeDto(root));
        //}

        //// Decodes your encoded data to tree.
        //public TreeNode deserialize(string data)
        //{
        //    var nodeDto = (TreeNodeDto)System.Text.Json.JsonSerializer.Deserialize(data, typeof(TreeNodeDto));
        //    return nodeDto.ToTreeNode();
        //}
    }

    public class SerializeStructureCodec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return "";

            var structure = new List<string>();

            var queue = new Stack<TreeNode>();
            queue.Push(root);
            while (queue.Any())
            {
                var curr = queue.Pop();
                int val = curr.val;
                bool left = curr.left != null;
                bool right = curr.right != null;
                structure.Add($"{val} {(left ? 1 : 0)} {(right ? 1 : 0)}");
                if (curr.left != null)
                    queue.Push(curr.left);
                if (curr.right != null)
                    queue.Push(curr.right);
            }
            return string.Join(Environment.NewLine, structure);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == "")
                return null;

            using (var reader = new StringReader(data))
            {
                return deserialize(reader);
            }
        }

        public TreeNode deserialize(StringReader reader)
        {
            var curr = reader.ReadLine();
            string[] currData = curr.Split(' ');
            int val = int.Parse(currData[0]);
            int left = int.Parse(currData[1]);
            int right = int.Parse(currData[2]);

            var currNode = new TreeNode(val);
            if (right == 1)
            {
                currNode.right = deserialize(reader);
            }
            if (left == 1)
            {
                currNode.left = deserialize(reader);
            }
            return currNode;
        }
    }

    public class BitwiseCodec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return "";

            var structure = new StringBuilder();

            var queue = new Stack<TreeNode>();
            queue.Push(root);
            while (queue.Any())
            {
                var curr = queue.Pop();
                int val = curr.val + 1000;
                int left = curr.left != null ? 1 : 0;
                int right = curr.right != null ? 1 : 0;

                int toSerialize = val | (left << 12) | (right << 13);
                structure.AppendLine(toSerialize.ToString());
                if (curr.left != null)
                    queue.Push(curr.left);
                if (curr.right != null)
                    queue.Push(curr.right);
            }
            return structure.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == "")
                return null;

            using (var reader = new StringReader(data))
            {
                return deserialize(reader);
            }
        }

        public TreeNode deserialize(StringReader reader)
        {
            var curr = reader.ReadLine();
            int serialized = int.Parse(curr);
            int val = (serialized & ((1 << 12) - 1)) - 1000;
            bool left = (serialized & (1 << 12)) != 0;
            bool right = (serialized & (1 << 13)) != 0;

            var currNode = new TreeNode(val);
            if (right)
            {
                currNode.right = deserialize(reader);
            }
            if (left)
            {
                currNode.left = deserialize(reader);
            }
            return currNode;
        }
    }

    public class DeepEndCodec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return "";

            var structure = new List<char>();

            var queue = new Stack<TreeNode>();
            queue.Push(root);
            while (queue.Any())
            {
                var curr = queue.Pop();
                int val = curr.val + 1000;
                int left = curr.left != null ? 1 : 0;
                int right = curr.right != null ? 1 : 0;

                char toSerialize = (char)(val | (left << 12) | (right << 13));
                structure.Add(toSerialize);
                if (curr.left != null)
                    queue.Push(curr.left);
                if (curr.right != null)
                    queue.Push(curr.right);
            }

            var s = new string(structure.ToArray());
            return s;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == "")
                return null;

            var enumerable = GetChars(data);
            return deserialize(enumerable.GetEnumerator());
        }

        public IEnumerable<char> GetChars(string data)
        {
            using (var reader = new StringReader(data))
            {
                foreach (char c in data)
                {
                    yield return c;
                }
            }
        }

        public TreeNode deserialize(IEnumerator<char> ints)
        {
            ints.MoveNext();
            var serialized = ints.Current;
            int val = (serialized & ((1 << 12) - 1)) - 1000;
            bool left = (serialized & (1 << 12)) != 0;
            bool right = (serialized & (1 << 13)) != 0;

            var currNode = new TreeNode(val);
            if (right)
            {
                currNode.right = deserialize(ints);
            }
            if (left)
            {
                currNode.left = deserialize(ints);
            }
            return currNode;
        }
    }
}
