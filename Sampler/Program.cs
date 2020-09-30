
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Sampler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var array = new int[] { 1, 2, 3, 4,5,6,7,8,9};

            Stopwatch watch = new Stopwatch();
            Program program = new Program();
            for (int i =0;i<10;i++)
            {
                watch.Restart();

                var result = program.HeapPermutation(array);

                watch.Stop();
                Console.WriteLine($"count : {result.Count}, elapsed : {watch.ElapsedMilliseconds}ms");
            }
        }

        public List<T[]> HeapPermutation<T>(T[] array)
        {
            //int expectCount = Enumerable.Range(1, array.Length).Aggregate(1, (p, item) => p * item);
            //List<T[]> results = new List<T[]>(expectCount);

            List<T[]> results = new List<T[]>();
            HeapPermutation(array, array.Length, results);

            return results;
        }

        public void HeapPermutation<T>(T[] array, int cursor, List<T[]> results)
        {
            //4->3->2->1 역순으로 대입한다.
            if (cursor == 1)
            {
                results.Add(ArrayClone(array));
            }

            for (int i = 0; i < cursor; i++)
            {
                HeapPermutation(array, cursor - 1, results);
                // 사이즈가 홀수면 0번째, 짝수면 i번째와 마지막을 스왑
                Swap(array, (cursor & 1) == 1 ? 0 : i, cursor - 1);
            }
        }
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

            return result;
        }

    }
}
