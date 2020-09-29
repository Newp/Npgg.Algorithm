using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Npgg.Algorithm.Tests
{


    public abstract class PermutationFixture
    {
        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        //[InlineData(50)]
        public void AllCountTest<T>(int count)
        {
            var array = Enumerable.Range(1, count).ToArray();

            var list = new List<string>();

            int expectCount = Enumerable.Range(1, count).Aggregate(1, (p, item) => p * item);

            var allcount = Permutation(array).Count();

            Assert.Equal(expectCount, allcount);

        }


        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public void DuplicationTest<T>(int count)
        {
            var array = Enumerable.Range(1, count).ToArray();

            var list = new List<string>();

            var result = Permutation(array);


            foreach (var shuffledArray in result)
            {
                var line = string.Join(',', shuffledArray);

                Assert.DoesNotContain(line, list);

                list.Add(line);
            }
        }

        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        public void AllElementExistsTest(int count)
        {
            var array = Enumerable.Range(1, count).ToArray();

            foreach (var shuffledArray in Permutation(array))
            {
                foreach(int value in array)
                {
                    Assert.Contains(value, shuffledArray);
                }
            }
        }

        public abstract IEnumerable<T[]> Permutation<T>(T[] arr);

        public void Swap<T>(T[] arr, int left, int right)
        {
            if (left == right)
                return;

            T temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

        public T[] ArrayClone<T>(T[] source)
        {
            var result = new T[source.Length];
            source.CopyTo(result, 0);
            
            //Buffer.BlockCopy(source, 0, result, 0, source.Length);
            return result;
        }

    }
}
