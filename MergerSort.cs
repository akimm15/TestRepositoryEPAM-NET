// <copyright file = "MergerSort.cs" company = "EPAM">
//  MergerSort
// </copyright>
namespace MergerSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Sort array
    /// </summary>
    public class MergerSort
    {
        /// <summary>
        /// Merge sort method
        /// </summary>
        /// <param name="unsortedArray"> Input array </param>
        /// <param name="leftIndex"> Input first element</param>
        /// <param name="rightIndex"> Input last element </param>
        /// <returns> Complete array </returns>
        public static int[] MergeSort(int[] unsortedArray, int leftIndex, int rightIndex)
        {
            if (unsortedArray == null)
            {
                throw new ArgumentNullException(nameof(unsortedArray));
            }

            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                MergeSort(unsortedArray, leftIndex, middleIndex);
                MergeSort(unsortedArray, middleIndex + 1, rightIndex);
                Merge(unsortedArray, leftIndex, middleIndex, rightIndex);
            }

            return unsortedArray;
        }

        /// <summary>
        /// Sorts parts of an array
        /// </summary>
        /// <param name="unsortedArray"> Input array </param>
        /// <param name="leftIndex"> Input first element</param>
        /// <param name="middleIndex"> Input middle index </param>
        /// <param name="rightIndex"> Input last element </param>
        private static void Merge(int[] unsortedArray, int leftIndex, int middleIndex, int rightIndex)
        {
            int lengthLeft = middleIndex - leftIndex + 1;
            int lengthRight = rightIndex - middleIndex;
            int[] leftArray = new int[lengthLeft + 1];
            int[] rightArrray = new int[lengthRight + 1];
            for (int i = 0; i < lengthLeft; i++)
            {
                leftArray[i] = unsortedArray[leftIndex + i];
            }

            for (int j = 0; j < lengthRight; j++)
            {
                rightArrray[j] = unsortedArray[middleIndex + j + 1];
            }

            leftArray[lengthLeft] = int.MaxValue;
            rightArrray[lengthRight] = int.MaxValue;
            int start = 0;
            int end = 0;

            for (int k = leftIndex; k <= rightIndex; k++)
            {
                if (leftArray[start] <= rightArrray[end])
                {
                    unsortedArray[k] = leftArray[start];
                    start++;
                }
                else
                {
                    unsortedArray[k] = rightArrray[end];
                    end++;
                }
            }
        }
    }
}