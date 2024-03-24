using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSort : MonoBehaviour
{
    [SerializeField] InputBehavior inputBehavior;
    [SerializeField] AudioSource audioSource;

    public void Sort(List<int> list)
    {
        if (list.Count <= 1) return;
        
        int pivotIndex = list.Count / 2;
        List<int> leftSubList = new List<int>();
        List<int> rightSubList = new List<int>();

        for (int i = 0; i < pivotIndex; i++)
        {
            leftSubList.Add(list[i]);
        }
        for (int i = pivotIndex; i < list.Count; i++)
        {
            rightSubList.Add(list[i]);
        }

        Sort(leftSubList);
        Sort(rightSubList);

        StartCoroutine(MergeLists(list, leftSubList, rightSubList));
    }

    private IEnumerator MergeLists(List<int> listToSort, List<int> leftList, List<int> rightList)
    {
        int mainIndex = 0;
        int leftIndex = 0;
        int rightIndex = 0;

        while (leftIndex < leftList.Count && rightIndex < rightList.Count)
        {
            if (leftList[leftIndex] < rightList[rightIndex])
            {
                listToSort[mainIndex] = leftList[leftIndex];
                leftIndex++;
                mainIndex++;
            }
            else
            {
                listToSort[mainIndex] = rightList[rightIndex];
                rightIndex++;
                mainIndex++;
            }

            inputBehavior.DisplaySortedList(listToSort);
            audioSource.Play();
            yield return new WaitForSeconds(0.5f);
        }

        while (leftIndex < leftList.Count)
        {
            listToSort[mainIndex] = leftList[leftIndex];
            leftIndex++;
            mainIndex++;

            inputBehavior.DisplaySortedList(listToSort);
            audioSource.Play();
            yield return new WaitForSeconds(0.5f);
        }

        while (rightIndex < rightList.Count)
        {
            listToSort[mainIndex] = rightList[rightIndex];
            rightIndex++;
            mainIndex++;

            inputBehavior.DisplaySortedList(listToSort);
            audioSource.Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
