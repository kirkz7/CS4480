using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmController : MonoBehaviour
{
    public static LeftArmController _instance;
    void Start()
    {
        _instance = this;
    }
    public void enableRock(Rock.RockType rockType, bool enabled)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
            transform.GetChild((int)rockType).gameObject.SetActive(enabled); //ASSUMES HIERARCHY IS ACCURATE, BAD PRACTICE!!! (but efficient code)
    }
}
