using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Npgg.Algorithm.Tests
{
    public class RecursivePermutationTests : PermutationFixture
    {

        [Fact]
        public void ArrayCloneTest()
        {
            var array = new int[] { 5, 4, 3, 2, 1 };

            var clone = ArrayClone(array);

            Assert.True(array.SequenceEqual(clone));

        }

        public override IEnumerable<T[]> Permutation<T>(T[] array) => RecursivePermutation(array, 0);

        public IEnumerable<T[]> RecursivePermutation<T>(T[] array, int currentDepth)
        {
            var length = array.Length;
            if (currentDepth == length)
            {
                yield return ArrayClone(array);
                yield break;
            }

            for (int i = currentDepth; i < length; i++)
            {
                Swap(array, i, currentDepth);
                foreach (var result in RecursivePermutation(array, currentDepth + 1))
                {
                    yield return ArrayClone(array);
                }
                Swap(array, i, currentDepth);
            }
        }
    }
}
