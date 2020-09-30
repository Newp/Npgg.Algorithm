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
            //4->3->2->1 �������� �����Ѵ�.
            if (size == 1)
            {
                results.Add(ArrayClone(array));
            }

            for (int i = 0; i < size; i++)
            {
                HeapPermutation(array, size - 1, results);
                // ����� Ȧ���� 0��°, ¦���� i��°�� �������� ����
                Swap(array, (size & 1) == 1 ? 0: i,  size - 1);
            }
        }
    }
}
