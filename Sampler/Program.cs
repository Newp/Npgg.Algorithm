
using System;
using System.Linq;
using System.Collections.Generic;

namespace Sampler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = HeapPermutation(new int[] { 1, 2, 3, 4 }, 4);

            foreach(var arr in result)
            {
                Console.WriteLine(string.Join(',', arr));
            }
        }

        static IEnumerable<int[]> HeapPermutation(int[] array, int size)
        {
            // 사이즈가 1이면 Array를 출력합니다.
            if (size == 1)
            {
                yield return array;
                yield break;
            }

            for (int i = 0; i < size; i++)
            {
                // 재귀 함수 호출
                foreach(var arr in HeapPermutation(array, size - 1))
                {
                    yield return array;
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

        static void Swap<T>(T[] arr, int left, int right)
        {
            if (left == right)
                return;

            T temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}
