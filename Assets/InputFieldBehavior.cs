using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldBehavior : MonoBehaviour
{
    public int index;
    public int value;
    public InputBehavior inputBehavior;

    public void SetElement()
    {
        inputBehavior.SetElement(index, value);
    }

    public void SetValue(string newValue)
    {
        value = int.Parse(newValue);
    }
}
