using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Npgg.Algorithm.Tests
{
    public class PermutationTests
    {
        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        //[InlineData(50)]
        public void DuplicationTest<T>(int count)
        {
            var array = Enumerable.Range(1, count).ToArray();

            var list = new List<string>();
            foreach (var shuffledArray in Permutation(array, 0))
            {
                var line = string.Join(',', shuffledArray);

                Assert.DoesNotContain(line, list);

                list.Add(line);
            }
        }

        [Theory]
        [InlineData(5)]
        [InlineData(20)]
        //[InlineData(50)]
        public void AllElementExistsTest(int count)
        {
            var array = Enumerable.Range(1, count).ToArray();

            foreach (var shuffledArray in Permutation(array, 0))
            {
                foreach(int value in array)
                {
                    Assert.Contains(value, shuffledArray);
                }
            }
        }

        public static IEnumerable<T[]> Permutation<T>(T[] arr, int currentDepth)
        {
            var length = arr.Length;
            if (currentDepth == length)
            {
                yield return arr;
                yield break;
            }

            for (int i = currentDepth; i < length; i++)
            {
                Swap(arr, i, currentDepth, true);
                foreach (var result in Permutation(arr, currentDepth + 1))
                {
                    yield return result;
                }
                Swap(arr, i, currentDepth, false);
            }
        }

        static void Swap<T>(T[] arr, int left, int right, bool print)
        {
            if (left == right)
                return;

            T temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

    }
}
