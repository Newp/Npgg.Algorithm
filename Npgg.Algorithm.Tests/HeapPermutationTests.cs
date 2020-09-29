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
            // ����� 1�̸� Array�� ����մϴ�.
            if (size == 1)
            {
                yield return ArrayClone(array);
                yield break;
            }

            for (int i = 0; i < size; i++)
            {
                // ��� �Լ� ȣ��
                foreach (var arr in HeapPermutation(array, size - 1))
                {
                    yield return ArrayClone(array);
                }

                // ����� Ȧ���� ù��°�� �������� �����մϴ�.
                if (size % 2 == 1)
                    Swap(array, 0, size - 1);

                // ����� ¦���� i��°�� �������� �����մϴ�.
                else
                    Swap(array, i, size - 1);
            }

            yield break;
        }


    }
}
