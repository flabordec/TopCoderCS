using System;
using System.CodeDom;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using TopCoderCS.Algorithms;
using System.Text;
using System.Xml;
using TopCoderCS.FiveThirtyEight;
using CodeForces;
using TopCoderCS;
using FluentAssertions;
using TopCoderCS.LeetCode;
using DistTreeNode = TopCoderCS.LeetCode.DistributeCoinsInBinaryTree.TreeNode;
using BtmpsTreeNode = TopCoderCS.LeetCode.BinaryTreeMaximumPathSum.TreeNode;
using DnarfTreeNode = TopCoderCS.LeetCode.DeleteNodesAndReturnForest.TreeNode;
using Xunit;

namespace TopCoderCSTest
{
    public class TopCoderUnitTest
    {
        [Fact]
        public void TestDNASingleMatcher()
        {
            DNASingleMatcher matcher = new DNASingleMatcher();
            int result;

            result = matcher.longestMatch("ABCDABD", "ABC ABCDAB ABCDABCDABDE");
            Assert.Equal(7, result);

            result = matcher.longestMatch("AAAAAAAAAA", "AAAAAAAAABAAAAAAAAAA");
            Assert.Equal(10, result);

            result = matcher.longestMatch("AAAAAAAAAAAAAAAAAAAAACCCGGGGGGGGGGGGG", "AAAACCCGGGGGGGGGGGGGGGGTTTTTTTTTGGGGGGGGGGGG");
            Assert.Equal(20, result);

            result = matcher.longestMatch("A", "A");
            Assert.Equal(1, result);

            result = matcher.longestMatch("", "");
            Assert.Equal(0, result);

            string w = new string('A', 49);
            string s = "B" + w;
            result = matcher.longestMatch(w, s);
            Assert.Equal(49, result);

            result = matcher.longestMatch(s, w);
            Assert.Equal(49, result);
        }

        [Fact]
        public void TestBridgeSort()
        {
            BridgeSort sort = new BridgeSort();
            string result;

            result = sort.sortedHand("DAS2S3S4S5S6S7S8S9STSJSQSK");
            Assert.Equal("DAS2S3S4S5S6S7S8S9STSJSQSK", result);
        }

        [Fact]
        public void TestSortishDiv2()
        {
            SortishDiv2 sort = new SortishDiv2();
            int result;

            result = sort.ways(5, new[] { 4, 0, 0, 2, 0 });
            Assert.Equal(2, result);

            result = sort.ways(2, new[] { 1, 3, 2 });
            Assert.Equal(1, result);

            result = sort.ways(2, new[] { 1, 2, 3 });
            Assert.Equal(0, result);
        }

        [Fact]
        public void WhiteHatTest()
        {
            WhiteHats hats = new WhiteHats();
            int result;
            int[] count;

            count = new[] { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
            result = hats.whiteNumber(count);
            Assert.Equal(-1, result);

            count = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 8 };
            result = hats.whiteNumber(count);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ColoringRectangleTest()
        {
            ColoringRectangle rect = new ColoringRectangle();
            int result;

            result = rect.chooseDisks(11, 3, new[] { 5, 5 }, new[] { 2, 5 });
            Assert.Equal(3, result);

            result = rect.chooseDisks(30, 5, new[] { 4, 10, 7, 8, 10 }, new[] { 5, 6, 11, 7, 5 });
            Assert.Equal(4, result);

            result = rect.chooseDisks(4, 4, new[] { 5 }, new[] { 6 });
            Assert.Equal(1, result);
        }

        [Fact]
        public void EllysNumberGuessingTest()
        {
            EllysNumberGuessing guessing = new EllysNumberGuessing();
            int result;

            result = guessing.getNumber(new[] { 1 }, new[] { 1000000001 });
            Assert.Equal(-2, result);
        }

        [Fact]
        public void MessageMessTest()
        {
            MessageMess mess = new MessageMess();
            string result;

            result = mess.restore(
                new[] { "A", "AA", "AAAAAAAAAAAAAAAAAAB" },
                "AAAAAAAAAAAAAAAAAAB");
            Assert.Equal("AAAAAAAAAAAAAAAAAAB", result);

            result = mess.restore(
                new[] { "A", "AA", "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB" },
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB");
            Assert.Equal("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB", result);

            result = mess.restore(
                new[] { "APPLE", "APPLET", "ET" }, "APPLET");
            Assert.Equal("APPLET", result);
        }

        [Fact]
        public void IDNumberVerificationTest()
        {
            IDNumberVerification ver = new IDNumberVerification();
            string result;

            result = ver.verify("542500201106110300", new[] {
                "510129", "330521", "152528", "632822", "211081",
                "532530", "340521", "440401", "230903", "130802",
                "542500", "621002"
            });
            Assert.Equal("Female", result);

            result = ver.verify("411222194802000278", new[] {
                "532930", "150821", "231085", "152501", "411222"
            });
            Assert.Equal("Invalid", result);

            result = ver.verify("411300191302280027", new[]  {
                "320701", "150823", "440903", "130900", "530324",
                "430511", "441825", "411300", "513233", "632122",
                "211303", "542324", "421127", "510115"
            });
            Assert.Equal("Female", result);
        }

        [Fact]
        public void LuckyCycleTest()
        {
            LuckyCycle cycle = new LuckyCycle();

            int[] result;

            result = cycle.getEdge(
                new[] { 1, 3, 2, 4 },
                new[] { 2, 2, 4, 5 },
                new[] { 4, 7, 4, 7 });
            Assert.Equal(new[] { 1, 5, 7 }, result);

            result = cycle.getEdge(
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                new[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
                new[] { 4, 4, 4, 4, 4, 4, 7, 7, 7, 7, 7, 7 });
            Assert.Equal(new[] { 1, 12, 7 }, result);

            result = cycle.getEdge(
                new[] { 2, 1, 5, 1, 1, 2, 1, 3, 5, 4, 4, 3 },
                new[] { 13, 2, 7, 5, 3, 12, 4, 11, 6, 9, 8, 10 },
                new[] { 4, 7, 7, 4, 7, 4, 4, 4, 7, 7, 7, 4 });
            Console.WriteLine(string.Join(",", result));
            Assert.Equal(new[] { 2, 10, 4 }, result);
        }

        [Fact]
        public void SilverDistanceTest()
        {
            SilverDistance dist = new SilverDistance();
            int result;

            result = dist.minSteps(-732513, -542725, 58853, -776738);
            Assert.Equal(791367, result);
        }

        [Fact]
        public void PriorityQueueTest()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();

            queue.IsEmpty.Should().BeTrue();

            int numElements = 1000;
            int[] values = new int[numElements];
            for (int i = 0; i < values.Length; i++)
                values[i] = i;

            Random rng = new Random();
            int n = values.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = values[k];
                values[k] = values[n];
                values[n] = value;
            }

            queue.AddAll(values);

            int nextValue = 0;
            while (!queue.IsEmpty)
            {
                Assert.Equal(nextValue, queue.DequeueMin());
                nextValue++;
            }
        }

        [Fact]
        public void PriorityQueueComparableTest()
        {
            PriorityQueue<IntWrapper> queue = new PriorityQueue<IntWrapper>();

            queue.IsEmpty.Should().BeTrue();

            int numElements = 1000;
            IntWrapper[] values = new IntWrapper[numElements];
            for (int i = 0; i < values.Length; i++)
                values[i] = new IntWrapper(i);

            Random rng = new Random();
            int n = values.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                IntWrapper value = values[k];
                values[k] = values[n];
                values[n] = value;
            }

            queue.AddAll(values);

            int nextValue = values.Length - 1;
            while (!queue.IsEmpty)
            {
                Assert.Equal(nextValue, queue.DequeueMin().Value);
                nextValue--;
            }
        }

        [Fact]
        public void PriorityQueueDupes()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Enqueue(1);

            int count = 0;
            while (!queue.IsEmpty)
            {
                Assert.Equal(1, queue.DequeueMin());
                count++;
            }
            Assert.Equal(4, count);
        }

