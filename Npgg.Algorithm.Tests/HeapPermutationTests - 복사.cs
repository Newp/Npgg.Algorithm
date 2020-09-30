using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Npgg.Algorithm.Tests
{
    public class HeapPermutationTests2 : PermutationFixture
    {
        public override IEnumerable<T[]> Permutation<T>(T[] array)
        {
            var results = new List<T[]>();

            HeapPermutation<T>(array, array.Length, results);

            return results;
        }

        public void HeapPermutation<T>(T[] array, int size, List<T[]> results)
        {
            //4->3->2->1 역순으로 대입한다.
            if (size == 1)
            {
                results.Add(ArrayClone(array));
            }

            for (int i = 0; i < size; i++)
            {
                HeapPermutation(array, size - 1, results);
                // 사이즈가 홀수면 0번째, 짝수면 i번째와 마지막을 스왑
                Swap(array, (size & 1) == 1 ? 0: i,  size - 1);
            }
        }
    }
}
