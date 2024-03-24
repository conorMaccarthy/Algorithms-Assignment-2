using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputBehavior : MonoBehaviour
{
    [SerializeField] MergeSort sorter;
    [SerializeField] GameObject displayElement;
    private GameObject elementBase;
    bool hasSorted = false;

    private List<int> listToSort = new List<int>();

    private void Start()
    {
        elementBase = GameObject.Find("ProtoElement");
    }

    public void AddElement()
    {
        if (transform.childCount < 20 && !hasSorted) 
        {
            GameObject newElement = Instantiate(elementBase);
            newElement.transform.SetParent(transform);
            newElement.GetComponent<InputFieldBehavior>().index = transform.childCount - 1;

            listToSort.Add(11111);
        }
    }

    public void RemoveElement()
    {
        if (transform.childCount != 0 && !hasSorted)
        {
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
            listToSort.RemoveAt(transform.childCount - 1);
        }
    }

    public void SetElement(int index, int value)
    {
        listToSort[index] = value;
    }

    public void StartSort()
    {
        bool canSort = true;

        for (int i = 0; i < listToSort.Count; i++)
        {
            if (listToSort[i] > 9999) canSort = false;
        }

        if (canSort)
        {
            sorter.Sort(listToSort);

            hasSorted = true;

            DisplaySortedList(listToSort);
        }
        else Debug.Log("Please fill out all cells");
    }

    public void DisplaySortedList(List<int> newList)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < newList.Count; i++)
        {
            GameObject elementToDisplay = Instantiate(displayElement);
            elementToDisplay.transform.SetParent(transform);
            elementToDisplay.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = newList[i].ToString();
        }
    }

    public void ClearElements()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        listToSort.Clear();
        hasSorted = false;
    }
}
