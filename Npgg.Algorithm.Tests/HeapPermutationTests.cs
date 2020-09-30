using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Npgg.Algorithm.Tests
{
    public class HeapPermutationTests : PermutationFixture
    {
        public override IEnumerable<T[]> Permutation<T>(T[] array) => HeapPermutation(array, array.Length);

        public IEnumerable<T[]> HeapPermutation<T>(T[] array, int size)
        {
            //4->3->2->1 �������� �����Ѵ�.
            if (size == 1)
            {
                yield return ArrayClone(array);
                yield break;
            }

            for (int i = 0; i < size; i++)
            {
                foreach (var arr in HeapPermutation(array, size - 1))
                {
                    yield return ArrayClone(array);
                }
                // ����� Ȧ���� 0��°, ¦���� i��°�� �������� ����
                Swap(array, (size & 1) == 1 ? 0: i,  size - 1);

            }

            yield break;
        }


    }
}
