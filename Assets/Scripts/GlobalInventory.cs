using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public static bool firstDoorKey = false;
    public bool internalDoorKey;
    
    void Update()
    {
        internalDoorKey = firstDoorKey;
    }
}
