using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IterateEnum : MonoBehaviour
{  
  public List <string> list = new List <string> ();  
    public enum MyEnum
    {
        Element1,
        Element2,
        Element3,
        Element4,
        Element5
    }

  
    private MyEnum currentEnumValue;

    private void Start()
    {
       
        currentEnumValue = MyEnum.Element1;
    }

    private void Update()
    {
      
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        
        if (scrollInput > 0f)
        {
            IterateEnums(true);
        }
    }

  
    private void IterateEnums(bool forward)
    {
        int currentIndex = (int)currentEnumValue;
        int enumLength = Enum.GetValues(typeof(MyEnum)).Length;

        int nextIndex;

        if (forward)
        {
            nextIndex = (currentIndex + 1) % enumLength;
        }
        else
        {
            nextIndex = (currentIndex - 1 + enumLength) % enumLength;
        }

        currentEnumValue = (MyEnum)nextIndex;
        list.Add(currentEnumValue.ToString()) ;
      
        Debug.Log("Current Enum Value: " + currentEnumValue);
    }
}