        [Fact]
        public void PriorityQueueMap()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);
            Assert.Equal(1, queue.DequeueMin());
            queue.Enqueue(5);
            queue.Enqueue(4);
            Assert.Equal(2, queue.DequeueMin());
            queue.Enqueue(1);
            Assert.Equal(1, queue.DequeueMin());
            Assert.Equal(3, queue.DequeueMin());
            Assert.Equal(4, queue.DequeueMin());
            Assert.Equal(5, queue.DequeueMin());
        }

        class IntWrapper : IComparable<IntWrapper>
        {
            public int Value { get; set; }
            public IntWrapper(int value)
            {
                this.Value = value;
            }

            public int CompareTo(IntWrapper other)
            {
                return other.Value - this.Value;
            }
        }

        [Fact]
        public void TheFansAndMeetingsDivTwoTest()
        {
            TheFansAndMeetingsDivTwo meets = new TheFansAndMeetingsDivTwo();
            double result = 0;
            result = meets.find(new[] { 1 }, new[] { 3 }, new[] { 1 }, new[] { 1 });
            Assert.Equal(0.333333333333333333333333333333333333333333, result);


            result = meets.find(
                new[] { 5, 7, 7, 1, 6, 1, 1 },
                new[] { 8, 9, 7, 3, 9, 5, 3 },
                new[] { 9, 12, 10, 14, 50, 9, 10 },
                new[] { 9, 13, 50, 15, 50, 12, 11 });
            Assert.Equal(0.014880952380952378, result);

            result = meets.find(
                new[]{1, 26, 15, 11, 29, 23, 19, 11, 23, 1, 37, 17, 40, 13, 22, 36, 1, 10, 23,
                    1, 35, 27, 5, 1, 21, 1, 43, 2, 31, 14, 29, 11, 26, 23, 1, 16, 20, 5, 17, 35,
                    35, 17, 16, 29, 13, 19, 6, 25, 29, 11},
                new[] {7, 38, 23, 37, 34, 27, 35, 13, 31, 7, 41, 49, 46, 29, 31, 47, 35, 10,
                    49, 35, 39, 31, 13, 10, 48, 36, 47, 50, 45, 35, 31, 19, 49, 30, 1, 40,
                    39, 20, 43, 48, 36, 21, 19, 41, 15, 47, 41, 36, 37, 40},
                new[]{19, 2, 7, 23, 34, 2, 34, 29, 11, 15, 17, 7, 13, 29, 15, 13, 31, 6, 13, 11, 1, 3,
                    35, 5, 33, 15, 26, 1, 23, 3, 17, 33, 5, 33, 8, 21, 25, 7, 1, 14, 3, 15,
                    6, 19, 1, 23, 19, 1, 17, 11},
                new[]{25, 41, 45, 49, 41, 5, 44, 31, 31, 18, 49, 27, 21, 46, 41, 21, 38, 50, 31,
                    41, 46, 17, 48, 35, 45, 45, 29, 43, 39, 47, 21, 39, 39, 39, 19, 21, 27, 26, 5,
                    24, 31, 37, 47, 23, 20, 39, 29, 29, 49, 37}
                );
            Assert.Equal(0.022860243235238876, result);
        }

        [Fact]
        public void PotatoGameTest()
        {
            PotatoGame game = new PotatoGame();
            string result;
            result = game.theWinner(200);
            Assert.Equal("Hanako", result);
            result = game.theWinner(1000000000);
            Assert.Equal("Hanako", result);
        }

        [Fact]
        public void PalindromeDecodingTest()
        {
            PalindromeDecoding dec = new PalindromeDecoding();
            string result;
            //result = dec.decode("ab", new[] { 0 }, new[] { 2 });
            //Assert.Equal("abba", result);

            result = dec.decode("abcd", new[] { 2 }, new[] { 2 });
            Assert.Equal("abcddc", result);

            result = dec.decode("Misip", new[] { 2, 3, 1, 7 }, new[] { 1, 1, 2, 2 });
            Assert.Equal("Mississippi", result);
        }

        [Fact]
        public void ProductBundlingTest()
        {
            ProductBundling bundle = new ProductBundling();
            int result;
            result = bundle.howManyBundles(new[] { "11100" });
            Assert.Equal(2, result);

            result = bundle.howManyBundles(new[] {
                "1100000000",
                "1100000000",
                "0011000000",
                "0011000000",
                "0000110000",
                "0000110000",
                "0000001100",
                "0000001100",
                "0000000011",
                "0000000011"});
            Assert.Equal(5, result);

            result = bundle.howManyBundles(new[] {
                "1010101010101010",
                "1100110011001100",
                "1111000011110000",
                "1111111100000000",
                "1111111111111111" });
            Assert.Equal(16, result);

            result = bundle.howManyBundles(new[] {
                "10101010101010101010101010101010101010101010101010",
                "11001100110011001100110011001100110011001100110011",
                "11110000111100001111000011110000111100001111000011",
                "11111111000000001111111100000000111111110000000011",
                "11111111111111110000000000000000111111111111111100",
                "11111111111111111111111111111111000000000000000000",
                "11111111111111111111111111111111111111111111111111",
                "11111111111111111111111111111111111111111111111111" });
            Assert.Equal(50, result);

            result = bundle.howManyBundles(new[] {
                "10101010101010101010101010101010101010101010101010",
                "11001100110011001100110011001100110011001100110011",
                "11110000111100001111000011110000111100001111000011",
                "11111111000000001111111100000000111111110000000011", "11111111111111110000000000000000111111111111111100", "11111111111111111111111111111111000000000000000000", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111", "11111111111111111111111111111111111111111111111111"});
            Assert.Equal(50, result);
        }

        //[Fact]
        //public void SubdividedSlimesTest()
        //{
        //	SubdividedSlimes slimes = new SubdividedSlimes();
        //	int result;

        //	//result = slimes.needCut(3, 2);
        //	//Assert.Equal(result, 1);

        //	//result = slimes.needCut(3, 3);
        //	//Assert.Equal(result, 2);

        //	//result = slimes.needCut(3, 4);
        //	//Assert.Equal(result, -1);

        //	result = slimes.needCut(765, 271828);
        //	Assert.Equal(result, 14);
        //}

        [Fact]
        public void BearDartsDiv2Test()
        {
            BearDartsDiv2 bear = new BearDartsDiv2();
            long result;

            result = bear.count(new[] { 10, 2, 2, 7, 40, 160 });
            Assert.Equal(2, result);

            result = bear.count(new[] {
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
            });
            Assert.Equal(2573031125, result);

            Stopwatch stop = new Stopwatch();
            stop.Start();
            result = bear.count(new[] {
                2, 4, 2, 8, 4, 1, 1, 1, 1, 1, 4, 8, 1, 2, 2, 2, 1, 2, 1, 4, 2, 1, 8, 2, 2, 1, 4, 4,
                8, 1, 1, 1, 2, 4, 8, 1, 2, 2, 1, 2, 2, 1, 1, 2, 2, 4, 4, 1, 8, 8, 4, 2, 1, 2, 8, 2,
                4, 2, 1, 2, 2, 1, 2, 1, 4, 1, 1, 1, 2, 2, 2, 1, 1, 8, 2, 1, 1, 1, 2, 8, 8, 2, 1, 2,
                8, 8, 8, 1, 1, 8, 4, 4, 1, 1, 2, 4, 1, 2, 1, 1, 8, 2, 2, 4, 1, 4, 1, 1, 4, 2, 1, 1,
                4, 8, 8, 2, 8, 8, 1, 1, 4, 2, 2, 4, 2, 8, 2, 1, 1, 1, 4, 1, 2, 8, 8, 2, 2, 2, 2, 1,
                1, 2, 1, 4, 2, 1, 1, 1, 8, 8, 1, 2, 1, 4, 1, 8, 4, 2, 8, 1, 2, 1, 1, 1, 1, 2, 2, 2,
                1, 1, 2, 1, 1, 4, 4, 4, 4, 8, 4, 2, 4, 2, 1, 1, 1, 1, 4, 2, 1, 1, 2, 4, 4, 1, 4, 4,
                2, 8, 1, 2, 4, 2, 2, 1, 1, 2, 2, 4, 1, 8, 2, 1, 2, 1, 1, 2, 1, 4, 1, 2, 1, 1, 1, 2,
                1, 4, 1, 8, 2, 1, 1, 1, 2, 2, 1, 4, 1, 2, 1, 1, 1, 4, 1, 2, 2, 1, 1, 4, 2, 4, 1, 2,
                1, 8, 4, 1, 2, 8, 2, 1, 8, 8, 1, 2, 2, 8, 8, 1, 1, 1, 2, 2, 2, 2, 8, 1, 2, 2, 4, 8,
                1, 4, 1, 1, 1, 8, 4, 4, 2, 2, 4, 1, 1, 2, 1, 2, 1, 1, 4, 2, 1, 1, 8, 2, 4, 2, 2, 8,
                1, 1, 2, 1, 2, 2, 1, 8, 1, 4, 2, 1, 8, 1, 1, 1, 1, 2, 1, 2, 2, 1, 1, 4, 1, 2, 8, 4,
                8, 1, 1, 1, 2, 2, 8, 4, 1, 2, 4, 1, 1, 1, 1, 1, 1, 2, 4, 2, 1, 1, 4, 2, 8, 2, 1, 8,
                8, 8, 1, 4, 1, 4, 2, 2, 1, 2, 1, 2, 4, 4, 1, 8, 4, 2, 4, 8, 8, 1, 1, 8, 1, 8, 1, 1,
                1, 1, 8, 1, 4, 1, 8, 1, 4, 1, 2, 1, 2, 2, 1, 1, 1, 2, 8, 1, 2, 1, 4, 1, 2, 4, 1, 2,
                1, 8, 1, 2, 4, 1, 1, 2, 1, 1, 2, 1, 2, 8, 4, 4, 2, 1, 1, 4, 1, 2, 2, 2, 1, 1, 4, 1,
                4, 2, 2, 1, 2, 1, 1, 1, 1, 2, 4, 2, 2, 2, 1, 1, 1, 1, 4, 2, 1, 2, 1, 8, 1, 2, 2, 4,
                8, 8, 1, 4, 1, 4, 2, 4, 4, 2, 1, 4, 1, 2, 1, 4, 2, 1, 2, 4, 1, 8, 1, 1
            });
            Assert.Equal(321762079, result);
            Console.WriteLine(stop.ElapsedMilliseconds);
        }

        [Fact]
        public void Tdetectived2Test()
        {
            Tdetectived2 detect = new Tdetectived2();
            int result;

            result = detect.reveal(new[] { "000", "000", "000" });
            Assert.Equal(3, result);

            result = detect.reveal(new[] { "0224", "2011", "2104", "4140" });
            Assert.Equal(10, result);

            result = detect.reveal(new[] { "0886", "8086", "8801", "6610" });
            Assert.Equal(12, result);

            result = detect.reveal(new[] { "064675511", "603525154", "430262731", "652030511", "726302420", "552020464", "517544052", "153126500", "141104200" });
            Assert.Equal(170, result);

            result = detect.reveal(new[] { "003211023320010", "000102333022113", "300122011213031", "211031033003103", "102302020203333", "122120201323311", "030002013013032", "231320102030311", "331301320202202", "302023002013100", "221002130103000", "023333302330330", "010133032103021", "113031310003200", "031331212000100" });
            Assert.Equal(238, result);
        }

        [Fact]
        public void CandyGameTest()
        {
            CandyGame candy = new CandyGame();
            int result;

            result = candy.maximumCandy(new[] { "NYN", "YNY", "NYN" }, 1);
            Assert.Equal(2, result);

            result = candy.maximumCandy(new[] { "NYYY", "YNNN", "YNNN", "YNNN" }, 1);
            Assert.Equal(4, result);

            result = candy.maximumCandy(new[] { "NYNNN", "YNYNN", "NYNYN", "NNYNN", "NNNNN" }, 3);
            Assert.Equal(-1, result);

            result = candy.maximumCandy(new[] { "NYNNNN", "YNYYNN", "NYNNYN", "NYNNNY", "NNYNNN", "NNNYNN" }, 0);
            Assert.Equal(10, result);

            result = candy.maximumCandy(new[] { "NYNNNNN", "YNYYNNN", "NYNNYNN", "NYNNNYY", "NNYNNNN", "NNNYNNN", "NNNYNNN" }, 0);
            Assert.Equal(11, result);
        }

        [Fact]
        public void PlaneGameTest()
        {
            PlaneGame plane = new PlaneGame();
            int result;

            result = plane.bestShot(Enumerable.Range(1, 50).ToArray(), Enumerable.Range(1, 50).ToArray());
            Assert.Equal(50, result);

            // WA
            // result = plane.bestShot(new[] { 0, 9788, 19509 }, new[] { 0, 14, 30 });
            // Assert.Equal(3, result);
        }

        [Fact]
        public void TileCuttingTest()
        {
            int result;
            TileCutting tiles = new TileCutting();
            result = tiles.cuts(new[] {
                ".x",
                "x."
            });
            Assert.Equal(3, result);

            result = tiles.cuts(new[] {
                "x.",
                ".x"
            });
            Assert.Equal(3, result);

            result = tiles.cuts(new[] {
                "xx",
                ".."
            });
            Assert.Equal(2, result);

            result = tiles.cuts(new[] {
                "..",
                "xx"
            });
            Assert.Equal(2, result);

            result = tiles.cuts(new[] {
                "x.",
                "x."
            });
            Assert.Equal(2, result);

            result = tiles.cuts(new[] {
                ".x",
                ".x"
            });
            Assert.Equal(2, result);

            result = tiles.cuts(new[] {
                "xxxx",
                "x..x",
                "x..x",
                "xxxx"
            });
            Assert.Equal(4, result);

            result = tiles.cuts(new[] {
                "x..x...x...x..x....x",
                ".x..x.xxx....xx..x..",
                "..x...x..x...xxx....",
                "x....x.....xx..xx...",
                "..x.x...x..x........",
                ".x...xx.xx...xxx...x",
                "x..x.x......xx.x....",
                "...xxx.....x.x..xx.."
            });
            Assert.Equal(44, result);
        }

        [Fact]
        public void MergeStringsTest()
        {
            FourStrings strings = new FourStrings();
            string mergedResult;
            int result;

            mergedResult = strings.MergeStringsLeft("coder", "top");
            Assert.Equal("topcoder", mergedResult);

            mergedResult = strings.MergeStringsLeft("opco", "top");
            Assert.Equal("topco", mergedResult);

            mergedResult = strings.MergeStringsRight("top", "coder");
            Assert.Equal("topcoder", mergedResult);

            mergedResult = strings.MergeStringsRight("top", "opco");
            Assert.Equal("topco", mergedResult);


            result = strings.shortestLength("top", "coder", "opco", "pcode");
            Assert.Equal(8, result);

            result = strings.shortestLength("thereare", "arelots", "lotsof", "ofcases");
            Assert.Equal(19, result);

            result = strings.shortestLength("aaabab", "ba", "bbabab", "bbbbab");
            Assert.Equal(13, result);
        }


        [Fact]
        public void UnderprimesTest()
        {
            Underprimes under = new Underprimes();
            int result;

            result = under.howMany(100, 150);
            Assert.Equal(32, result);

            result = under.howMany(2, 100000);
            Assert.Equal(63255, result);
        }

        [Fact]
        public void ParenthesesDiv2MediumTest()
        {
            ParenthesesDiv2Medium par = new ParenthesesDiv2Medium();
            int[] arr = par.correct(")()(");
        }

        [Fact]
        public void EllysSocksTest()
        {
            EllysSocks socks = new EllysSocks();
            int result;

            result = socks.getDifference(new[] { 42, 37, 84, 36, 41, 42 }, 2);
            Assert.Equal(1, result);

            result = socks.getDifference(new[] { 42, 37, 84, 36, 41, 42 }, 3);
            Assert.Equal(42, result);

            result = socks.getDifference(new[] { 17, 3, 13, 3, 2, 17, 11, 5, 5, 7, 11, 7, 13, 19 }, 7);
            Assert.Equal(4, result);

            result = socks.getDifference(
                new[] {
                    795755685, 581869303, 404620563, 708632712, 545404205, 133711906, 372047868, 949333986, 579004999, 323567404,
                    418932836, 944672732, 196140741, 809094427, 946129058, 30574577, 182506778, 15198493, 150802600, 138749191,
                    676943010, 177512688, 126303054, 81133258, 183966551, 471852627, 84672537, 867128744, 857788837, 275731772,
                    609397213, 20544910, 811450930, 483031419, 361913171, 547204602, 892462744, 522136404, 173978710, 131752569,
                    478582453, 867889991, 153380496, 551745921, 647984700, 910208077, 283496852, 368550363, 379821990, 712568903,
                    40498239, 113911604, 103237637, 39073007, 684602223, 812852787, 479711181, 746745228, 735241235, 296707007,
                    262522458, 870676136, 136721027, 359573809, 189375153, 547914047, 198304613, 640439653, 417177802, 25475624,
                    758242872, 764919655, 310701088, 537655880, 361931892, 14685971, 213794688, 107063881, 147944789, 444803289,
                    884392679, 540721924, 638781100, 902841101, 7097711, 219972874, 879609715, 156513984, 802611721, 755486970,
                    103522060, 967048445, 913778155, 94092596, 519074050, 884870761, 248268555, 339840186, 53612697, 826647953},
                    42);
        }

        [Fact]
        public void DNAStringTest()
        {
            DNAString dna = new DNAString();
            int result;

            result = dna.minChanges(3, new[] { "ATAGATA" });
            Assert.Equal(1, result);

            result = dna.minChanges(12, new[] { "ACGTATAGCATGACA", "ACAGATATTATG", "ACAGATGTAGCAGTA", "ACCA", "GAC" });
            Assert.Equal(20, result);

            result = dna.minChanges(2500, new[] { "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT", "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT" });
            Assert.Equal(0, result);

            result = dna.minChanges(2300, new[] { "CTGACAGGGACCCTCTTGTATAGCAGCAGTTGTGCATTTGTTGCCACTCA", "TAGCCTTCCGATGGAGAGAAGCGCGGGCCACTAGAAGATAATGTCGGGCC", "CTTGAGCGCGCCAAGCCCCAGGCATTTGTAGGCAGGTTTCCTCTCCCGCA", "GGGGCAATGTGTACATTCGGTAGAACATAACGCTGGAATTACATTCGCCG", "CATTACTAGTAAACCGTCCTTTGTAAGGAAGCCGCCAGGAGTGCGTTAAT", "GGATAGGGTCCGAACGGTCTCAACTAAGTCCACCTTGCGCAGCCAACGCC", "ACAACTGCCACAGCTTTATCCCGCCTCAGCAGTGGCATGTCTCCAAACCA", "CGGGCAAGCCTGCGATATCAGGCCGCGGAGTCGTGCCGGAGGATCGTCGC", "CGTAACGACTGTTCTATACCTACCCTAGGGAATACGGGTCTAATCGAGTA", "TCAGGGTGGCTAGATAATAGGCGTATTGACGGCTCGCTCATAGGTACCTC", "AAGAGGTTTTCAGAATATGCACGGCTCAGTTACACACTCGAACACATATA", "AGTCAAGCGCCTCCAGCACACCTCCCTAATCGAGGACCATTTTTTATGTG", "GTCTTCCGGGCTGGTCCGCGACACGACACCTTGGTCAGATACACTAGGCA", "ATCTAACGCCGCCGTAAGTTACACTCTAACCACTTCCACGCCTTCAACAT", "GATATGGGTTATCTGTGTCAAGTCTAGAGCTTTGGTAATACTCAGGCGTC", "CACACAGGCTAAATGTCTTTACTCATTATCCTCCAGAACGGAGGCTGAAT", "ATTGCGCCAATTCGATGGTCTCCAATAGTCGAAAGGCCACGATCCAACGG", "AAAGGTTTGCCTCGGGGGCCAAAGCGTGTAAACCCAAAGGGTCATATCGC", "CAGCGAGTTCGTATTTCCAACCGCGGCGCGACTCTCCCGATACTTTGTAA", "GGCGAGATTCTTGGCACAACCACGTTAAGATCGTCTCTACACGGCCGAAC", "TATACCGAAGGTCAAGCGCACTGCACCGTTGAGGTTCAAGGCAAGCAAGC", "AATATGTGGATACTGTGGTGGAGCGGGACCTGGTGGAAGTAAGATTGTAC", "GCATAGCCGCAAATGTTACGGGGGACGTTTCTTAGGCACGCACCGTGCCG", "CACGCAGATCTCCACTAGAACCACAGAGAACAGTTTCCTCCCAGTCAGCG", "CATCCCAAGTAGGGGTGAGTTAGAGTAGACGTCCCTGGTGCAATAAGTAT", "ATTGAGTGCGGATATAAGTCTGTATATGGAATGAGCAGCCTGCAATATAT", "GTCATTACACGCTCCGATGCAGCCCTCCGAAGCGCCGGACGTCTTTCTGG", "GGGTGATGCATGGGAAGCGTTCGCCGGGGCTATGCTCTGGCAGAAACAGT", "GTCAGAACAGAATATAACTCTCCAAATTGCTAGGCTAGTAATTCTGACAT", "AGACCCACTAGCGTTCCCACGAGGGTGCTCAAAATACTGTAGGTTCAGTT", "AAACGCGAATATAAGATAACGGCGCTGCCTAAGGTGCGTCCTGACTACCA", "ATCGATTCGATGAGCCCAGTCAGCTTCCAAATTGGTTGACCCCCGGGATT", "CGTCGCCCGGTAATGGGCTTCTCGTTAGATCGGGTAGACCATCTGTCGAC", "ACCTTAGTAGTGGCGTTACATAGGGCCTTTACCCCGGCCTTGTCACCAAC", "TGTCAACACTGCGGAGTGACAGCACACGCTGAAGACGGTCGTAGTCTCGA", "TTTAGTATGTATACCCTACGAGCAGCGATCTCCATCCCCGTCCAATCCAC", "AGATCAAATCATATAATCTTTCATCGATAATCTATAGACATGCGAACGAA", "AAGCAGGCCATAATTGCACATACCAATGTGCGAAGACGGGTTCTTATTCT", "CCACCCTGCTAGGATCAACGCTGTGATATGAGTCCGTCTGTGGTTACATT", "CGGCCCTTCGTCGCCGGAATAACTGACTCATTCTCCCCGTCGATTTCGTG", "AGGTCGAGTGATCGACGCTGGGTCCAGCGTTCCGAACGAACTGCAGATGT", "CAATTTTACGCATCCTATACCAAATTAGTGACTCGGATCTGTCCTCTCAT", "TTAGTTTCCGGGACTGTTTGTCGTGCTGTCCAAGGTGGCGACCGTGTGAG", "ATCTCTCGTTGCTTGTATGAGTACTGTTATTATTATGTATTCTGCAGGCC", "CCGTGCGTTGGCGTAGTGTGGAGTTACGGTAGGCCTCCACAGCCCAGTGC", "GCAGCGAACGCTACGTTTCGGTATCTGATGGGATATACAAGATAGTTCTG", "GGAGGCCGACCAGTCCCATCTGATCAGAATTACGGCTATTACCCGGCGTC", "GGTCTTGCATGTCTCGTCCACCTGGCTCTTTTATGAGCGCAATGGAGTCG", "TCACGGGGATCTAAGCTCGCGTCACACCCTGTGATGCATTCTCTGCATTT", "TGCGCTACAGCATAATACGTGGTTATGTGGCGCCTAGATGCTGAAGATCG" });
            Assert.Equal(133, result);

            result = dna.minChanges(3, new[] { "TCGTCGATGATGACTACT" });
            Assert.Equal(6, result);
        }

        private static Stopwatch stopwatch = new Stopwatch();

        [Fact]
        public void DNAStringBenchmark()
        {
            DNAString dna = new DNAString();
            int resultBase;

            var results = new Dictionary<string, List<long>>();
            results.Add("base", new List<long>());
            results.Add("magus", new List<long>());
            results.Add("oscar", new List<long>());

            bool keepTestingMagus = true;
            bool keepTestingOscar = true;

            int max = 4000;
            int step = 200;

            Random rand = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = step; i <= max; i += step)
            {
                for (int j = 0; j < step; j++)
                {
                    char next;
                    switch (rand.Next(4))
                    {
                        case 0:
                            next = 'A';
                            break;
                        case 1:
                            next = 'C';
                            break;
                        case 2:
                            next = 'G';
                            break;
                        case 3:
                            next = 'T';
                            break;
                        default:
                            next = '\0';
                            Debug.Fail("Unexpected number");
                            break;
                    }
                    builder.Append(next);
                }

                string str = builder.ToString();
                stopwatch.Restart();
                resultBase = dna.minChanges(i, new[] { str });
                stopwatch.Stop();
                results["base"].Add(stopwatch.ElapsedMilliseconds);

                if (keepTestingMagus)
                    keepTestingMagus = RunTest("magus", dna, resultBase, results, () => dna.minChangesMagus(i, new[] { str }));

                if (keepTestingOscar)
                    keepTestingOscar = RunTest("oscar", dna, resultBase, results, () => dna.minChangesOscar(i, new[] { str }));
            }

            for (int i = step; i <= max; i += step)
                Console.Write(",{0}", i);
            Console.WriteLine();
            foreach (string name in results.Keys)
            {
                Console.WriteLine("{0},{1}", name, string.Join(",", results[name]));
            }
        }

        private static bool RunTest(
            string name,
            DNAString dna,
            int resultBase,
            Dictionary<string, List<long>> results,
            Func<int> action)
        {
            try
            {
                stopwatch.Restart();

                Task<int> task = Task<int>.Run(action);
                bool finished = task.Wait(2000);
                int result = task.Result;

                stopwatch.Stop();

                if (!finished)
                    return false;

                if (resultBase != result)
                    return false;

                results[name].Add(stopwatch.ElapsedMilliseconds);

                return true;
            }
            catch
            {
                return false;
            }
        }

        [Fact]
        public void Sunnygraphs2Test()
        {
            Sunnygraphs2 sun = new Sunnygraphs2();
            long result = sun.count(new[] { 1, 0, 0, 2, 1 });
            Assert.Equal(25, result);
        }

        [Fact]
        public void DubsTest()
        {
            Dubs dubs = new Dubs();
            long result;

            result = dubs.count(0L, 1565L);
            Assert.Equal(155, result);

            result = dubs.count(0L, 1111L);
            Assert.Equal(111, result);

            result = dubs.count(1111111L, 111111111L);
            Assert.Equal(11000001, result);

            //result = dubs.count(91750002841L, 91751522033L);
            //Assert.Equal(151920, result);
        }

        [Fact]
        public void PartSorting()
        {
            PartSorting sort = new PartSorting();

            int[] result;

            result = sort.process(new[] { 3, 2, 1 }, 20);
            Assert.Equal(new[] { 3, 2, 1 }, result);

            result = sort.process(new[] { 19, 20, 17, 18, 15, 16, 13, 14, 11, 12 }, 5);
            Assert.Equal(new[] { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11 }, result);

            result = sort.process(
                new[]
                {
                    89, 103, 107, 90, 97, 85, 12, 29, 71, 10, 94, 18, 15, 36, 55, 13, 77, 86, 5,
                    4, 48, 47, 3, 43, 25, 41, 74, 119, 8, 113, 42, 98, 14, 80, 37, 110, 11, 115,
                    87, 21, 127, 28, 124, 61, 102, 39, 70, 38, 81, 73
                },
                20);
            Assert.Equal(
                new[]
                {
                    107, 103, 97, 94, 90, 89, 85, 71, 36, 12, 29, 10, 18, 15, 55, 13, 77, 86, 5,
                    4, 48, 47, 3, 43, 25, 41, 74, 119, 8, 113, 42, 98, 14, 80, 37, 110, 11, 115,
                    87, 21, 127, 28, 124, 61, 102, 39, 70, 38, 81, 73
                },
                result);
        }

        [Fact]
        public void TestPermutations()
        {
            string[] expected = new[]
            {
                "ABCD", "BACD", "CABD", "ACBD", "ABCD", "BACD", "DACB", "ADCB", "CDAB", "DCAB",
                "DACB", "ADCB", "ABCD", "BACD", "CABD", "ACBD", "ABCD", "BACD", "BADC", "ABDC",
                "DBAC", "BDAC", "BADC", "ABDC"
            };

            {
                IEnumerable<char[]> results = HeapPermutations.Permutations("ABCD".ToCharArray());
                IEnumerable<string> actual = results.Select(c => new string(c));
                Console.WriteLine(string.Join("\n", actual));
                actual.ToArray().Should().BeEquivalentTo(expected);
            }

            {
                IEnumerable<char[]> results = HeapPermutations.EnumeratePermutations("ABCD".ToCharArray());
                IEnumerable<string> actual = results.Select(c => new string(c));
                actual.ToArray().Should().BeEquivalentTo(expected);
            }
        }

        [Fact]
        public void RopestringTest()
        {
            Ropestring rope = new Ropestring();

            int n = 500000;
            Random rand = new Random();
            StringBuilder builder = new StringBuilder(n);
            for (int i = 0; i < n; i++)
            {
                if (rand.Next(100) > 75)
                    builder.Append("-");
                else
                    builder.Append(".");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            stopwatch.Restart();
            string rope1 = rope.makerope1(builder.ToString());
            stopwatch.Stop();
            long millis1 = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            string rope2 = rope.makerope2(builder.ToString());
            stopwatch.Stop();
            long millis2 = stopwatch.ElapsedMilliseconds;


            Console.WriteLine("{0} {1}", millis1, millis2);
            Assert.Equal(rope2, rope1);
        }

        [Fact]
        public void InfiniteStringTest()
        {
            InfiniteString infstr = new InfiniteString();

            string result;
            result = infstr.equal1("ab", "ababababababababababababababababababababababababababab");
            Assert.Equal("Equal", result);

            result = infstr.equal1("aba", "ab");
            Assert.Equal("Not equal", result);

            result = infstr.equal1(
                "ababababababababababababababababa",
                "abababababababababababababab");
            Assert.Equal("Not equal", result);

            result = infstr.equal1("abba", "abbaabb");
            Assert.Equal("Not equal", result);
        }

        [Fact]
        public void InfiniteStringBenchmark()
        {
            InfiniteString infstr = new InfiniteString();

            int n = 50;
            string a257 = new string('a', 257);
            string a8387 = new string('a', 8387);

            string a20 = new string('a', 20);
            string a8000 = new string('a', 8000);

            string result;

            stopwatch.Start();
            for (int i = 0; i < n; i++)
                result = infstr.equal2(a257, a8387);
            for (int i = 0; i < n; i++)
                result = infstr.equal1(a257, a8387);


            stopwatch.Restart();
            for (int i = 0; i < n; i++)
                result = infstr.equal2(a257, a8387);
            stopwatch.Stop();
            Console.WriteLine("Equal whiles: {0}", stopwatch.ElapsedTicks);

            stopwatch.Restart();
            for (int i = 0; i < n; i++)
                result = infstr.equal2(a20, a8000);
            stopwatch.Stop();
            Console.WriteLine("Equal whiles: {0}", stopwatch.ElapsedTicks);

            stopwatch.Restart();
            for (int i = 0; i < n; i++)
                result = infstr.equal1(a257, a8387);
            stopwatch.Stop();
            Console.WriteLine("Equal LCM: {0}", stopwatch.ElapsedTicks);

            stopwatch.Restart();
            for (int i = 0; i < n; i++)
                result = infstr.equal1(a20, a8000);
            stopwatch.Stop();
            Console.WriteLine("Equal LCM: {0}", stopwatch.ElapsedTicks);
        }

        [Fact]
        public void PaperAndPaintEasyTest()
        {
            PaperAndPaintEasy paint = new PaperAndPaintEasy();
            long result;

            result = paint.computeArea(7, 4, 3, 0, 2, 2, 4, 4);
            Assert.Equal(22, result);

            result = paint.computeArea(7, 4, 3, 0, 2, 2, 4, 4);
            Assert.Equal(22, result);

            result = paint.computeArea(5, 6, 2, 2, 1, 1, 3, 2);
            Assert.Equal(21, result);

            result = paint.computeArea(3, 13, 1, 0, 1, 8, 2, 12);
            Assert.Equal(35, result);

            result = paint.computeArea(6, 4, 4, 1, 3, 0, 4, 1);
            Assert.Equal(22, result);
        }

        [Fact]
        public void UnionOfIntervalsTest()
        {
            UnionOfIntervals union = new UnionOfIntervals();
            int result;

            result = union.nthElement(
                new[] { 1, 2 },
                new[] { 3, 4 },
                3);
            Assert.Equal(3, result);

            result = union.nthElement(
                new[] { 1, 1, 1 },
                new[] { 2, 2, 2 },
                0);
            Assert.Equal(1, result);

            result = union.nthElement(
                new[] { 1, 1, 1 },
                new[] { 2, 2, 2 },
                1);
            Assert.Equal(1, result);

            result = union.nthElement(
                new[] { 1, 1, 1 },
                new[] { 2, 2, 2 },
                2);
            Assert.Equal(1, result);

            result = union.nthElement(
                new[] { 1, 1, 1 },
                new[] { 2, 2, 2 },
                3);
            Assert.Equal(2, result);

            result = union.nthElement(
                new[] { 1, 1, 1 },
                new[] { 2, 2, 2 },
                5);
            Assert.Equal(2, result);

            result = union.nthElement(
                new[] { 1, 2, 4 },
                new[] { 3, 4, 5 },
                7);
            Assert.Equal(5, result);

            result = union.nthElement(
                new[] { 1, 4 },
                new[] { 3, 5 },
                4);
            Assert.Equal(5, result);

            result = union.nthElement(
                new[] { -9223, 2423, 2869, 6255, -9974, -2746, -8326, -1407, 857, -916, 1985, -7169, -9105, 1786, -4086, -2330, 1972 },
                new[] { -9217, 2426, 2870, 6260, -9965, -2744, -8324, -1400, 860, -911, 1990, -7168, -9100, 1793, -4077, -2321, 1974 },
                86);
            Assert.Equal(2423, result);
        }

        [Fact]
        public void NiceGameOfChessTest()
        {
            NiceGameOfChess chess = new NiceGameOfChess(12, 8);

            stopwatch.Restart();
            long resultRecursive = chess.PawnRecursive(1, 4, 4);
            stopwatch.Stop();
            Console.WriteLine("Recursive {0} in {1} ms", resultRecursive, stopwatch.ElapsedTicks);

            stopwatch.Restart();
            long resultRecursiveMemo = chess.PawnRecursiveMemo(1, 4, 4);
            stopwatch.Stop();
            Console.WriteLine("Recursive Memo {0} in {1} ms", resultRecursiveMemo, stopwatch.ElapsedTicks);

            stopwatch.Restart();
            long resultDp = chess.PawnDp(1, 4, 4);
            stopwatch.Stop();
            Console.WriteLine("DP {0} in {1} ms", resultDp, stopwatch.ElapsedTicks);

            Assert.Equal(resultRecursive, resultDp);
        }

        [Fact]
        public void SlayingDeerTest()
        {
            SlayingDeer deer = new SlayingDeer();
            int result;

            result = deer.getTime(5, 4, 20);
            Assert.Equal(20, result);

            result = deer.getTime(5, 4, 47);
            Assert.Equal(34, result);

            result = deer.getTime(10, 17, 1);
            Assert.Equal(-1, result);

            result = deer.getTime(3, 4, 30);
            Assert.Equal(90, result);

            result = deer.getTime(133, 198, 7515);
            Assert.Equal(7515, result);

            result = deer.getTime(1, 1, 100000);
            Assert.Equal(300010, result);
        }

        [Fact]
        public void ReadingBooksTest()
        {
            ReadingBooks books = new ReadingBooks();
            int result;

            result = books.countBooks(new[] { "introduction", "story", "introduction", "edification" });
            Assert.Equal(1, result);

            result = books.countBooks(new[]
            {
                "introduction", "story", "introduction", "edification", "story",
                "story", "edification", "edification", "edification", "introduction",
                "introduction", "edification", "story", "introduction", "story",
                "edification", "edification", "story", "introduction", "edification",
                "story", "story", "edification", "introduction", "story"
            });
            Assert.Equal(5, result);
        }

        [Fact]
        public void RevealTriangleTest()
        {
            RevealTriangle tri = new RevealTriangle();
            string[] result;

            result = tri.calcTriangle(new[] { "4??", "?2", "1" });
            Assert.Equal(new[] { "457", "92", "1" }, result);

            result = tri.calcTriangle(new[] { "???2", "??2", "?2", "2" });
            Assert.Equal(new[] { "0002", "002", "02", "2" }, result);
        }

        [Fact]
        public void ThueMorseGameTest()
        {
            ThueMorseGame game = new ThueMorseGame();
            string result;

            //result = game.get(9, 6);
            //Assert.Equal("Bob", result);

            //result = game.get(201, 6);
            //Assert.Equal("Bob", result);

            //result = game.get(387, 22);
            //Assert.Equal("Alice", result);

            //result = game.get(499999975, 49);
            //Assert.Equal("Bob", result);

            //result = game.get(499999999, 50);
            //Assert.Equal("Alice", result);

            result = game.get(499540828, 50);
            Assert.Equal("Alice", result);
        }

        [Fact]
        public void SquareFreeStringBenchmark()
        {
            SquareFreeString square = new SquareFreeString();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                sb.Append((char)i);

            stopwatch.Restart();
            square.isSquareFree(sb.ToString());
            stopwatch.Stop();
            Console.WriteLine("Magus: {0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            square.isSquareFreeFernando(sb.ToString());
            stopwatch.Stop();
            Console.WriteLine("Fernando: {0}", stopwatch.ElapsedMilliseconds);
        }

        [Fact]
        public void CreateCalendarRecycle()
        {
            var calendars = new Dictionary<Tuple<DayOfWeek, bool>, int>();

            for (int year = 2002; year < 3000; year++)
            {
                DateTime date = new DateTime(year, 1, 1);
                DayOfWeek dayOfWeek = date.DayOfWeek;
                bool isLeap = DateTime.IsLeapYear(year);

                var key = new Tuple<DayOfWeek, bool>(dayOfWeek, isLeap);
                if (!calendars.ContainsKey(key))
                {
                    calendars.Add(key, year);
                }
                Console.WriteLine($"{key} ==== {year} => {calendars[key]}");
            }

        }

        [Fact]
        public void ModularInequalityTest()
        {
            ModularInequality mod = new ModularInequality();
            int result;

            result = mod.countSolutions(new[] { -693 }, 1265);
            Assert.Equal(2531, result);

            result = mod.countSolutions(new[] { 1, 2, 3 }, 6);
            Assert.Equal(5, result);

            result = mod.countSolutions(new[]
                { -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000, -1000000000},
                0);
            Assert.Equal(1, result);

            result = mod.countSolutions(new[] { 1, -1, 1, -1 }, 4);
            Assert.Equal(3, result);

            result = mod.countSolutions(new[] { 1, -1, 1, -1 }, 8);
            Assert.Equal(5, result);

            result = mod.countSolutions(new[] { 10, 9, -8, 7, -6, 5, 4 }, 46);
            Assert.Equal(9, result);

            result = mod.countSolutions(new[] { 10, 9, -8, 7, -6, 5, 4 }, 35);
            Assert.Equal(0, result);
        }

        [Fact]
        public void AlphabetOrderDiv2Test()
        {
            AlphabetOrderDiv2 al = new AlphabetOrderDiv2();
            string result;

            result = al.isOrdered(new[] { "xye", "xem" });
            Assert.Equal("Possible", result);

            result = al.isOrdered(new[] { "abc", "bcd", "zab", "bcf", "cat" });
            Assert.Equal("Impossible", result);

            result = al.isOrdered(new[] { "abc", "bca" });
            Assert.Equal("Impossible", result);

            result = al.isOrdered(new[] { "aaaaa", "eeeee", "iiiii", "ooooo", "uuuuu" });
            Assert.Equal("Possible", result);

            result = al.isOrdered(new[] { "abc", "bcd", "zab", "bcf" });
            Assert.Equal("Possible", result);

            result = al.isOrdered(new[] { "aaa" });
            Assert.Equal("Possible", result);
        }

        [Fact]
        public void ThreeNPlusOneTest()
        {
            stopwatch.Start();

            Assert.Equal(1, UVA00001_3nP1.Solve(1, 1));
            Assert.Equal(2, UVA00001_3nP1.Solve(2, 2));
            Assert.Equal(8, UVA00001_3nP1.Solve(3, 3));
            Assert.Equal(3, UVA00001_3nP1.Solve(4, 4));

            Assert.Equal(20, UVA00001_3nP1.Solve(1, 10));
            Assert.Equal(125, UVA00001_3nP1.Solve(100, 200));
            Assert.Equal(89, UVA00001_3nP1.Solve(201, 210));
            Assert.Equal(174, UVA00001_3nP1.Solve(900, 1000));

            // Para 10000
            // Agregar DP solito -> 1800 ms
            // Agrega en cada corrida -> 200 ms
            // Basura optimizada -> 196 ms
            // Basura optimizada -> 204 ms
            int testCases = 50000;
            Random random = new Random(1);
            for (int i = 0; i < testCases; i++)
            {
                int n = random.Next(10000);
                int m = n + random.Next(10000 - n);
                UVA00001_3nP1.Solve(n, m);
            }

            stopwatch.Stop();
            Console.WriteLine("Millis: {0}", stopwatch.ElapsedMilliseconds);
        }

        [Fact]
        public void GenerateBigInput1()
        {
            int maxD = 1350;
            int maxL = maxD * (maxD - 1) / 2;

            StringBuilder inputBuilder = new StringBuilder();
            inputBuilder.AppendLine(maxD.ToString());
            inputBuilder.AppendLine(maxL.ToString());
            for (int i = 0; i < maxD; i++)
            {
                for (int j = i + 1; j < maxD; j++)
                {
                    inputBuilder.AppendLine($"{i} {j}");
                }
            }
            File.WriteAllText(@"C:\Users\flaborde\Documents\NetBeansProjects\OmegaUp_DocTechBatchImportTool\dist\Debug\Cygwin-Windows\all.in", inputBuilder.ToString());
        }

        [Fact]
        public void GenerateBigInput2()
        {
            for (int maxD = 20; maxD < 20000; maxD *= 10)
            {
                var rand = new Random();

                List<string> lines = new List<string>();
                for (int i = maxD - 1; i > 0; i--)
                {
                    int[] arr = Shuffle(rand, i);

                    for (int j = 0; j < i / 2; j++)
                        lines.Add($"{arr[j]} {i}");
                }
                StringBuilder inputBuilder = new StringBuilder();
                inputBuilder.AppendLine(maxD.ToString());
                inputBuilder.AppendLine(lines.Count.ToString());
                foreach (string line in lines)
                    inputBuilder.AppendLine(line);

                File.WriteAllText(
                    $@"C:\Users\flaborde\Documents\NetBeansProjects\OmegaUp_DocTechBatchImportTool\dist\Debug\Cygwin-Windows\random{maxD}.in",
                    inputBuilder.ToString());
            }
        }

        [Fact]
        public void GenerateBigInput3()
        {
            int maxD = 5000;
            int maxQueries = 50;
            int maxL = maxD + maxQueries - 1;

            StringBuilder inputBuilder = new StringBuilder();
            inputBuilder.AppendLine(maxD.ToString());
            inputBuilder.Append("M");
            for (int i = 0; i < maxD - 1; i++)
                inputBuilder.Append(" M");
            inputBuilder.AppendLine();
            inputBuilder.AppendLine(maxL.ToString());
            for (int i = 0; i < maxD - 1; i++)
            {
                inputBuilder.AppendLine($"L {i} {i + 1}");
                if (i > maxD - maxQueries - 2)
                    inputBuilder.AppendLine($"Q {i + 1}");
            }
            File.WriteAllText(@"chain.in", inputBuilder.ToString());
        }

        [Fact]
        public void GenerateBigInput4()
        {
            int maxD = 500;
            int maxQueries = 50;
            int maxL = maxD + maxQueries - 1;

            StringBuilder inputBuilder = new StringBuilder();
            inputBuilder.AppendLine(maxD.ToString());
            inputBuilder.Append("M");
            for (int i = 0; i < maxD - 1; i++)
                inputBuilder.Append(" M");
            inputBuilder.AppendLine();
            inputBuilder.AppendLine(maxL.ToString());
            for (int i = 0; i < maxD - 1; i++)
            {
                inputBuilder.AppendLine($"L {i} {i + 1}");
                if (i > maxD - maxQueries - 2)
                    inputBuilder.AppendLine($"Q {i + 1}");
            }
            File.WriteAllText(@"chain_small.in", inputBuilder.ToString());
        }

        [Fact]
        public void GenerateBigInput5()
        {
            int maxQueries = 50;
            int maxD = 100; // 1350
            int maxL = (maxD * (maxD - 1) / 2) + maxQueries;

            StringBuilder inputBuilder = new StringBuilder();
            inputBuilder.AppendLine(maxD.ToString());

            inputBuilder.Append("M");
            for (int i = 0; i < maxD - 1; i++)
                inputBuilder.Append(" M");
            inputBuilder.AppendLine();

            inputBuilder.AppendLine(maxL.ToString());
            for (int i = 0; i < maxD; i++)
            {
                for (int j = i + 1; j < maxD; j++)
                {
                    inputBuilder.AppendLine($"L {i} {j}");
                }
            }
            int[] arr = Shuffle(new Random(), maxD);
            for (int i = 0; i < 50; i++)
            {
                inputBuilder.AppendLine($"Q {arr[i]}");
            }
            File.WriteAllText(@"all.in", inputBuilder.ToString());
        }

        [Fact]
        public void GenerateBigInput6()
        {
            int maxFiles = 1000;
            int maxLinks = 30;

            StringBuilder inputBuilder = new StringBuilder();
            inputBuilder.AppendLine(maxFiles.ToString());

            Random rand = new Random();
            for (int i = 0; i < maxFiles; i++)
            {
                int numLinks = rand.Next(maxLinks);
                int[] links = Shuffle(rand, maxFiles);
                var linksToPrint = links.Where(l => l != i).Take(numLinks);
                if (numLinks > 0)
                    inputBuilder.AppendLine($"{i} {string.Join(" ", linksToPrint)}");
                else
                    inputBuilder.AppendLine(i.ToString());
            }
            inputBuilder.AppendLine(rand.Next(maxFiles).ToString());

            File.WriteAllText($"{maxLinks}links.in", inputBuilder.ToString());
        }

        [Fact]
        public void GenerateBigInput7()
        {


            for (int f = 25; f < 51; f++)
            {
                StringBuilder inputBuilder = new StringBuilder();

                Random rand = new Random();
                int t1 = rand.Next(1, 1000);
                int t4 = rand.Next(t1 + 1, 1001);

                inputBuilder.AppendLine(t4.ToString());
                inputBuilder.AppendLine(t1.ToString());
                inputBuilder.AppendLine(f.ToString());
                for (int i = 0; i < f; i++)
                {
                    int p = rand.Next(0, 1001);
                    inputBuilder.AppendLine(p.ToString());
                }

                File.WriteAllText($"{f}_floors.in", inputBuilder.ToString());
            }


        }

        private static int[] Shuffle(Random rand, int n)
        {
            int[] arr = new int[n - 1];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i;
            for (int i = 0; i < arr.Length; i++)
            {
                int x = rand.Next(i, arr.Length - 1);
                int temp = arr[x];
                arr[x] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }

        [Fact]
        public void TopoSortTest()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (StreamReader stream = File.OpenText(@"C:\Users\flaborde\Desktop\BigInput.txt"))
            {
                int n = int.Parse(stream.ReadLine());
                int l = int.Parse(stream.ReadLine());

                bool[][] graph = new bool[n][];
                for (int i = 0; i < n; i++)
                    graph[i] = new bool[n];

                for (int i = 0; i < l; i++)
                {
                    string line = stream.ReadLine();
                    string[] splitLine = line.Split(' ');
                    int from = int.Parse(splitLine[0]);
                    int to = int.Parse(splitLine[1]);

                    graph[to][from] = true;
                }

                IEnumerable<int> topoSortedNodes = TopologicalSort.SortGraph(graph);
                Console.WriteLine(string.Join(" ", topoSortedNodes));
            }
            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds} ms");
        }

        [Fact]
        public void TopoSortLargeTest()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (StreamReader stream = File.OpenText(@"C:\Users\flaborde\Desktop\BigInput.txt"))
            {
                int n = int.Parse(stream.ReadLine());
                int l = int.Parse(stream.ReadLine());

                var graph = new List<HashSet<int>>();
                for (int i = 0; i < n; i++)
                    graph.Add(new HashSet<int>());

                for (int i = 0; i < l; i++)
                {
                    string line = stream.ReadLine();
                    string[] splitLine = line.Split(' ');
                    int from = int.Parse(splitLine[0]);
                    int to = int.Parse(splitLine[1]);

                    graph[to].Add(from);
                }

                IEnumerable<int> topoSortedNodes = TopologicalSort.SortGraph(graph);
                Console.WriteLine(string.Join(" ", topoSortedNodes));
            }
            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds} ms");
        }

        [Fact]
        public void CyberDojo_HarryPotterTest()
        {
            var harry = new CyberDojo_HarryPotter_Easy.CyberDojo_HarryPotter();
            harry.MinPrice(20, new[] { 0, 0.9, 1 });
        }

        [Fact]
        public void GenerateStates()
        {
            InnerGenerateStates(new int[3], 0, new HashSet<State>());
        }

        class State : IEquatable<State>
        {
            public int[] Values => _values;
            private readonly int[] _values;

            /// <inheritdoc />
            public State(int[] values)
            {
                _values = new int[values.Length];
                Array.Copy(values, _values, values.Length);
                Array.Sort(_values);
            }

            public static implicit operator State(int[] values)
            {
                return new State(values);
            }

            /// <inheritdoc />
            public bool Equals(State other)
            {
                if (ReferenceEquals(null, other))
                    return false;
                if (ReferenceEquals(this, other))
                    return true;

                if (_values.Length != other._values.Length)
                    return false;
                for (int i = 0; i < _values.Length; i++)
                {
                    if (_values[i] != other._values[i])
                        return false;
                }

                return true;
            }

            /// <inheritdoc />
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                if (obj.GetType() != this.GetType())
                    return false;
                return Equals((State)obj);
            }

            /// <inheritdoc />
            public override int GetHashCode()
            {
                int hashCode = 0;
                for (int i = 0; i < _values.Length; i++)
                {
                    hashCode = (hashCode * 397) ^ _values[i];
                }
                return hashCode;
            }

            public static bool operator ==(State left, State right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(State left, State right)
            {
                return !Equals(left, right);
            }
        }

        private void InnerGenerateStates(int[] currentValues, int startIx, HashSet<State> states)
        {
            if (currentValues.Length == startIx)
            {
                State state = currentValues;
                if (!states.Contains(state))
                {
                    Console.WriteLine(string.Join("\t", state.Values));
                    states.Add(state);
                }

                return;
            }

            for (int i = 0; i < currentValues.Length; i++)
            {
                InnerGenerateStates(currentValues, startIx + 1, states);
                currentValues[startIx]++;
            }
            currentValues[startIx] = 0;
        }

        class Node
        {
            public char Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            /// <inheritdoc />
            public Node(char value)
            {
                this.Value = value;
            }

            /// <inheritdoc />
            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                this.ToString(builder, 0);
                return builder.ToString();
            }

            private void ToString(StringBuilder builder, int depth)
            {
                builder.AppendLine($"{new string(' ', depth * 2)}{this.Value}");
                this.Left?.ToString(builder, depth + 1);
                this.Right?.ToString(builder, depth + 1);
            }
        }

        [Fact]
        public void CalculateKnightTest()
        {
            GoogleInterviewKnight knight = new GoogleInterviewKnight();
            knight.CalculateKnight(5);
        }

        [Fact]
        public void AbbreviationTest()
        {
            {
                string response = Abbreviation.Solve("abDbAaxBc", "DABC");
                Assert.Equal("YES", response);
            }

            //{
            //    StringBuilder a = new StringBuilder();
            //    StringBuilder b = new StringBuilder();
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        int range = ('z' - 'a');
            //        char c = (char) ('a' + (i % range));
            //        a.Append(c);
            //        b.Append(char.ToUpper(c));
            //    }
            //    string response = Abbreviation.Solve(a.ToString(), b.ToString());
            //    Assert.Equal("YES", response);
            //}
            //{
            //    string a = new string('a', 1000);
            //    string b = new string('A', 999);
            //    string response = Abbreviation.Solve(a, b);
            //    Assert.Equal("YES", response);
            //}
            //{
            //    string a = new string('a', 1000);
            //    string b = new string('A', 999) + 'B';
            //    string response = Abbreviation.Solve(a, b);
            //    Assert.Equal("NO", response);
            //}
            //{
            //    string a = "abcABC";
            //    string b = "ABCABC";
            //    string response = Abbreviation.Solve(a, b);
            //    Assert.Equal("YES", response);
            //}
            //{
            //    string a = "abcABC";
            //    string b = "ABC";
            //    string response = Abbreviation.Solve(a, b);
            //    Assert.Equal("YES", response);
            //}
            //{
            //    string a = "AbcABC";
            //    string b = "ABC";
            //    string response = Abbreviation.Solve(a, b);
            //    Assert.Equal("NO", response);
            //}
        }

        [Fact]
        public void SetAlarms()
        {
            string directory =
                @"C:\Users\flaborde\OneDrive - National Instruments\Book Club\Programming Challenges\Challenges\01 Set Alarms";

            string result = BookClub.SetAlarms.Solve(Path.Combine(directory, "input_050_10000.txt"));
            string expectedResult = File.ReadAllText(Path.Combine(directory, "output.txt"));

            Assert.Equal(expectedResult.Trim(), result.Trim());
        }

        [Fact]
        public void EmaSupercomputer()
        {
            int area;

            //area = Solution_EmaSupercomputer.twoPluses(
            //    new[]
            //    {
            //        "GGGGGG",
            //        "GBBBGB",
            //        "GGGGGG",
            //        "GGBBGB",
            //        "GGGGGG",
            //    });
            //Assert.Equal(5, area);

            //area = Solution_EmaSupercomputer.twoPluses(
            //    new[]
            //    {
            //        "BGBBGB",
            //        "GGGGGG",
            //        "BGBBGB",
            //        "GGGGGG",
            //        "BGBBGB",
            //        "BGBBGB",
            //    });
            //Assert.Equal(25, area);

            //area = Solution_EmaSupercomputer.twoPluses(
            //    new[]
            //    {
            //        "BBB",
            //    });
            //Assert.Equal(0, area);

            //area = Solution_EmaSupercomputer.twoPluses(
            //    new[]
            //    {
            //        "BGB",
            //        "GGG",
            //        "BGB",
            //    });
            //Assert.Equal(5, area);

            //area = Solution_EmaSupercomputer.twoPluses(
            //    new[]
            //    {
            //        "BGBBGB",
            //        "GGGGGG",
            //        "BGBBGB",
            //    });
            //Assert.Equal(25, area);

            area = Solution_EmaSupercomputer.twoPluses(
                new[]
                {
                    "BBGBBGBB",
                    "BBGBBGBB",
                    "GGGGGGGG",
                    "BBGBBGBB",
                    "BBGBBGBB",
                });
            Assert.Equal(25, area);
        }

        [Fact]
        public void BomberMan()
        {
            string[] result;

            result = Solution_Bomberman.bomberMan(
                    3,
                    new[]
                    {
                        ".......",
                        "...O...",
                        "....O..",
                        ".......",
                        "OO.....",
                        "OO.....",
                    });
            PrintGrid(result, 3);

            result = Solution_Bomberman.bomberMan(
                    11,
                    new[]
                    {
                    "O..O",
                    ".O..",
                    "....",
                    });
            PrintGrid(result, 11);
        }

        private static void PrintGrid(string[] gridExplosions, int n)
        {
            var s = new StringBuilder();
            s.AppendLine($"t = {n}");
            for (int i = 0; i < gridExplosions.Length; i++)
            {
                s.AppendLine(gridExplosions[i]);
            }
            s.AppendLine();
            s.AppendLine();

            Console.WriteLine(s.ToString());
        }

        [Fact]
        public void RoadsAndLibraries()
        {
            string resultS;
            resultS = Solution_RoadsAndLibraries.roadsAndLibraries(File.ReadAllText(@"C:\Users\Magus\Desktop\input04.txt"));
            Console.WriteLine(resultS);

            long result;

            result = Solution_RoadsAndLibraries.roadsAndLibraries(3, 2, 1, new int[][]
            {
                new int[]{1, 2 },
                new int[]{3, 1 },
                new int[]{2, 3 },
            });
            Assert.Equal(4, result);

            result = Solution_RoadsAndLibraries.roadsAndLibraries(4, 2, 1, new int[][]
            {
                new int[]{1, 2 },
            });
            Assert.Equal(7, result);

            result = Solution_RoadsAndLibraries.roadsAndLibraries(6, 2, 1, new int[][]
            {
                new int[]{1, 3 },
                new int[]{3, 4 },
                new int[]{2, 4 },
                new int[]{1, 2 },
                new int[]{2, 3 },
                new int[]{5, 6 },
            });
            Assert.Equal(8, result);
        }

        [Fact]
        public void TheMaximumSubarray()
        {
            int[] result;

            result = Solution_TheMaximumSubarray.maxSubarray(new[] { -2, -3, -1, -4, -6 });
            result.Should().BeEquivalentTo(new[] { -1, -1 });

            result = Solution_TheMaximumSubarray.maxSubarray(new[] { 1, 2, 3, 4 });
            result.Should().BeEquivalentTo(new[] { 10, 10 });

            result = Solution_TheMaximumSubarray.maxSubarray(new[] { 2, -1, 2, 3, 4, -5 });
            result.Should().BeEquivalentTo(new[] { 10, 11 });
        }

        [Fact]
        public void KingdomDivision()
        {
            int r = Solution_KingdomDivision.KingdomDivision(
                5,
                new int[][]
                {
                        new int[]{1, 2},
                        new int[]{1, 3},
                        new int[]{3, 4},
                        new int[]{3, 5},
                });

            r.Should().Be(4);
        }

        [Fact]
        public void BricksGame()
        {
            int r;

            r = Solution_BricksGame.BricksGame(new[] { 123, 4, 56, 19, 20 });
            r.Should().Be(183);

            r = Solution_BricksGame.BricksGame(new[] { 1, 2, 3, 4, 5 });
            r.Should().Be(6);
        }

        [Fact]
        public void SurroundedRegions()
        {
            var dut = new TopCoderCS.LeetCode.SurroundedRegions.Solution();

            char[][] board;

            board = new char[][]{
                new char[] {'X','X','X','X'},
                new char[] {'X','O','O','X'},
                new char[] {'X','X','O','X'},
                new char[] {'X','O','X','X'}
            };
            dut.Solve(board);
            for (int i = 0; i < board.Length; i++)
            {
                Console.WriteLine(new string(board[i]));
            }

            board = new char[][]{
                new char[] {'O','O','O','O','O','O','O','O','X','O','O','O','O','O','X','O','O','O','O','O'},
                new char[] {'O','O','O','O','O','O','O','X','O','O','O','O','O','O','O','O','O','O','O','O'},
                new char[] {'X','O','O','X','O','X','O','O','O','O','X','O','O','X','O','O','O','O','O','O'},
                new char[] {'O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','X','X','O'},
                new char[] {'O','X','X','O','O','O','O','O','O','X','O','O','O','O','O','O','O','O','O','O'},
                new char[] {'O','O','O','O','X','O','O','O','O','O','O','X','O','O','O','O','O','X','X','O'},
                new char[] {'O','O','O','O','O','O','O','X','O','O','O','O','O','O','O','O','O','O','O','O'},
                new char[] {'O','O','O','O','O','O','O','O','O','O','O','O','O','X','O','O','O','O','O','O'},
                new char[] {'O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','X','O'},
                new char[] {'O','O','O','O','O','X','O','O','O','O','O','O','O','O','O','O','O','O','O','O'},
                new char[] {'O','O','O','O','O','O','O','O','X','O','O','O','O','O','O','O','O','O','O','O'},
                new char[] {'O','O','O','O','X','O','O','O','O','X','O','O','O','O','O','O','O','O','O','O'},
                new char[] {'O','O','O','O','O','O','O','O','X','O','O','O','O','O','O','O','O','O','O','O'},
                new char[] {'X','O','O','O','O','O','O','O','O','X','X','O','O','O','O','O','O','O','O','O'},
                new char[] {'O','O','O','O','O','O','O','O','O','O','O','X','O','O','O','O','O','O','O','O'},
                new char[] {'O','O','O','O','X','O','O','O','O','O','O','O','O','X','O','O','O','O','O','X'},
                new char[] {'O','O','O','O','O','X','O','O','O','O','O','O','O','O','O','X','O','X','O','O'},
                new char[] {'O','X','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O'},
                new char[] {'O','O','O','O','O','O','O','O','X','X','O','O','O','X','O','O','X','O','O','X'},
                new char[] {'O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O','O'}
            };
            dut.Solve(board);
            for (int i = 0; i < board.Length; i++)
            {
                Console.WriteLine(new string(board[i]));
            }
        }

        [Fact]
        public void DailyTemperatures()
        {
            Solution_DailyTemperatures dt = new Solution_DailyTemperatures();
            int[] result;

            result = dt.DailyTemperatures(new[] { 34, 80, 80, 34, 34, 80, 80, 80, 80, 34 });
            result.Should().BeEquivalentTo(new[] { 1, 0, 0, 2, 1, 0, 0, 0, 0, 0 });

            result = dt.DailyTemperatures(new[] { 89, 62, 70, 58, 47, 47, 46, 76, 100, 70 });
            result.Should().BeEquivalentTo(new[] { 8, 1, 5, 4, 3, 2, 1, 1, 0, 0 });
        }

        [Fact]
        public void Trap()
        {
            var sut = new TopCoderCS.LeetCode.TrappingRainWater.Solution();
            int result;

            result = sut.Trap(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            result.Should().Be(6);

            result = sut.Trap(new[] { 4, 2, 0, 3, 2, 5 });
            result.Should().Be(9);

            result = sut.Trap(new[] { 2, 1, 0, 1 });
            result.Should().Be(1);
        }

        [Fact]
        public void NQueens()
        {
            var sut = new TopCoderCS.LeetCode.NQueens.Solution();

            var result = sut.SolveNQueens(4);
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result[i].Count; j++)
                {
                    Console.WriteLine(result[i][j]);
                }
                Console.WriteLine("-------------------");
            }
        }

        [Fact]
        public void DistributeCoinsInBinaryTree()
        {
            var sut = new TopCoderCS.LeetCode.DistributeCoinsInBinaryTree.Solution();

            int result;
            DistTreeNode tree;
            tree =
                new DistTreeNode(0,
                    new DistTreeNode(2,
                        new DistTreeNode(0,
                            new DistTreeNode(1, null, null),
                            null),
                        new DistTreeNode(0, null, null)),
                    new DistTreeNode(3, null, null));
            result = sut.DistributeCoins(tree);
            result.Should().Be(5);

            tree =
                new DistTreeNode(0,
                    new DistTreeNode(1,
                        null,
                        new DistTreeNode(2)),
                    new DistTreeNode(2,
                        new DistTreeNode(2),
                        new DistTreeNode(0,
                            new DistTreeNode(0),
                            null)));
            result = sut.DistributeCoins(tree);
            result.Should().Be(6);
        }

        [Fact]
        public void DungeonGame()
        {
            var sut = new TopCoderCS.LeetCode.DungeonGame.Solution();

            int result;

            result = sut.CalculateMinimumHP(
                new int[][]
                {
                    new int[]{-2, -3, 3},
                    new int[]{-5, -10, 1},
                    new int[]{10, 30, -5},
                });
            result.Should().Be(7);

            result = sut.CalculateMinimumHP(
                new int[][]
                {
                    new int[]{0}
                });
            result.Should().Be(1);

            result = sut.CalculateMinimumHP(
                new int[][]
                {
                    new int[]{100}
                });
            result.Should().Be(1);

            result = sut.CalculateMinimumHP(
                new int[][]
                {
                    new int[]{0, 0}
                });
            result.Should().Be(1);

            result = sut.CalculateMinimumHP(
                new int[][]
                {
                    new []{1, -3, 3 },
                    new []{0, -2, 0 },
                    new []{-3, -3, -3 }
                });
        }

        [Fact]
        public void BinaryTreeMaximumPathSum()
        {
            var sut = new TopCoderCS.LeetCode.BinaryTreeMaximumPathSum.Solution();
            BtmpsTreeNode tree;
            int result;

            tree =
                new BtmpsTreeNode(-10,
                    new BtmpsTreeNode(9, null, null),
                    new BtmpsTreeNode(20, 
                        new BtmpsTreeNode(15, null, null), 
                        new BtmpsTreeNode(7, null, null)
                    )
                );
            result = sut.MaxPathSum(tree);
            result.Should().Be(42);

            tree = new BtmpsTreeNode(-3, null, null);
            result = sut.MaxPathSum(tree);
            result.Should().Be(-3);

            tree = new BtmpsTreeNode(3, null, null);
            result = sut.MaxPathSum(tree);
            result.Should().Be(3);

            tree = new BtmpsTreeNode(3,
                new BtmpsTreeNode(2, null, null),
                null);
            result = sut.MaxPathSum(tree);
            result.Should().Be(5);

            tree =
                new BtmpsTreeNode(5,
                    new BtmpsTreeNode(4,
                        new BtmpsTreeNode(3,
                            new BtmpsTreeNode(2,
                                new BtmpsTreeNode(1, null, null),
                                null),
                            null),
                        null),
                    null);
            result = sut.MaxPathSum(tree);
            result.Should().Be(15);

            tree =
                new BtmpsTreeNode(-1,
                    new BtmpsTreeNode(-2, null, null),
                    new BtmpsTreeNode(-3, null, null)
                );
            result = sut.MaxPathSum(tree);
            result.Should().Be(-1);

            tree =
                new BtmpsTreeNode(1,
                    new BtmpsTreeNode(-2, null, null),
                    new BtmpsTreeNode(3, null, null)
                );
            result = sut.MaxPathSum(tree);
            result.Should().Be(4);
        }

        [Fact]
        public void DeleteNodesAndReturnForest()
        {
            var sut = new TopCoderCS.LeetCode.DeleteNodesAndReturnForest.Solution();
            DnarfTreeNode tree;
            IList<DnarfTreeNode> result;

            tree =
                new DnarfTreeNode(1,
                    new DnarfTreeNode(2, 
                        new DnarfTreeNode(4),
                        new DnarfTreeNode(5)),
                    new DnarfTreeNode(3,
                        new DnarfTreeNode(6),
                        new DnarfTreeNode(7)
                    )
                );
            result = sut.DelNodes(tree, new int[] { 3, 5 });
            result.Should().HaveCount(3);
        }

        [Fact]
        public void TheSkylineProblem()
        {
            var sut = new TopCoderCS.LeetCode.TheSkylineProblem.Solution();
            var ret = sut.GetSkyline(new int[][] { new[] { 2, 9, 10 }, new[] { 3, 7, 15 }, new[] { 5, 12, 12 }, new[] { 15, 20, 10 }, new[] { 19, 24, 8 } });
            ret.Should().BeEquivalentTo(new int[][] { new int[] { 2, 10 }, new int[] { 3, 15 }, new int[] { 7, 12 }, new int[] { 12, 0 }, new int[] { 15, 10 }, new int[] { 20, 8 }, new int[] { 24, 0 } });
        }

        [Fact]
        public void FindTheWinnerOfTheCircularGame()
        {
            var good = new TopCoderCS.LeetCode.FindTheWinnerOfTheCircularGame.ArraySolution();
            var sut = new TopCoderCS.LeetCode.FindTheWinnerOfTheCircularGame.CompressingListSolution();

            int expected = good.FindTheWinner(7, 5);
            int actual = sut.FindTheWinner(7, 5);
            actual.Should().Be(expected);

            for (int i = 5; i < 500; i++)
            {
                for (int j = 3; j < i; j++)
                {
                    expected = good.FindTheWinner(i, j);
                    actual = sut.FindTheWinner(i, j);
                    actual.Should().Be(expected, $"because {i},{j} should be {expected}");
                }
            }
        }
    }
}
