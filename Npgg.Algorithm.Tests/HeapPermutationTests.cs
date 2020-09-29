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
            // 사이즈가 1이면 Array를 출력합니다.
            if (size == 1)
            {
                yield return ArrayClone(array);
                yield break;
            }

            for (int i = 0; i < size; i++)
            {
                // 재귀 함수 호출
                foreach (var arr in HeapPermutation(array, size - 1))
                {
                    yield return ArrayClone(array);
                }

                // 사이즈가 홀수면 첫번째와 마지막을 스왑합니다.
                if (size % 2 == 1)
                    Swap(array, 0, size - 1);

                // 사이즈가 짝수면 i번째와 마지막을 스왑합니다.
                else
                    Swap(array, i, size - 1);
            }

            yield break;
        }


    }
}
